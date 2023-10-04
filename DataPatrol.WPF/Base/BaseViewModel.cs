using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using DataPatrol.WPF.Base.Interfaces;

namespace DataPatrol.WPF.Base
{
    public class BaseAsyncViewModel : ErrorHandlerBase
    {
        public bool IsBusy { get; set; }
        public string BusyStatus { get; set; }

        public async void BusyExecute(Func<Task> action, string busyStatus = "Loading ...") {
            if (IsBusy)
                return;

            try {
                BusyStatus = busyStatus;
                IsBusy = true;
                await action();
                IsBusy = false;
            } catch (Exception ex) {
                LogError(ex.GetBaseException().Message);
            } finally {
                IsBusy = false;
            }
        }
    }

    public class BaseViewModel<TView> : BaseAsyncViewModel, IPresentable
        where TView : new()
    {
        protected TView View;
        public UIElement GetView() {
            if (View == null) {
                View = new TView();
                if (View is FrameworkElement element)
                    element.DataContext = this;
            }
            return View as UIElement;
        }

        protected bool IsDesignMode() {
            return DesignerProperties.GetIsInDesignMode(new DependencyObject());
        }
    }
}
