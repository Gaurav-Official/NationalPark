using Microsoft.AspNetCore.Components.Web;
using NationlParkAPI_2.Models;

namespace NationlParkAPI_2.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        User Authenticate(string username,string password);
        User Register(string username, string password);
    }
}
