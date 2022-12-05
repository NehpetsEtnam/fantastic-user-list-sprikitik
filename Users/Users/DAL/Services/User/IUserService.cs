using System.Collections.Generic;
using System.Threading.Tasks;
using Users.DAL.Model.User;

namespace Users.DAL.Services.User
{
    public interface IUserService
	{
        Task<List<UserModel>> GetUsers();
    }
}

