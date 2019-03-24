using AuroraControlsGallery.ViewModels;
using AuroraControlsGallery.ViewModels.Base;
using AuroraControlsGallery.ViewModels.Controls;
using AuroraControlsGallery.ViewModels.Effects;
using AuroraControlsGallery.ViewModels.Gauges;
using AuroraControlsGallery.ViewModels.Loading;
using AuroraControlsGallery.Views;
using AuroraControlsGallery.Views.Controls;
using AuroraControlsGallery.Views.Effects;
using AuroraControlsGallery.Views.Gauges;
using AuroraControlsGallery.Views.Loading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuroraControlsGallery.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> mappings;

        protected Application CurrentApplication => Application.Current;

        public NavigationService()
        {
            mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public async Task InitializeAsync()
        {
            await NavigateToAsync<MainViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase => InternalNavigateToAsync(typeof(TViewModel), null);

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase => InternalNavigateToAsync(typeof(TViewModel), parameter);

        public Task NavigateToAsync(Type viewModelType) => InternalNavigateToAsync(viewModelType, null);

        public Task NavigateToAsync(Type viewModelType, object parameter) => InternalNavigateToAsync(viewModelType, parameter);

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage is MainView)
            {
                var mainPage = CurrentApplication.MainPage as MainView;
                await mainPage.Detail.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            if (CurrentApplication.MainPage is MainView mainPage)
            {
                mainPage.Detail.Navigation.RemovePage(
                    mainPage.Detail.Navigation.NavigationStack[mainPage.Detail.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            var page = CreateAndBindPage(viewModelType, parameter);

            if (page is MainView)
            {
                CurrentApplication.MainPage = page;
            }
            else if (CurrentApplication.MainPage is MainView)
            {
                var mainPage = CurrentApplication.MainPage as MainView;

                if (mainPage.Detail is CustomNavigationPage navigationPage)
                {
                    var currentPage = navigationPage.CurrentPage;

                    if (currentPage.GetType() != page.GetType())
                    {
                        await navigationPage.PushAsync(page);
                    }
                }
                else
                {
                    navigationPage = new CustomNavigationPage(page);
                    mainPage.Detail = navigationPage;
                }

                mainPage.IsPresented = false;
            }
            else
            {
                if (CurrentApplication.MainPage is CustomNavigationPage navigationPage)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    CurrentApplication.MainPage = new CustomNavigationPage(page);
                }
            }

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            var pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            var page = Activator.CreateInstance(pageType) as Page;
            var viewModel = Locator.Instance.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }

        void CreatePageViewModelMappings()
        {
            mappings.Add(typeof(ControlsViewModel), typeof(ControlsView));
            mappings.Add(typeof(CalendarViewModel), typeof(CalendarView));
            mappings.Add(typeof(CheckBoxViewModel), typeof(CheckBoxView));
            mappings.Add(typeof(ConfettiViewModel), typeof(ConfettiControlView));
            mappings.Add(typeof(CupertinoButtonViewModel), typeof(CupertinoButtonView));
            mappings.Add(typeof(CupertinoToggleSwitchViewModel), typeof(CupertinoToggleSwitchView));
            mappings.Add(typeof(FlatButtonViewModel), typeof(FlatButtonView));
            mappings.Add(typeof(FloatLabelDatePickerViewModel), typeof(FloatLabelDatePickerView));
            mappings.Add(typeof(FloatLabelEditorViewModel), typeof(FloatLabelEditorView));
            mappings.Add(typeof(FloatLabelNumericEntryControlViewModel), typeof(FloatLabelNumericEntryControlView));
            mappings.Add(typeof(GradientPillButtonViewModel), typeof(GradientPillButtonView));
            mappings.Add(typeof(ImageViewModel), typeof(ImageControlView));
            mappings.Add(typeof(MaterialToggleSwitchViewModel), typeof(MaterialToggleSwitchView));
            mappings.Add(typeof(NotificationBadgeViewModel), typeof(NotificationBadgeView));
            mappings.Add(typeof(NumericBumperControlViewModel), typeof(NumericBumperControlView));
            mappings.Add(typeof(SegmentedControlViewModel), typeof(SegmentedControlView));
            mappings.Add(typeof(SliderViewModel), typeof(SliderView));
            mappings.Add(typeof(StepIndicatorViewModel), typeof(StepIndicatorView));
            mappings.Add(typeof(TileViewModel), typeof(TileView));
            mappings.Add(typeof(HomeViewModel), typeof(HomeView));
            mappings.Add(typeof(MainViewModel), typeof(MainView));
            mappings.Add(typeof(MenuViewModel), typeof(MenuView));
            mappings.Add(typeof(EffectsViewModel), typeof(EffectsView));
            mappings.Add(typeof(NoControlChromeEffectViewModel), typeof(NoControlChromeEffectView));
            mappings.Add(typeof(RoundedCornerEffectViewModel), typeof(RoundedCornerEffectView));
            mappings.Add(typeof(ShadowEffectViewModel), typeof(ShadowEffectView));
            mappings.Add(typeof(CircularGaugeViewModel), typeof(CircularGaugeView));
            mappings.Add(typeof(LoadingViewModel), typeof(LoadingView));
        }
    }
}