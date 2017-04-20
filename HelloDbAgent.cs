using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHello.ApiLib
{
    public class HelloDbAgent:IHelloAgent
    {
        public string SayHello()
        {
            string _rv = "Hi from DB Agent";
			//TODO something in DB.
            return _rv;
        }
    }
}
