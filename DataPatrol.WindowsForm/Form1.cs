using System;
using System.Windows.Forms;
using DataPatrol.WindowsForm.AppServices;
using System.Text.Json;
using DataPatrol.WindowsForm.WindowsFormModels;
using Timer = System.Threading.Timer;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;

namespace DataPatrol.WindowsForm
{
    public partial class MainForm : Form
    {
        private readonly SendApiRequestService _apiRequestService;

        public MainForm() {
            InitializeComponent();

            _apiRequestService = new SendApiRequestService();
            Listeners = new BindingList<Listener>();

            InitializeDataGrid();
        }

        private void InitializeDataGrid() {
            ListenerDataGrid.AutoGenerateColumns = true;
            ListenerDataGrid.ReadOnly = true;
            ListenerDataGrid.MultiSelect = false;
            ListenerDataGrid.RowHeadersVisible = false;
            ListenerDataGrid.AllowUserToAddRows = false;

            ListenerDataGrid.DataSource = Listeners;
        }

        private Timer Timer { get; set; }
        private BindingList<Listener> Listeners { get; set; }


        private void Form1_Load(object sender, EventArgs e) {
            ApiUrl.Text = "http://localhost:5129/Generator";
        }

        private void OnStartApiCallButtonClicked(object sender, EventArgs e) {
            Timer = new Timer(CallApi, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        }

        private async void CallApi(object state) {
            try {
                var response = await _apiRequestService.CallApi(ApiUrl.Text);

                if (!string.IsNullOrWhiteSpace(response)) {
                    var responseBody = JsonSerializer.Deserialize<GenerateResponseModel>(response);
                    var number = responseBody.Data.Number;
                    //ExecuteOnUIThread(() => ApiRequestStatusLabel.Text = $"The new value is : {number}");

                    var targetListener = Listeners.FirstOrDefault(e => e.Target == number);
                    if (targetListener != null) {
                        targetListener.IncreaseCounter();
                        ExecuteOnUIThread(() => ListenerDataGrid.Refresh());
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }


        private void OnStopApiButtonClicked(object sender, EventArgs e) {
            if (Timer != null)
                Timer.Dispose();
        }

        private void OnRegisterListenerButtonClicked(object sender, EventArgs e) {
            try {
                var index = Listeners.Count + 1;
                if (index > 10) {
                    MessageBox.Show("You are not able to add more listeners");
                    return;
                }

                Listeners.Add(new Listener {
                    Name = $"Listener {index}",
                    Target = index
                });
                ListenerDataGrid.Refresh();
            } catch (Exception ex) {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }

        private void OnUnRegisterListenerButtonClicked(object sender, EventArgs e) {
            try {
                if (ListenerDataGrid.SelectedRows.Count > 0) {
                    var selectedRow = ListenerDataGrid.SelectedRows[0];

                    Listeners.RemoveAt(selectedRow.Index);
                    return;
                }

                if (ListenerDataGrid.SelectedCells.Count > 0) {
                    var selectedCell = ListenerDataGrid.SelectedCells[0];
                    var selectedRow = selectedCell.OwningRow;

                    Listeners.RemoveAt(selectedRow.Index);
                    return;
                }

                MessageBox.Show("You have to select a listener first.");
            } catch (Exception ex) {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }



        private void ExecuteOnUIThread(Action action) {
            BeginInvoke((MethodInvoker)delegate { action?.Invoke(); });
        }
    }
}
