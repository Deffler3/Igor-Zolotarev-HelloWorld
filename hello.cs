using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;

using System.Net;
using System.Text;
using System.Web.Http;

using MyHello.DIBase;
using MyHello.ApiLib;
using Microsoft.Practices.Unity;
using MyHello.Web.api;
using Xunit;

namespace MyHello.xUnit
{
    [Trait("Test","Hello")]
    public class hello : IDisposable
    {

        IUnityContainer container;
        IHelloAgent cmdAgent;
        IHelloAgent dbAgent;
        IHelloAgent csvAgent;

        public hello()
        {
            try
            {
                container = MyDiContainer.Container(new ApiLibDiContainer());
                cmdAgent = container.Resolve<IHelloAgent>("HelloCmdAgent");
                dbAgent = container.Resolve<IHelloAgent>("HelloDbAgent");
                csvAgent = container.Resolve<IHelloAgent>("HelloCsvAgent");
            }
            catch(Exception ex)
            {
                string _s = ex.Message;
            }
        }

        [Trait("Test", "Hello")]
        public void Dispose()
        {
        }

        [Fact]
        public void testCmd()
        {
            string _reply=cmdAgent.SayHello();
			Assert.Equal("Hi from CMD Agent", _reply);
		}

		[Fact]
		public void testDb()
		{
			string _reply = dbAgent.SayHello();
			Assert.Equal("Hi from CMD Agent", _reply);
		}


		[Fact]
		public void testCsv()
		{
			string _reply = csvAgent.SayHello();
			Assert.Equal("Hi from Csv Agent", _reply);
		}


		[Fact]
		public void testWeb()
		{
			var contriller = new MyHelloController();
			var rs = ((System.Web.Http.Results.OkNegotiatedContentResult<string>)contriller.gethello()).Content;
			

			Assert.Same("Hi from CMD Agent", rs);
		}
	}
}
