using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Users.DAL.Model.User;
using Users.DAL.Services.User;
using Users.Essentials;
using Xamarin.Forms;
using NavigationMode = Prism.Navigation.NavigationMode;

namespace Users.Pages.User
{
    public class UserListViewModel : ViewModelBase
    {
        private IUserService _userService;
        private IConnectivity _connectivity;
        private IPageDialogService _dialogService;

        ObservableCollection<UserModel> _users = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChanged(nameof(Users));
            }
        }

        public DelegateCommand<object> OpenUserCommand => new DelegateCommand<object>(OnOpenUser);

        public UserListViewModel(INavigationService navigationService,
            IUserService userService,
            IConnectivity connectivity,
            IPageDialogService dialogService)
            : base(navigationService)
        {
            _userService = userService;
            _connectivity = connectivity;
            _dialogService = dialogService;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.GetNavigationMode() == NavigationMode.New)
                await GetUsers();
        }

        private async Task GetUsers()
        {
            if (_connectivity.IsConnected())
            {
                var result = await _userService.GetUsers();
                Users = new ObservableCollection<UserModel>(result);
            }
            else
            {
                Device.BeginInvokeOnMainThread(DisplayNoInternet);
            }
        }

        private async void DisplayNoInternet()
        {
            await _dialogService.DisplayAlertAsync(
                "No Internet Access",
                "Please check your internet connection and try again!", "Okay");
        }

        private async void OnOpenUser(object obj)
        {
            if (obj is UserModel userModel)
            {
                await NavigationService.NavigateAsync(nameof(UserPage), new NavigationParameters()
                {
                    { nameof(UserModel), userModel }
                });
            }
        }
    }
}
