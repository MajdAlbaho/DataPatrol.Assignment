using DataPatrol.WPF.Base;
using System.Collections.ObjectModel;
using DataPatrol.DataModel.CustomModels;
using System.Linq;

namespace DataPatrol.WPF.MainWindow.ListenerComponent
{
    public partial class ListenerViewModel : BaseViewModel<ListenerView>
    {
    }

    public partial class ListenerViewModel
    {
        public ListenerViewModel() {
            Listeners = new ObservableCollection<ListenerItem>();
        }

        public ObservableCollection<ListenerItem> Listeners { get; set; }
        public ListenerItem SelectedListener { get; set; }

        public void IncreaseCount(int target) {
            var targetListener = Listeners.FirstOrDefault(e => e.Target == target);
            if (targetListener != null)
                targetListener.IncreaseCounter();
        }

        public int GetTotalListeners() {
            return Listeners.Count;
        }

        public void AddListener(Listener listener) {
            Listeners ??= new ObservableCollection<ListenerItem>();

            // We can use AutoMapper here
            Listeners.Add(new ListenerItem {
                Counter = listener.Counter,
                Target = listener.Target,
                Name = listener.Name
            });
        }

        public void RemoveSelectedListener() {
            if (SelectedListener == null)
                return;

            Listeners.Remove(SelectedListener);
        }
    }

}
