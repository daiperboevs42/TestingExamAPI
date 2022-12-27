using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingExamAPI.Core.Entities;

namespace TestingExamAPI.Core.Interfaces
{
    public interface IPairingManager
    {
        List<User> FindPairings(User user);
        List<User> FindAllPairings(User user);
    }
}
