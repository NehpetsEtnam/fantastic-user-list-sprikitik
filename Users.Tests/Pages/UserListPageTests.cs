using NUnit.Framework;
using Shouldly;
using Users.Pages.User;
using DryIoc;
using Prism.Ioc;
using System.Linq;
using System.Collections.ObjectModel;
using Users.DAL.Model.User;

namespace Users.Tests.Pages
{
    [TestFixture]
    public class UserListPageTests : BaseTest
    {
        /// <summary>
        /// Launching the app for the  first
        /// time and navigating in to User List page
        /// </summary>
        [Test]
        public void AppLaunchingFirstTimeTest()
        {
            // Is the app running
            App.ShouldNotBeNull();

            // Am I in the User list page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(UserListViewModel));

            // List should be empty
            App.Container.Resolve<UserListViewModel>().Users.Count.ShouldBe(0);
        }

        /// <summary>
        /// Navigating to the User Page from the 
        /// User List Page by clicking item on the list
        /// </summary>
        [Test]
        public void NavigatingToUserPageTest()
        {
            // Is the app running
            App.ShouldNotBeNull();

            // Am I in the User list page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(UserListViewModel));

            var vm = App.Container.Resolve<UserListViewModel>();

            vm.Users = new ObservableCollection<UserModel>()
            {
                new UserModel
                {
                    Id = "1",
                    Name = "John",
                    ImageUrl = "https://www.alchinlong.com/wp-content/uploads/2015/09/sample-profile.png"
                }
            };

            // Navigating to User page
            vm.OpenUserCommand.Execute(vm.Users.FirstOrDefault());

            // Am I in the User page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(UserViewModel));
        }
    }
}
