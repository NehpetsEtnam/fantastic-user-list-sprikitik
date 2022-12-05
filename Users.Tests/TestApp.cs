using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Prism.DryIoc;
using Users.DAL.Services.User;
using Users.Pages.User;
using Users.Essentials;
using Users.Tests.Mocks;

namespace Users.Tests
{
    public class TestApp : PrismApplication
    {
        public TestApp() : this(null) { }

        public TestApp(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(UserListPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<UserListPage, UserListViewModel>();
            containerRegistry.RegisterForNavigation<UserPage, UserViewModel>();

            containerRegistry.RegisterSingleton<IUserService, MockUserService>();
            containerRegistry.RegisterSingleton<IConnectivity, MockConnectivity>();
        }
    }
}