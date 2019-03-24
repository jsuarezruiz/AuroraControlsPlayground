using AuroraControlsGallery.Services.Navigation;
using AuroraControlsGallery.ViewModels.Controls;
using AuroraControlsGallery.ViewModels.Effects;
using AuroraControlsGallery.ViewModels.Gauges;
using AuroraControlsGallery.ViewModels.Loading;
using Autofac;
using System;

namespace AuroraControlsGallery.ViewModels.Base
{
    public class Locator
    {
        IContainer container;
        ContainerBuilder containerBuilder;

        public static Locator Instance { get; } = new Locator();

        public Locator()
        {
            containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<NavigationService>().As<INavigationService>();

            containerBuilder.RegisterType<ControlsViewModel>();
            containerBuilder.RegisterType<CalendarViewModel>();
            containerBuilder.RegisterType<CheckBoxViewModel>();
            containerBuilder.RegisterType<ConfettiViewModel>();
            containerBuilder.RegisterType<CupertinoButtonViewModel>();
            containerBuilder.RegisterType<CupertinoToggleSwitchViewModel>();
            containerBuilder.RegisterType<FlatButtonViewModel>();
            containerBuilder.RegisterType<FloatLabelDatePickerViewModel>();
            containerBuilder.RegisterType<FloatLabelEditorViewModel>();
            containerBuilder.RegisterType<FloatLabelNumericEntryControlViewModel>();
            containerBuilder.RegisterType<GradientPillButtonViewModel>();
            containerBuilder.RegisterType<ImageViewModel>();
            containerBuilder.RegisterType<MaterialToggleSwitchViewModel>();
            containerBuilder.RegisterType<NotificationBadgeViewModel>();
            containerBuilder.RegisterType<NumericBumperControlViewModel>();
            containerBuilder.RegisterType<SegmentedControlViewModel>();
            containerBuilder.RegisterType<SliderViewModel>();
            containerBuilder.RegisterType<StepIndicatorViewModel>();
            containerBuilder.RegisterType<TileViewModel>();
            containerBuilder.RegisterType<HomeViewModel>();
            containerBuilder.RegisterType<MenuViewModel>();
            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<EffectsViewModel>();
            containerBuilder.RegisterType<NoControlChromeEffectViewModel>();
            containerBuilder.RegisterType<RoundedCornerEffectViewModel>();
            containerBuilder.RegisterType<ShadowEffectViewModel>();
            containerBuilder.RegisterType<CircularGaugeViewModel>();
            containerBuilder.RegisterType<LoadingViewModel>();
        }

        public T Resolve<T>() => container.Resolve<T>();

        public object Resolve(Type type) => container.Resolve(type);

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface => containerBuilder.RegisterType<TImplementation>().As<TInterface>();

        public void Register<T>() where T : class => containerBuilder.RegisterType<T>();

        public void Build() => container = containerBuilder.Build();
    }
}