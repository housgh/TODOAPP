using System.Threading.Tasks;
using TODOAPP.Domain.Entities;
using TODOAPP.Domain.Models;

namespace TODOAPP.Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}