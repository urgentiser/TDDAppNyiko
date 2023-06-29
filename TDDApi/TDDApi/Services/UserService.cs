using TDDApi.Models;

namespace TDDApi.Services
{
    public class UserService: IUserService
    {
        private readonly HttpClient httpClient;
        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var usersResponse = await httpClient.GetAsync("htttps://nyiko.com");
            if(usersResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<User>();
            }
           var responseContent = usersResponse.Content;
            var allUsers = await responseContent.ReadFromJsonAsync<List<User>>(); 
            
            return allUsers.ToList();
        }
    }
}
