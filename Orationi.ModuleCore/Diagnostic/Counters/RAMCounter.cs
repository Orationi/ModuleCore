using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orationi.ModuleCore.Diagnostic.Counters
{
	public class RAMCounter : Counter, ISimpleCounter
	{
		public RAMCounter()
		{
			Name = "Available RAM";
			Unit = "MB";
			RepeatMiliseconds = 2000;
		}

		public override void TakeValue()
		{
			PerformanceCounter theMemCounter = new PerformanceCounter("Memory", "Available MBytes");
			this.Value = theMemCounter.NextValue().ToString();
		}
	}
}
