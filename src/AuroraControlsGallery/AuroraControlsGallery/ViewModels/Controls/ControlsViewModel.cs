using AuroraControlsGallery.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AuroraControlsGallery.ViewModels.Controls
{
    public class ControlsViewModel : ViewModelBase
    {
        private ObservableCollection<Models.ControlItem> _controlItems;

        public ControlsViewModel()
        {
            Controls = new ObservableCollection<Models.ControlItem>();

            LoadControls();
        }

        public ObservableCollection<Models.ControlItem> Controls
        {
            get => _controlItems;
            set
            {
                _controlItems = value;
                OnPropertyChanged();
            }
        }

        public ICommand ControlSelectedCommand => new Command<Models.ControlItem>(OnSelectControl);

        private void LoadControls()
        {
            Controls.Add(new Models.ControlItem
            {
                Title = "Calendar",
                ViewModelType = typeof(CalendarViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "CheckBox",
                ViewModelType = typeof(CheckBoxViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "Confetti",
                ViewModelType = typeof(ConfettiViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "CupertinoButton",
                ViewModelType = typeof(CupertinoButtonViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "CupertinoToggleSwitch",
                ViewModelType = typeof(CupertinoToggleSwitchViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "FlatButton",
                ViewModelType = typeof(FlatButtonViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "FloatLabelDatePicker",
                ViewModelType = typeof(FloatLabelDatePickerViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "FloatLabelEditor",
                ViewModelType = typeof(FloatLabelEditorViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "FloatLabelNumericEntryControl",
                ViewModelType = typeof(FloatLabelNumericEntryControlViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "GradientPillButton",
                ViewModelType = typeof(GradientPillButtonViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "ImageView",
                ViewModelType = typeof(ImageViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "MaterialToggleSwitch",
                ViewModelType = typeof(MaterialToggleSwitchViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "NotificationBadge",
                ViewModelType = typeof(NotificationBadgeViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "NumericBumperControl",
                ViewModelType = typeof(NumericBumperControlViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "SegmentedControl",
                ViewModelType = typeof(SegmentedControlViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "Slider",
                ViewModelType = typeof(SliderViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "StepIndicator",
                ViewModelType = typeof(StepIndicatorViewModel)
            });

            Controls.Add(new Models.ControlItem
            {
                Title = "Tile",
                ViewModelType = typeof(TileViewModel)
            });
        }

        void OnSelectControl(Models.ControlItem item)
        {
            if (item != null && item.ViewModelType != null)
            {
                NavigationService.NavigateToAsync(item.ViewModelType, item);
            }
        }
    }
}