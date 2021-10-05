using System;

namespace Ssu.Task2.Nda
{
	public static class ConsoleHelper
	{
		public static void Failure(string message)
		{
			Console.WriteLine("FAILURE");
			Console.WriteLine(message);
			Console.WriteLine("__________________________________________");
		}

		public static void Success(string message)
		{
			Console.WriteLine("SUCCESS");
			Console.WriteLine(message);
			Console.WriteLine("__________________________________________");
		}
	}
}
