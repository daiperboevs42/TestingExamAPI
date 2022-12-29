using System.Net.Http.Headers;
using TestingExamAPI.Consumer;
using System.Net.Http.Json;
using System.Reflection;

namespace TestingExamAPI.Consumer
{
    class Program
    {

        static void Main(string[] args)
        {
            Printer pront = new Printer();
            new RequestMaker();
            pront.Options();
        }
    }
}