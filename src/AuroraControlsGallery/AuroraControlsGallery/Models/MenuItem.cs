using System;
using Xamarin.Forms;

namespace AuroraControlsGallery.Models
{
    public enum MenuItemType
    {
        Home,
        Controls,
        Effects,
        Gauges,
        Loading
    }

    public class MenuItem : BindableObject
    {
        string _title;
        MenuItemType _menuItemType;
        Type _viewModelType;

        public string Title
        {
            get => _title;

            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public MenuItemType MenuItemType
        {
            get => _menuItemType;

            set
            {
                _menuItemType = value;
                OnPropertyChanged();
            }
        }

        public Type ViewModelType
        {
            get => _viewModelType;

            set
            {
                _viewModelType = value;
                OnPropertyChanged();
            }
        }
    }
}