using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

using System.IO;

namespace MyHello.ApiLib
{
    public class HelloCsvAgent : IHelloAgent
    {
		private string fileOutpuName = "";

		public HelloCsvAgent()
		{
			fileOutpuName = @"C:\test_hello.txt";
		}

		public string SayHello()
        {
			try
			{
				string _rv = "Hi from Csv Agent";
				fileOutpuName = ConfigurationManager.AppSettings["outfilename"];
				if (ConfigurationManager.AppSettings["savehellotofile"] != "false")
				{
					SaveData(_rv);
				}
				else
				{
					_rv = "Skip saving to file";
				}
				return _rv; 
			}
			catch(Exception ex)
			{
				return ex.Message;
			}
        }

		private void SaveData(string _s)
		{
			FileInfo _fInfo;
			StreamWriter _sw;
			_fInfo = new FileInfo(fileOutpuName);
			_sw = new System.IO.StreamWriter(_fInfo.FullName);
			_sw.Write(_s);
			_sw.Flush();
			_sw.Close();
		}
    }
}
