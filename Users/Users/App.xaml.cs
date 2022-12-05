using Prism;
using Prism.DryIoc;
using Users.Pages.User;
using Users.DAL.Services.User;
using Xamarin.Forms;
using Prism.Ioc;
using Users.Essentials;

namespace Users
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(UserListPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<UserListPage, UserListViewModel>();
            containerRegistry.RegisterForNavigation<UserPage, UserViewModel>();

            containerRegistry.RegisterSingleton<IUserService, UserService>();
            containerRegistry.RegisterSingleton<IConnectivity, Essentials.Connectivity>();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

