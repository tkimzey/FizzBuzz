using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzLibrary;

namespace FizzBuzzLibraryTests {
	[TestClass]
	public class FizzBuzzHelperTests {
		private StringWriter _stringWriter;

		[TestInitialize]
		public void TestInitialize() {
			_stringWriter = new StringWriter();
		}

		[TestCleanup]
		public void TestCleanup() {
			_stringWriter.Dispose();
		}

		private static string GetExpectedOutputWithLineBreaks(IEnumerable<string> tokens) {
			return string.Join("\r\n", tokens) + "\r\n";
		}

		[TestMethod]
		public void TestPrintRangeDefaultFactorsToTokens() {
			IFizzBuzzHelper fizzBuzzHelper = new FizzBuzzHelper(null, _stringWriter);
			string expected =
				GetExpectedOutputWithLineBreaks(new List<string> { "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" });
			fizzBuzzHelper.PrintRange(10, 15);
			Assert.AreEqual(expected, _stringWriter.ToString());
		}

		[TestMethod]
		public void TestPrintRangeCustomFactorsToTokens() {
			IList<KeyValuePair<int, string>> factorsToTokens = new List<KeyValuePair<int, string>> {
				new KeyValuePair<int, string>(2, "Cat"),
				new KeyValuePair<int, string>(3, "Duck"),
				new KeyValuePair<int, string>(4, "Chicken")
			};
			IFizzBuzzHelper fizzBuzzHelper = new FizzBuzzHelper(factorsToTokens, _stringWriter);
			string expected = GetExpectedOutputWithLineBreaks(new List<string> {
					 "Cat", "Duck", "CatChicken", "5", "CatDuck", "7",
					 "CatChicken",
					 "Duck", "Cat", "11", "CatDuckChicken"
			});
			fizzBuzzHelper.PrintRange(2, 12);
			Assert.AreEqual(expected, _stringWriter.ToString());
		}
		
		[TestMethod]
		public void TestPrintSetDefaultFactorsToTokens() {
			IFizzBuzzHelper fizzBuzzHelper = new FizzBuzzHelper(null, _stringWriter);
			string expected = GetExpectedOutputWithLineBreaks(new List<string> {
				"FizzBuzz","1","Buzz","2","Fizz"
			});
			fizzBuzzHelper.PrintSet(new HashSet<int> {15, 1, 5, 2, 3});
			Assert.AreEqual(expected, _stringWriter.ToString());
		}

		[TestMethod]
		public void TestPrintSetCustomFactorsToTokens() {
			IList<KeyValuePair<int, string>> factorsToTokens = new List<KeyValuePair<int, string>> {
				new KeyValuePair<int, string>(3, "Fizz"),
				new KeyValuePair<int, string>(4, "Buzz"),
				new KeyValuePair<int, string>(5, "Bang")
			};
			IFizzBuzzHelper fizzBuzzHelper = new FizzBuzzHelper(factorsToTokens, _stringWriter);
			fizzBuzzHelper.PrintSet(new HashSet<int>{ 3, 4, 5, 7, 12, 20, 60 });
			string expected = GetExpectedOutputWithLineBreaks(new List<string> {
				"Fizz", "Buzz", "Bang", "7", "FizzBuzz", "BuzzBang", "FizzBuzzBang"
			});
			Assert.AreEqual(expected, _stringWriter.ToString());
		}
	}
}
