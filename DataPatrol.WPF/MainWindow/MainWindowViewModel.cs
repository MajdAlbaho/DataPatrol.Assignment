using System.Collections.ObjectModel;
using DataPatrol.Services.IGeneratorServices;
using DataPatrol.WPF.Base;
using System.Threading;
using System.Windows.Input;
using DataPatrol.DataModel.CustomModels;
using System;
using System.Linq;
using System.Text.Json;
using System.Windows;
using DataPatrol.DataModel.ResponseModels.GeneratorResponseModels;
using DataPatrol.WPF.MainWindow.ListenerComponent;
using System.Net.NetworkInformation;

namespace DataPatrol.WPF.MainWindow
{
    public partial class MainWindowViewModel
    {
        public MainWindowViewModel() {
            if (IsDesignMode()) {
                // write code for design mode
                ApiUrl = "http://localhost:5129/Generator";
            }
        }
    }


    public partial class MainWindowViewModel : BaseViewModel<MainWindowView>
    {
        private readonly ISendApiRequestService _sendApiRequestService;

        public MainWindowViewModel(ISendApiRequestService sendApiRequestService,
                ListenerViewModel listenerViewModel) {
            _sendApiRequestService = sendApiRequestService;
            ListenerViewModel = listenerViewModel;
            if (listenerViewModel.GetView() is ListenerView view)
                ListenerViewControl = view;

            ApiUrl = "http://localhost:5129/Generator";
            StartCommand = new RelayCommand(Start);
            StopCommand = new RelayCommand(Stop);
            RegisterCommand = new RelayCommand(Register);
            UnRegisterCommand = new RelayCommand(UnRegister);
        }

        public int NextRequest { get; set; }
        private Timer Timer { get; set; }
        public string ApiUrl { get; set; }

        private string _apiStatus;

        public string ApiStatus {
            get { return _apiStatus; }
            set { _apiStatus = value; OnPropertyChanged(); }
        }


        private ListenerView _listenerView;
        public ListenerView ListenerViewControl {
            get { return _listenerView; }
            set { _listenerView = value; OnPropertyChanged(); }
        }

        public ListenerViewModel ListenerViewModel { get; set; }

        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand UnRegisterCommand { get; set; }


        private void Start() {
            Timer = new Timer(SendApiRequest, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        }

        private void SendApiRequest(object state) {
            BusyExecute(async () => {
                NextRequest = 10;
                ApiStatus = "Getting new value...";
                var response = await _sendApiRequestService.SendApiRequest(ApiUrl);

                if (!string.IsNullOrWhiteSpace(response)) {
                    var responseBody = JsonSerializer.Deserialize<GenerateResponseModel>(response);
                    var number = responseBody?.Data?.Number;
                    ApiStatus = $"the new value is : {number}";

                    if (number != null)
                        ListenerViewModel.IncreaseCount(number.Value);
                }
            });
        }


        private void Stop() {
            Timer?.Dispose();
        }

        private void Register() {
            try {
                var index = ListenerViewModel.GetTotalListeners() + 1;
                if (index > 10) {
                    MessageBox.Show("You are not able to add more listeners");
                    return;
                }

                ListenerViewModel.AddListener(new Listener {
                    Name = $"Listener {index}",
                    Target = index
                });
            } catch (Exception ex) {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }

        private void UnRegister() {
            try {
                ListenerViewModel.RemoveSelectedListener();
            } catch (Exception ex) {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }

    }
}
