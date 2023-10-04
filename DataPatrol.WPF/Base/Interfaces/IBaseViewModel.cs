using System.Threading.Tasks;

namespace DataPatrol.WPF.Base.Interfaces
{
    public interface IViewModel : IPresentable
    {
        bool Initialized { get; set; }
    }

    public interface IBaseViewModel : IViewModel
    {
        Task Initialize();
    }
}
