using System;
using Prism;
using System.Net.Http;
using System.Net.WebSockets;
using Prism.DryIoc;
using Prism.Events;
using Prism.Navigation;
using Users.Pages.User;
using Users.DAL.Services.User;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Ioc;

namespace Users
{
    public partial class App : PrismApplication
    {
        private static UserService userService = new UserService();

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

            containerRegistry.RegisterInstance<IUserService>(userService);
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

