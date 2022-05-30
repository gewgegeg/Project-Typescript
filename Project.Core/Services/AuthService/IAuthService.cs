using System.Threading.Tasks;
using Monit.Project.DAL.Entities;

namespace Monit.Project.Core.Services.AuthService
{
    public interface IAuthService
    {
        public Task<Session> OpenSessionAsync(string userName, string hash);
        public Task CloseSessionAsync(string token);
        public Task RegisterNewUserAsync(string userName, string email, string hash);
        public Task<bool> IsSessionOpenAsync(string token);
    }
}
