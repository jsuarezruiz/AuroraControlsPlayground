using AuroraControlsGallery.ViewModels.Base;
using System.Threading.Tasks;

namespace AuroraControlsGallery.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        MenuViewModel _menuViewModel;

        public MainViewModel(MenuViewModel menuViewModel)
        {
            _menuViewModel = menuViewModel;
        }

        public MenuViewModel MenuViewModel
        {
            get => _menuViewModel;

            set
            {
                _menuViewModel = value;
                OnPropertyChanged();
            }
        }

        public override Task InitializeAsync(object navigationData) => Task.WhenAll
                (
                    _menuViewModel.InitializeAsync(navigationData),
                    NavigationService.NavigateToAsync<HomeViewModel>()
                );
    }
}