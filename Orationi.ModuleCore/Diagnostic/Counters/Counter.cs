using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Orationi.ModuleCore.Diagnostic.Counters
{
	public class Counter : ISimpleCounter
	{
		public Counter()
		{
			RepeatMiliseconds = 2000;
		}

		private CancellationTokenSource _canceled = new CancellationTokenSource();

		public void Start()
		{
			State = CounterState.Running;
			if (CounterStarted != null)
			{
				CounterStarted(this, null);
			}

			var task = Repeat.Interval(
					TimeSpan.FromMilliseconds(RepeatMiliseconds),
					() => TakeValue(), _canceled.Token);

		}

		public void Stop()
		{
			_canceled.Cancel();
			State = CounterState.Stoped;
			if (CounterStoped != null)
			{
				CounterStoped(this, null);
			}
		}
		public string Name { get; set; }

		public CounterState State
		{
			get
			{
				lock (counterlocker)
				{
					return _state;
				}
			}
			set
			{
				lock (counterlocker)
				{
					_state = value;
				}
			}
		}

		private CounterState _state;


		private object counterlocker = new object();

		public int RepeatMiliseconds
		{ get; set; }

		public DateTime TimeMark { get; set; }


		public string Unit { get; set; }

		public string Value { get; set; }

		public event EventHandler CounterStarted;
		public event EventHandler CounterStoped;

		public virtual void TakeValue()
		{

		}

	}
	public enum CounterState
	{
		Stoped = 0,
		Running = 1
	}
}
