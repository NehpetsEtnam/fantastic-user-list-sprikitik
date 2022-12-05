using NUnit.Framework;
using Shouldly;
using Users.Pages.User;
using DryIoc;
using Prism.Ioc;
using System.Linq;
using System.Collections.ObjectModel;
using Users.DAL.Model.User;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Users.Tests.Pages
{
    [TestFixture]
    public class UserPageTests : BaseTest
    {
        /// <summary>
        /// Navigating to the User Page from the 
        /// User List Page by clicking item on the list
        /// </summary>
        [Test]
        public async Task NavigatingToUserPageTest()
        {
            // Is the app running
            App.ShouldNotBeNull();

            // Am I in the User list page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(UserListViewModel));

            var vm = App.Container.Resolve<UserListViewModel>();

            var sampleUser = new UserModel
            {
                Id = "1",
                Name = "John",
                ImageUrl = "https://www.alchinlong.com/wp-content/uploads/2015/09/sample-profile.png"
            };

            vm.Users = new ObservableCollection<UserModel>()
            {
                sampleUser
            };

            // Navigating to User page
            vm.OpenUserCommand.Execute(vm.Users.FirstOrDefault());

            // Am I in the User page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(UserViewModel));

            var userVm = App.Container.Resolve<UserViewModel>();

            userVm.User = sampleUser;

            userVm.User.Id.ShouldBe("1");
            userVm.User.Name.ShouldBe("John");
            userVm.User.ImageUrl.ShouldBe("https://www.alchinlong.com/wp-content/uploads/2015/09/sample-profile.png");

            // Performing UI backward navigation
            await((NavigationPage)App.MainPage).Navigation.PopAsync();

            // Am I in the User list page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(UserListViewModel));
        }
    }
}
