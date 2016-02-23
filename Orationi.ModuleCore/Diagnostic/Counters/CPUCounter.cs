using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orationi.ModuleCore.Diagnostic.Counters
{
	public class CPUCounter : Counter, ISimpleCounter
	{
		public CPUCounter()
		{
			Name = "CPU";
			Unit = "%";
			RepeatMiliseconds = 2000;
		}

		public override void TakeValue()
		{
			System.Management.ManagementObjectSearcher man =
						new System.Management.ManagementObjectSearcher("SELECT LoadPercentage  FROM Win32_Processor");
			List<double> results = new List<double>();
						foreach (System.Management.ManagementObject obj in man.Get())
			{
				results.Add(Convert.ToDouble(obj["LoadPercentage"]));
			}
			this.Value = results.Average().ToString();
		}
	}
}
