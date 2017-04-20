using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace MyHello.DIBase
{
    public abstract class MyDiContainerBase
    {
        public void InitializeContainer(IUnityContainer container)
        {
            if (container == null)
            {
                container = new UnityContainer();
            }
            RegisterComponents(container);
            container.RegisterInstance<IUnityContainer>(container);
        }

        public virtual void RegisterComponents(IUnityContainer container)
        { }

    }
}
