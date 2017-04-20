using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

namespace MyHello.DIBase
{
    public class MyDiContainer
    {

        private static object locker = new object();
        private static IUnityContainer container = null;

        public static IUnityContainer Container(MyDiContainerBase uc)
        {
            lock (locker)
            {
                if (container == null)
                {
                    InitializeContainer(uc);
                }
            }
            return container;
        }

        private static void InitializeContainer(MyDiContainerBase uc)
        {
            lock (locker)
            {
                if (container == null)
                {
                    container = new UnityContainer();
                }
                uc.InitializeContainer(container);
            }
        }

        public static void Reset()
        {
            lock (locker)
            {
                container = null;
            }
        }
    }
}
