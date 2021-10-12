using System;

namespace LexicalAnalyzer
{
	class Program
	{
		static void Main(string[] args)
		{
			var analyser = new Analyzer();
			var result = analyser.Run(string.Join(Environment.NewLine,
												"do while a == 5",
												"	a = a + 1",
												"	output a"));
			Console.WriteLine(result);
			var lexemes = analyser.Lexemes;
			for (int i = 0; i < lexemes.Count; i++)
			{
				Console.WriteLine($"Id: {i}, Class: {lexemes[i].Class}, Type: {lexemes[i].Type}, Value {lexemes[i].Value}");
			}
		}
	}
}
