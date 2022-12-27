using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingExamAPI.Core.Entities;

namespace TestingExamAPI.Core.Interfaces
{
    public interface IUserManager
    {
        List<User> GetAllUsers();
        User GetById(int id);
        User CreateUser(User user);
        User DeleteUser(int id);
        User UpdateUser(User user);
    }
}
