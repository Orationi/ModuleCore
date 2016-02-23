using System;
using System.IO;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orationi.ModuleCore.Providers;

namespace Orationi.ModuleCore.Tests
{
	[TestClass]
	public class PowerShellProviderTests
	{
		[TestMethod]
		public void ExecuteCutomScriptTest()
		{
			PowerShellProvider provider = new PowerShellProvider();
			if (File.Exists("process.txt"))
				File.Delete("process.txt");
			provider.InvokeScript("Get-Process | Out-File process.txt");
			Assert.IsFalse(!File.Exists("process.txt"), "!File.Exists('process.txt')");
		}

		[TestMethod]
		public void ExecuteCutomScriptTestAsync()
		{
			PowerShellProvider provider = new PowerShellProvider();
			if (File.Exists("process.txt"))
				File.Delete("process.txt");
			IAsyncResult result = provider.InvokeScriptAsync("Get-Process | Out-File process.txt");
			while (!result.IsCompleted) { }
			Assert.IsFalse(!File.Exists("process.txt"), "!File.Exists('process.txt')");
		}
	}
}
