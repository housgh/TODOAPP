using System.Threading.Tasks;
using TODOAPP.Domain.Models;

namespace TODOAPP.Core.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResult> LoginAsync(LoginModel model);
    }
}