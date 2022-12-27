using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingExamAPI.Infrastructure
{
    public interface IDbInitializer
    {
        void Initialize(TestingExamAPIContext context);
    }
}
