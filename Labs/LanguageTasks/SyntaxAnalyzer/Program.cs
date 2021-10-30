using System;
using System.IO;
using System.Text;

namespace SyntaxAnalyzer
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;
			using var stream = new StreamReader("input.txt");
			var code = stream.ReadToEnd();
			var analyser = new SyntaxAnalyzer();
			try
			{
				var result = analyser.Run(code);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
}
	}
}
