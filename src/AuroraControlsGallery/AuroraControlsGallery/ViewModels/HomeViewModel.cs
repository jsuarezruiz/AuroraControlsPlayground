using AuroraControlsGallery.ViewModels.Base;
using AuroraControlsGallery.ViewModels.Controls;
using AuroraControlsGallery.ViewModels.Effects;
using AuroraControlsGallery.ViewModels.Gauges;
using AuroraControlsGallery.ViewModels.Loading;
using System.Windows.Input;
using Xamarin.Forms;

namespace AuroraControlsGallery.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand ControlsCommand => new Command(OnControls);
        public ICommand EffectsCommand => new Command(OnEffects);
        public ICommand GaugesCommand => new Command(OnGauges);
        public ICommand LoadingCommand => new Command(OnLoading);

        void OnControls()
        {
            NavigationService.NavigateToAsync<ControlsViewModel>();
        }

        void OnEffects()
        {
            NavigationService.NavigateToAsync<EffectsViewModel>();
        }

        void OnGauges()
        {
            NavigationService.NavigateToAsync<CircularGaugeViewModel>();
        }

        void OnLoading()
        {
            NavigationService.NavigateToAsync<LoadingViewModel>();
        }
    }
}