using TDDApi.Models;

namespace TDDApi.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();
    }
}
