using System;
using Xamarin.Forms;

namespace AuroraControlsGallery.Models
{
    public class ControlItem : BindableObject
    {
        string _title;
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