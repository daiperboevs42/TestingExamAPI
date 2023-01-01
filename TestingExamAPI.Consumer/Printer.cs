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
                var result = RequestMaker.GetAllUsers().GetAwaiter().GetResult();
                //var result = RequestMaker.GetSpecificUser(1).GetAwaiter().GetResult();
                //var result = RequestMaker.CreateUser().GetAwaiter().GetResult();
                //var result = RequestMaker.UpdateUser().GetAwaiter().GetResult();
                //var result = RequestMaker.DeleteUser().GetAwaiter().GetResult();

                Console.WriteLine(result);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }
    }
}
