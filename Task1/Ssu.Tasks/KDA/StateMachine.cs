using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KDA
{
	public class StateMachine
	{
		private readonly string _initialState;
		private readonly List<State> _states;
		private readonly List<Transition> _transitions;

		public StateMachine(string jsonFilePath)
		{
			var stateMachine = CreateMachineByJson(jsonFilePath);
			_initialState = stateMachine.States[0].Name;
			_states = stateMachine.States;
			_transitions = stateMachine.Transitions;
		}

		public string Run(char[] input, out ICollection<string> logs)
		{
			logs = new List<string>();
			var output = string.Empty;
			var currentState = _initialState;

			foreach (var c in input)
			{
				if (IsEndState(currentState))
					return output;

				var transition = GetNextTransition(currentState, c);
				if (transition == null)
					return output;

				logs.Add($"{c} => ({transition.StartState}, {transition.EndState}) => {transition.Result}");

				output += transition.Result;
				currentState = transition.EndState;
			}

			return output;
		}
		
		private bool IsEndState(string stateName)
		{
			return _states.FirstOrDefault(s => s.Name == stateName).IsEndState;
		}

		private Transition GetNextTransition(string startState, char c)
		{
			return _transitions.FirstOrDefault(t => t.StartState == startState && t.Condition == c);
		}

		private StateMachineForConverting CreateMachineByJson(string jsonFilePath)
		{
			using var reader = new StreamReader(jsonFilePath);
			return JsonConvert.DeserializeObject<StateMachineForConverting>(reader.ReadToEnd());
		}

		private class StateMachineForConverting
		{
			public List<State> States { get; set; }
			public List<Transition> Transitions { get; set; }
		}
	}
}
