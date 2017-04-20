using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MyHello.DIBase;
using MyHello.ApiLib;
using Microsoft.Practices.Unity;

namespace MyHello.Web.api
{
	[RoutePrefix("api")]
	public class MyHelloController : ApiController
    {

		[Route("gethello"), HttpGet]
		public IHttpActionResult gethello()
		{
			try
			{
				string msg = "test";

				IUnityContainer container;
				IHelloAgent cmdAgent;
				container = MyDiContainer.Container(new ApiLibDiContainer());
				cmdAgent = container.Resolve<IHelloAgent>("HelloCmdAgent");
				msg = cmdAgent.SayHello();

				return Ok(msg);
			}
			catch
			{
				return Ok("Api failed");
			}
		}
	}
}
