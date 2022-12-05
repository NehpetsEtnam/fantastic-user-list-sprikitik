using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using Users.DAL.Api;
using Users.DAL.Api.User;
using Users.DAL.Model.User;

namespace Users.DAL.Services.User
{
	public class UserService : IUserService
    {
		public UserService()
		{
		}

        public async Task<List<UserModel>> GetUsers()
        {
            var allUser = new List<UserModel>();
            try
            {
                var apiClient = RestService.For<IUserApi>(BaseApi.BaseUrl);
                var result = await apiClient.AllUsers();
                allUser = result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }

            return allUser.Distinct<UserModel>(UserModel.Comparer).ToList();
        }
    }
}

