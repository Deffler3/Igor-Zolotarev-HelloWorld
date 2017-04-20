using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHello.DIBase;

using Microsoft.Practices.Unity;

namespace MyHello.ApiLib
{
    public class ApiLibDiContainer: MyDiContainerBase
    {
        public override void RegisterComponents(IUnityContainer container)
        {
            container.RegisterType<IHelloAgent, HelloCsvAgent>("HelloCsvAgent");
            container.RegisterType<IHelloAgent, HelloDbAgent>("HelloDbAgent");
            container.RegisterType<IHelloAgent, HelloCmdAgent>("HelloCmdAgent");
        }
    }
}
