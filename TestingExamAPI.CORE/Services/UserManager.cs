using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingExamAPI.Core.Entities;
using TestingExamAPI.Core.Interfaces;

namespace TestingExamAPI.Core.Services
{
    public class UserManager : IUserManager
    {
        private IRepository<User> _userRepository;
        public UserManager(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(User user)
        {
            return _userRepository.Create(user);

        }

        public User DeleteUser(int id)
        {
            var userToDelete = _userRepository.Get(id);
            if (userToDelete != null)
                return _userRepository.Delete(id);
            else
                throw new InvalidDataException("No user with given id");
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.Get(id);
        }

        public User UpdateUser(User user)
        {
            var userToUpdate = _userRepository.Get(user.Id);
            if (userToUpdate != null)
                return _userRepository.Update(user);
            else
                throw new InvalidDataException("No user with given id");
        }
    }
}
