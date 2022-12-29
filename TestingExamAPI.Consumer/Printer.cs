using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingExamAPI.Consumer
{
    public class Printer
    {
        public async void Options()
        {
            Console.WriteLine("what you want?");

            try
            {
                RequestMaker.GetAllUsers().GetAwaiter().GetResult();
                //RequestMaker.GetSpecificUser().GetAwaiter().GetResult();
                //RequestMaker.CreateUser().GetAwaiter().GetResult();
                //RequestMaker.UpdateUser().GetAwaiter().GetResult();
                //RequestMaker.DeleteUser().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }
    }
}
