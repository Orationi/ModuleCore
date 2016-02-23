using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orationi.ModuleCore.Diagnostic.Counters
{
	/// <summary>
	/// Interface for simple counter
	/// </summary>
	interface ISimpleCounter
	{
		/// <summary>
		/// Measurement date 
		/// </summary>
		DateTime TimeMark { get; set; }

		/// <summary>
		/// Name of counter
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Value
		/// </summary>
		string Value { get; set; }

		/// <summary>
		/// Unit
		/// </summary>
		string Unit { get; set; }

		CounterState State { get; set; }

		int RepeatMiliseconds { get; set; }

		/// <summary>
		/// Command for measure
		/// </summary>
		void TakeValue();

		void Start();

		void Stop();

		/// <summary>
		/// Event for counter start
		/// </summary>
		event EventHandler CounterStarted;

		/// <summary>
		/// Event for counter stop
		/// </summary>
		event EventHandler CounterStoped;
	}


}
