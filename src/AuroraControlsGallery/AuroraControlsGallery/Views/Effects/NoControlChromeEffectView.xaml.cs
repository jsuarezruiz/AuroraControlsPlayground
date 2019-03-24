using Aurora.Effects;
using Xamarin.Forms;

namespace AuroraControlsGallery.Views.Effects
{
    public partial class NoControlChromeEffectView : ContentPage
	{
		public NoControlChromeEffectView ()
		{
			InitializeComponent ();
            NumericEntry.Effects.Add(new NoControlChromeEffect());
        }
	}
}