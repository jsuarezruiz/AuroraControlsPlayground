using Android.App;
using Android.Content.PM;
using Android.OS;

namespace AuroraControlsGallery.Droid
{
    [Activity(
        Label = "AuroraControlsGallery",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.SetFlags(new[] { "CollectionView_Experimental" });
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(false);
            Aurora.ComponentLoader.Init(AppSettings.AndroidKey);
            LoadApplication(new App());
        }
    }
}