using System.ComponentModel;

namespace DataPatrol.WindowsForm.WindowsFormModels
{
    public class Bindable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
