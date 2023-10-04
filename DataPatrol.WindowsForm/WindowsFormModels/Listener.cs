namespace DataPatrol.WindowsForm.WindowsFormModels
{
    public class Listener : Bindable
    {
        public string Name { get; set; }
        public int Target { get; set; }

        private int _counter;
        public int Counter {
            get => _counter;
            private set {
                _counter = value;
                OnPropertyChanged(nameof(Counter));
            }
        }



        public void IncreaseCounter(int counter = 1) { Counter += counter; }
        public void DecreaseCounter(int counter = 1) { Counter -= counter; }
    }
}
