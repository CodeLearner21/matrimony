using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Dtos.GatewayResponses.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Core.Interfaces.Gateways
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(User user, string password);
        Task<User> FindByName(string userName);
        Task<User> FindByEmail(string email);
        Task<bool> CheckPassword(User user, string password);
    }
}
