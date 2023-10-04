using DataPatrol.WPF.Base;

namespace DataPatrol.WPF.MainWindow.ListenerComponent
{
    public class ListenerItem : Bindable
    {
        public string Name { get; set; }
        public int Target { get; set; }

        private int _counter;

        public int Counter {
            get => _counter;
            set { _counter = value; OnPropertyChanged(); }
        }



        public void IncreaseCounter(int counter = 1) { Counter += counter; }
        public void DecreaseCounter(int counter = 1) { Counter -= counter; }
    }
}
