using System.Collections.Generic;

namespace FizzBuzzLibrary {
	public class OutputTokenizer : IOutputTokenizer {

		private readonly IList<KeyValuePair<int, string>> _factorsToTokens;

		public OutputTokenizer(IList<KeyValuePair<int, string>> factorsToTokens) {
			_factorsToTokens = factorsToTokens;
		}

		public string GetOutputString(int number) {
			string output = "";
			foreach (KeyValuePair<int, string> kvp in _factorsToTokens) {
				if (number % kvp.Key == 0) {
					output += kvp.Value;
				}
			}

			if (string.IsNullOrEmpty(output)) {
				output = number.ToString();
			}

			return output;
		}
	}
}
