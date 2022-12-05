using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Users.DAL.Model.User;
using Users.DAL.Services.User;

namespace Users.Pages.User
{
    public class UserListViewModel : ViewModelBase
    {
        private IUserService _userService;

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
            IUserService userService)
            : base(navigationService)
        {
            _userService = userService;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.GetNavigationMode() == NavigationMode.New)
                await GetUsers();
        }

        private async Task GetUsers()
        {
            var result = await _userService.GetUsers();
            Users = new ObservableCollection<UserModel>(result);
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
