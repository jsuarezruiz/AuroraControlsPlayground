using AuroraControlsGallery.Services.Navigation;
using System.Threading.Tasks;

namespace AuroraControlsGallery.ViewModels.Base
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
        protected readonly INavigationService NavigationService;

        public ViewModelBase()
        {
            NavigationService = Locator.Instance.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);
    }
}