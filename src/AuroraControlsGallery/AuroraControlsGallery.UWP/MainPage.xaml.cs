namespace AuroraControlsGallery.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Aurora.ComponentLoader.Init(AppSettings.UWPKey);
            LoadApplication(new AuroraControlsGallery.App());
        }
    }
}
