using hSenidPos.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hSenidPos.Server.Services.UserService
{
    public interface IUserService
    {
        string GetUserId();
        Task<ApplicationUser> GetUserName();
        bool IsAuthenticated();
    }
}
