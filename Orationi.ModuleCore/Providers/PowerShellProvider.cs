using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Orationi.ModuleCore.Providers
{
	public class PowerShellProvider
	{
		public PSDataCollection<PSObject> OutputCollection { get; protected set; }

		public PSDataCollection<ProgressRecord> ProgressStream => _powerShellInstance.Streams.Progress;

		private readonly PowerShell _powerShellInstance;

		public PowerShellProvider()
		{
			_powerShellInstance = PowerShell.Create();
			OutputCollection = new PSDataCollection<PSObject>();
		}

		public void InvokeScript(string script, Dictionary<string, object> parametersDictionary = null)
		{
			if (parametersDictionary != null)
				_powerShellInstance.AddParameters(parametersDictionary);

			_powerShellInstance.AddScript(script);

			_powerShellInstance.Invoke(OutputCollection);
		}

		public IAsyncResult InvokeScriptAsync(string script, Dictionary<string, object> parametersDictionary = null)
		{
			if (parametersDictionary != null)
				_powerShellInstance.AddParameters(parametersDictionary);

			_powerShellInstance.AddScript(script);

			return _powerShellInstance.BeginInvoke(OutputCollection);
		}
	}
}
