using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyHello.DIBase;
using MyHello.ApiLib;

using Microsoft.Practices.Unity;

namespace MyHello.cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var container = MyDiContainer.Container(new ApiLibDiContainer());
                IHelloAgent cmdAgent = container.Resolve<IHelloAgent>("HelloCmdAgent");
                cmdAgent.SayHello();
                 Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
