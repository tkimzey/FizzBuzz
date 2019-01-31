using System;
using System.Collections.Generic;
using System.IO;

namespace FizzBuzzLibrary {

	public class FizzBuzzHelper : IFizzBuzzHelper {
		private readonly IOutputTokenizer _outputTokenizer;
		private readonly TextWriter _textWriter;

		public FizzBuzzHelper(IList<KeyValuePair<int, string>> factorsToTokens = null, TextWriter textWriter = null) {
			_outputTokenizer = new OutputTokenizer(factorsToTokens ??
												   new List<KeyValuePair<int, string>> {
													   new KeyValuePair<int, string>(3, "Fizz"),
													   new KeyValuePair<int, string>(5, "Buzz")
												   });
			_textWriter = textWriter ?? Console.Out;
		}

		public void PrintRange(int begin, int end) {
			for (int i = begin; i <= end; i++) {
				_textWriter.WriteLine(_outputTokenizer.GetOutputString(i));
			}
		}

		public void PrintSet(ISet<int> intSet) {
			foreach (int number in intSet) {
				_textWriter.WriteLine(_outputTokenizer.GetOutputString(number));
			}
		}
	}
}
