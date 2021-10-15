using System;

namespace LexicalAnalyzer
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter code for analyser:");
			var code = Console.ReadLine();
			var analyser = new Analyzer();
			var result = analyser.Run(string.Join(Environment.NewLine, code));
			//Console.WriteLine(result ? "Okay" : "Errors were occurred");
			var lexemes = analyser.Lexemes;
			Console.WriteLine("---------------------------------");
			Console.WriteLine("Result:");
			for (int i = 0; i < lexemes.Count; i++)
			{
				Console.WriteLine($"Index: {i}, Class: {lexemes[i].Class}, Type: {lexemes[i].Type}, Value {lexemes[i].Value}");
			}
		}
	}
}
