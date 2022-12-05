using System;
using NUnit.Framework;
using Shouldly;
using Users.DAL.Model.User;

namespace Users.Tests.DAL.Model
{
    [TestFixture]
    public class UserModelEqualityTests
    {
        private class UserModelSubClass : UserModel { }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Equals_AllFieldsMatch_ReturnsTrue()
        {
            var user1 = CreateMockUserModel();
            var user2 = CreateMockUserModel();

            UserModel.Comparer.Equals(user1, user2).ShouldBeTrue();
        }

        [Test]
        public void Equals_NoIdMatch_ReturnsFalse()
        {
            var user1 = CreateMockUserModel();
            var user2 = CreateMockUserModel();

            user1.Id = "2";

            UserModel.Comparer.Equals(user1, user2).ShouldBeFalse();
        }

        [Test]
        public void Equals_NoNameMatch_ReturnsFalse()
        {
            var user1 = CreateMockUserModel();
            var user2 = CreateMockUserModel();

            user1.Name = "Mark";

            UserModel.Comparer.Equals(user1, user2).ShouldBeFalse();
        }

        [Test]
        public void Equals_NoImageUrlMatch_ReturnsFalse()
        {
            var user1 = CreateMockUserModel();
            var user2 = CreateMockUserModel();

            user1.ImageUrl = "https://www.alchinlong.com/wp-content/uploads/2015/09/sample.png";

            UserModel.Comparer.Equals(user1, user2).ShouldBeFalse();
        }

        [Test]
        public void Equals_XIsNull_ReturnsFalse()
        {
            UserModel.Comparer.Equals(null, new UserModel()).ShouldBeFalse();
        }

        [Test]
        public void Equals_YIsNull_ReturnsFalse()
        {
            UserModel.Comparer.Equals(new UserModel(), null).ShouldBeFalse();
        }

        [Test]
        public void Equals_BothAreNull_ReturnsTrue()
        {
            UserModel.Comparer.Equals(null, null).ShouldBeTrue();
        }

        [Test]
        public void Equals_SameReference_ReturnsTrue()
        {
            var user1 = CreateMockUserModel();
            var user2 = user1;

            UserModel.Comparer.Equals(user1, user2).ShouldBeTrue();
        }

        [Test]
        public void Equals_DifferentType_ReturnsFalse()
        {
            var user1 = new UserModel();
            var user2 = new UserModelSubClass();

            UserModel.Comparer.Equals(user1, user2).ShouldBeFalse();
        }

        [Test]
        public void GetHashCode_ReturnsExpectedValue()
        {
            var user = CreateMockUserModel();

            var expected = HashCode.Combine(
                user.Id,
                user.Name,
                user.ImageUrl);

            UserModel.Comparer.GetHashCode(user).ShouldBe(expected);
        }

        private UserModel CreateMockUserModel()
        {
            return new UserModel
            {
                Id = "1",
                Name = "John",
                ImageUrl = "https://www.alchinlong.com/wp-content/uploads/2015/09/sample-profile.png"
            };
        }
    }
}
