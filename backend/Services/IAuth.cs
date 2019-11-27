using System.Threading.Tasks;
using fullstackApp.Controllers;
using fullstackApp.Models;

namespace fullstackApp.Services {
    public interface IAuth 
    {
        bool IsAuthenticated(TokenRequest request, out string token);
        Task<AuthenticationResult> RegisterAsync(string email, string password);

    }
}