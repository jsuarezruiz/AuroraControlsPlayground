using Aurora.Effects;
using Xamarin.Forms;

namespace AuroraControlsGallery.Views.Effects
{
    public partial class RoundedCornerEffectView : ContentPage
	{
		public RoundedCornerEffectView ()
		{
			InitializeComponent ();

            // Add the rounded corner effect to the view
            CustomGrid.Effects.Add(Effect.Resolve(RoundedCornersEffect.EffectName));

            // Set the corner radius
            RoundedCornersEffect.SetCornerRadius(CustomGrid, 20);
        }
	}
}