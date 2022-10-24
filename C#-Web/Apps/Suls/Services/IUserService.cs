using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public interface IUserService
    {
        void CreateUser (string username, string email, string password);

        string GetUserId (string username, string password);

        bool IsUserNameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
