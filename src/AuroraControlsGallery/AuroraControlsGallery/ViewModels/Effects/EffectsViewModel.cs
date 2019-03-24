using AuroraControlsGallery.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AuroraControlsGallery.ViewModels.Effects
{
    public class EffectsViewModel : ViewModelBase
    {
        private ObservableCollection<Models.EffectItem> _effectItems;

        public EffectsViewModel()
        {
            Effects = new ObservableCollection<Models.EffectItem>();

            LoadEffects();
        }

        public ObservableCollection<Models.EffectItem> Effects
        {
            get => _effectItems;
            set
            {
                _effectItems = value;
                OnPropertyChanged();
            }
        }

        public ICommand EffectSelectedCommand => new Command<Models.EffectItem>(OnSelectEffect);

        private void LoadEffects()
        {
            Effects.Add(new Models.EffectItem
            {
                Title = "NoControlChromeEffect",
                ViewModelType = typeof(NoControlChromeEffectViewModel)
            });

            Effects.Add(new Models.EffectItem
            {
                Title = "RoundedCornerEffect",
                ViewModelType = typeof(RoundedCornerEffectViewModel)
            });

            Effects.Add(new Models.EffectItem
            {
                Title = "ShadowEffect",
                ViewModelType = typeof(ShadowEffectViewModel)
            });
        }

        void OnSelectEffect(Models.EffectItem item)
        {
            if (item != null && item.ViewModelType != null)
            {
                NavigationService.NavigateToAsync(item.ViewModelType, item);
            }
        }
    }
}