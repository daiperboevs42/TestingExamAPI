using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingExamAPI.Core.Entities;
using TestingExamAPI.Core.Interfaces;

namespace TestingExamAPI.Core.Services
{
    public class PairingManager : IPairingManager
    {
        private IRepository<User> _userRepository;
        public PairingManager(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> FindAllPairings(User user)
        {
            var pairs = new List<User>();
            //var allUsers = _userRepository.GetAll();
            //foreach (User u in allUsers)
            //{
            //    if(u.Interests == user.Interests && u.IsAvailable)
            //        pairs.Add(u);
            //}
            return pairs;
        }

        public List<User> FindPairings(User user)
        {
            var allPairs = _userRepository.GetAll().Where(u => u.IsAvailable).ToList();
            return allPairs;
        }
    }
}
