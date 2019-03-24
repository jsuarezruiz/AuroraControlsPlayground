using AuroraControlsGallery.Models;
using AuroraControlsGallery.ViewModels.Base;
using AuroraControlsGallery.ViewModels.Controls;
using AuroraControlsGallery.ViewModels.Effects;
using AuroraControlsGallery.ViewModels.Gauges;
using AuroraControlsGallery.ViewModels.Loading;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AuroraControlsGallery.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<Models.MenuItem> _menuItems;

        public MenuViewModel()
        {
            MenuItems = new ObservableCollection<Models.MenuItem>();
      
            LoadMenuItems();
        }

        public ObservableCollection<Models.MenuItem> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        public ICommand MenuItemSelectedCommand => new Command<Models.MenuItem>(OnSelectMenuItem);

        private void LoadMenuItems()
        {
            MenuItems.Add(new Models.MenuItem
            {
                Title = "Home",
                MenuItemType = MenuItemType.Home,
                ViewModelType = typeof(MainViewModel)
            });

            MenuItems.Add(new Models.MenuItem
            {
                Title = "Controls",
                MenuItemType = MenuItemType.Controls,
                ViewModelType = typeof(ControlsViewModel)
            });

            MenuItems.Add(new Models.MenuItem
            {
                Title = "Effects",
                MenuItemType = MenuItemType.Effects,
                ViewModelType = typeof(EffectsViewModel)
            });

            MenuItems.Add(new Models.MenuItem
            {
                Title = "Gauges",
                MenuItemType = MenuItemType.Gauges,
                ViewModelType = typeof(CircularGaugeViewModel)
            });

            MenuItems.Add(new Models.MenuItem
            {
                Title = "Loading",
                MenuItemType = MenuItemType.Loading,
                ViewModelType = typeof(LoadingViewModel)
            });
        }

        void OnSelectMenuItem(Models.MenuItem item)
        {
            if (item.ViewModelType != null)
            {
                 NavigationService.NavigateToAsync(item.ViewModelType, item);
            }
        }
    }
}