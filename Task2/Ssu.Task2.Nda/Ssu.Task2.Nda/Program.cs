using System;

namespace Ssu.Task2.Nda
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter file with automaton:");
			var file = Console.ReadLine();
			var automaton = NDA.CreateMachineByJson(file);

			automaton.ValidateWord("");
			automaton.ValidateWord("1");
			automaton.ValidateWord("0");
			automaton.ValidateWord("01");
			automaton.ValidateWord("000001");
			automaton.ValidateWord("111110");
			automaton.ValidateWord("10");
			automaton.ValidateWord("11");
			automaton.ValidateWord("111111");
			automaton.ValidateWord("000000");
		}
	}
}
