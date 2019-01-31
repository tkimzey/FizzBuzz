using System.Collections.Generic;
using FizzBuzzLibrary;

namespace AdvancedFizzBuzz {
	public class Program {
		public static void Main() {
			IList<KeyValuePair<int, string>> factorsToTokens = new List<KeyValuePair<int, string>> {
				new KeyValuePair<int, string>(3, "Fizz"),
				new KeyValuePair<int, string>(11, "Buzz"),
				new KeyValuePair<int, string>(42, "Bang")
			};
			FizzBuzzHelper fizzBuzzHelper = new FizzBuzzHelper(factorsToTokens);
			fizzBuzzHelper.PrintRange(-18, 235);
		}
	}
}
