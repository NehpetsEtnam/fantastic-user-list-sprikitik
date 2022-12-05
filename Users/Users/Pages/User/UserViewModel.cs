using Prism.Navigation;
using Users.DAL.Model.User;

namespace Users.Pages.User
{
    public class UserViewModel : ViewModelBase
    {
        UserModel _user = new UserModel();
        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged(nameof(User));
            }
        }

        public UserViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            if (parameters.ContainsKey(nameof(UserModel))
                && parameters[nameof(UserModel)] is UserModel user)
            {
                User = user;
            }
        }
    }
}
