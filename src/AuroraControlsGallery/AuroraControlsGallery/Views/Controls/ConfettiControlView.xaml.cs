using Xamarin.Forms;

namespace AuroraControlsGallery.Views.Controls
{
    public partial class ConfettiControlView : ContentPage
	{
		public ConfettiControlView()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Confetti.Start();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Confetti.Stop();
        }
    }
}