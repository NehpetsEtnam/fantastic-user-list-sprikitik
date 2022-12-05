using System.Collections.Generic;
using System.Threading.Tasks;
using Users.DAL.Model.User;
using Users.DAL.Services.User;

namespace Users.Tests.Mocks
{
    public class MockUserService : IUserService
    {
        public Task<List<UserModel>> GetUsers()
        {
            var mockUsers = new List<UserModel>
            {
                new UserModel
                {
                    Id = "1",
                    Name = "John",
                    ImageUrl = "https://www.alchinlong.com/wp-content/uploads/2015/09/sample-profile.png"
                },
                new UserModel
                {
                    Id = "1",
                    Name = "John",
                    ImageUrl = "https://www.alchinlong.com/wp-content/uploads/2015/09/sample-profile.png"
                },
                new UserModel
                {
                    Id = "2",
                    Name = "Chris",
                    ImageUrl = "https://www.alchinlong.com/wp-content/uploads/2015/09/sample-profile.png"
                },
                new UserModel
                {
                    Id = "3",
                    Name = "Mark",
                    ImageUrl = "https://www.alchinlong.com/wp-content/uploads/2015/09/sample-profile.png"
                },
            };

            return Task.FromResult(mockUsers);
        }
    }
}
