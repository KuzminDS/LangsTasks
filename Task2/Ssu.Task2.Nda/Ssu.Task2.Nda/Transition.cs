using System;

namespace Ssu.Task2.Nda
{
	public class Transition
	{
		public string StartState { get; set; }
		public string Symbol { get; set; }
		public string EndState { get; set; }

		public override string ToString()
		{
			return $"{Symbol} => ({StartState} -> {EndState})";
		}
	}
}
