using Xamarin.Forms;

namespace AuroraControlsGallery.Views.Loading
{
    public partial class LoadingView : ContentPage
	{
		public LoadingView ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Loading.StartAnimating(16, 750);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Loading.StopAnimating();
        }
    }
}