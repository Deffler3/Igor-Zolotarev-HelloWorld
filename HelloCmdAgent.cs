using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHello.ApiLib
{
    public class HelloCmdAgent:IHelloAgent
    {
        public string SayHello()
        {
            string _rv = "Hi from CMD Agent";
            Console.WriteLine(_rv);
            return _rv;
        }
    }
}
