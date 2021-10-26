using System;
using System.Text;

namespace SyntaxAnalyzer
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;
			Console.WriteLine("Enter code for analyser:");
			var code = Console.ReadLine();
			var analyser = new SyntaxAnalyzer();
			try
			{
				var result = analyser.Run(code);
				Console.WriteLine(result ? "Okay" : "It is not a while statement");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
