using System;
using System.Collections.Generic;

namespace Users.DAL.Model.User
{
    public class UserModel
    {
        public static IEqualityComparer<UserModel> Comparer => new UserModelEqualityComparer();

        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        private sealed class UserModelEqualityComparer : IEqualityComparer<UserModel>
        {
            public bool Equals(UserModel x, UserModel y)
            {
                if (ReferenceEquals(x, y)) { return true; }
                if (ReferenceEquals(x, null)) { return false; }
                if (ReferenceEquals(y, null)) { return false; }
                if (x.GetType() != y.GetType()) { return false; }

                return x.Id == y.Id &&
                       x.Name == y.Name &&
                       x.ImageUrl == y.ImageUrl;
            }

            public int GetHashCode(UserModel obj)
            {
                return HashCode.Combine(obj.Id, obj.Name, obj.ImageUrl);
            }
        }
    }
}

