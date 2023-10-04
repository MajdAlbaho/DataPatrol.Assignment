using System.Reflection;
using log4net;

namespace DataPatrol.WPF.Base
{
    public class ErrorHandlerBase : Bindable
    {
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public void LogError(string message) {
            Log.Error(message);
        }
    }
}
