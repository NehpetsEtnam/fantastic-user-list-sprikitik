using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using Shouldly;
using Users.DAL.Model.User;
using Users.DAL.Services.User;

namespace Users.Tests.DAL.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private IUserService? _service;

        private const string Url = "http://localhost";
        private MockHttpMessageHandler? MockHttp { get; set; }

        [SetUp]
        public void SetUp()
        {
            MockHttp = new MockHttpMessageHandler();

            _service = new UserService();
        }

        [TearDown]
        public void TearDown()
        {
            _service = null;
        }

        [Test]
        public async Task UserCanGetListOfUsers()
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

            MockHttp
                .When(HttpMethod.Get, $"{Url}/erni-ph-mobile-team/c5b401c4fad718da9038669250baff06/raw/7e390e8aa3f7da4c35b65b493fcbfea3da55eac9/test.json")
                .Respond(
                    "application/json",
                    JsonConvert.SerializeObject(mockUsers));

            var result = await _service!.GetUsers();

            var expected = mockUsers.Distinct(UserModel.Comparer).ToList();

            result.SequenceEqual(expected, UserModel.Comparer).ShouldBe(true);
        }
    }
}
