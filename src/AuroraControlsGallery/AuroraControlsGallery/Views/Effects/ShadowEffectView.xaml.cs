using Xamarin.Forms;

namespace AuroraControlsGallery.Views.Effects
{
    public partial class ShadowEffectView : ContentPage
	{
		public ShadowEffectView ()
		{
			InitializeComponent ();

            // Add the shadow effect to the control
            CustomButton.Effects.Add(new Aurora.Effects.ShadowEffect());

            // Set the corner radius of the shadow effect and apply it to the control
            Aurora.Effects.ShadowEffect.SetCornerRadius(CustomButton, 6);
        }
	}
}