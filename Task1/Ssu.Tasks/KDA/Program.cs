using System;

namespace KDA
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter file name: ");
			string path = Console.ReadLine();
			Console.WriteLine("Enter input sequence: ");
			string input = Console.ReadLine();
			Console.WriteLine();

			var stateMachine = new StateMachine(path);
			var result = stateMachine.Run(input.ToCharArray(), out var logs);

			foreach (var log in logs)
			{
				Console.WriteLine(log);
			}
			Console.WriteLine();
			Console.WriteLine($"Result: {result}");
		}
	}
}
