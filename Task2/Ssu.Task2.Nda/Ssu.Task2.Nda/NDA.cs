using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ssu.Task2.Nda
{
	public class NDA
	{
		private List<string> Alphabet { get; set; }
		private List<string> States { get; set; }
		private List<Transition> Transitions { get; set; }
		private string BeginState { get; set; }
		private List<string> FinalStates { get; set; }

		private NDA()
		{
		}

		public static NDA CreateMachineByJson(string jsonFilePath)
		{
			using var reader = new StreamReader(jsonFilePath);
			var stateMachine = JsonConvert.DeserializeObject<StateMachineForConverting>(reader.ReadToEnd());
			var nda = new NDA();
			nda.Alphabet = stateMachine.Alphabet;
			nda.States = stateMachine.States; 
			nda.BeginState = stateMachine.BeginState;
			nda.FinalStates = stateMachine.FinalStates;
			nda.Transitions = stateMachine.Transitions;

			if (nda.Alphabet.Any(a => a.Length > 1))
			{
				throw new Exception("Invalid automaton");
			}
			if (!nda.Transitions.All(t => nda.ValidateTransition(t)))
			{
				throw new Exception("Invalid automaton");
			}

			return nda;
		}

		public void ValidateWord(string input)
		{
			Console.WriteLine($"Trying to accept: {input}");

			if (ValidateWord(BeginState, input, new List<string>()))
			{
				return;
			}
			ConsoleHelper.Failure($"Could not accept the input: {input}");
		}

		private bool ValidateWord(string currentState, string input, List<string> steps)
		{
			if (FinalStates.Contains(currentState))
			{
				if (input == string.Empty)
				{
					var stepsMessage = string.Join(Environment.NewLine, steps);

					ConsoleHelper.Success("Successfully accepted the input " + input +
										  " in the final state " + currentState +
										  " with steps:\n" + stepsMessage);
					return true; 
				}
				else
				{
					return false;
				}
			}

			char? nextChar = input.FirstOrDefault();
			var next = nextChar?.ToString() ?? string.Empty;

			var transitions = GetAllTransitions(currentState, next);
			foreach (var transition in transitions)
			{
				steps.Add(transition.ToString());
				if (transition.Symbol == string.Empty)
				{
					if (ValidateWord(transition.EndState, input, steps))
					{
						return true;
					}
				}
				else
				{
					if (ValidateWord(transition.EndState, input.Substring(1), steps))
					{
						return true;
					}
				}
			}
			return false;
		}

		private IEnumerable<Transition> GetAllTransitions(string currentState, string symbol)
		{
			return Transitions.FindAll(t => t.StartState == currentState && (t.Symbol == symbol || t.Symbol == string.Empty));
		}

		private bool ValidateTransition(Transition transition)
		{
			return States.Contains(transition.StartState) &&
				States.Contains(transition.EndState) &&
				Alphabet.Contains(transition.Symbol);
		}

		private class StateMachineForConverting
		{
			public List<string> Alphabet { get; set; }
			public List<string> States { get; set; }
			public string BeginState { get; set; }
			public List<string> FinalStates { get; set; }
			public List<Transition> Transitions { get; set; }
		}
	}
}
