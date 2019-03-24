using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AuroraControlsGallery.Behaviors
{
    public sealed class SelectionChangedCommandCollectionView
    {
        public static readonly BindableProperty SelectionChangedCommandProperty =      
            BindableProperty.CreateAttached(
                "SelectionChangedCommand",
                typeof(ICommand),
                typeof(SelectionChangedCommandCollectionView),
                default(ICommand),
                BindingMode.OneWay,
                null,
                PropertyChanged);

        static void PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CollectionView collectionView)
            {
                collectionView.SelectionChanged -= CollectionViewSelectionChanged;
                collectionView.SelectionChanged += CollectionViewSelectionChanged;
            }
        }

        static void CollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is CollectionView collection && collection.IsEnabled)
            {
                collection.SelectedItem = null;
                var command = GetSelectionChangedCommand(collection);
                if (e.CurrentSelection != null && command != null && command.CanExecute(e.CurrentSelection))
                {
                    command.Execute(e.CurrentSelection.FirstOrDefault());
                }
            }
        }

        public static ICommand GetSelectionChangedCommand(BindableObject bindableObject) => (ICommand)bindableObject.GetValue(SelectionChangedCommandProperty);

        public static void SetSelectionChangedCommand(BindableObject bindableObject, object value) => bindableObject.SetValue(SelectionChangedCommandProperty, value);
    }
}