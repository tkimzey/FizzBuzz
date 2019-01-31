using System.Collections.Generic;
using FizzBuzzLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzLibraryTests {
	[TestClass]
	public class TokenizedOutputHelperTest {

		[TestMethod]
		public void TestOutputSingleFactorTest() {
			IList<KeyValuePair<int, string>> factorsToTokens = new List<KeyValuePair<int, string>> {
				new KeyValuePair<int, string>(3, "Fizz")
			};
			OutputTokenizer outputTokenizer = new OutputTokenizer(factorsToTokens);
			string actual = outputTokenizer.GetOutputString(3);
			Assert.AreEqual("Fizz", actual);
		}

		[TestMethod]
		public void TestOutputMultipleFactorsTest() {
			IList<KeyValuePair<int, string>> factorsToTokens = new List<KeyValuePair<int, string>> {
				new KeyValuePair<int, string>(2, "Fizz"),
				new KeyValuePair<int, string>(3, "Buzz"),
				new KeyValuePair<int, string>(4, "Bang")
			};
			OutputTokenizer outputTokenizer = new OutputTokenizer(factorsToTokens);
			string actual = outputTokenizer.GetOutputString(12);
			Assert.AreEqual("FizzBuzzBang", actual);
		}

		[TestMethod]
		public void TestOutputMultipleFactorsOrderIsRespectedTest() {
			IList<KeyValuePair<int, string>> factorsToTokens = new List<KeyValuePair<int, string>> {
				new KeyValuePair<int, string>(4, "Bang"),
				new KeyValuePair<int, string>(2, "Fizz"),
				new KeyValuePair<int, string>(3, "Buzz")
			};
			OutputTokenizer outputTokenizer = new OutputTokenizer(factorsToTokens);
			string actual = outputTokenizer.GetOutputString(12);
			Assert.AreEqual("BangFizzBuzz", actual);
		}

		[TestMethod]
		public void TestFactorOnNegativeInput() {
			IList<KeyValuePair<int, string>> factorsToTokens = new List<KeyValuePair<int, string>> {
				new KeyValuePair<int, string>(2, "Cat"),
				new KeyValuePair<int, string>(3, "Duck")
			};
			OutputTokenizer outputTokenizer = new OutputTokenizer(factorsToTokens);
			string actual = outputTokenizer.GetOutputString(-12);
			Assert.AreEqual("CatDuck", actual);
		}

		[TestMethod]
		public void TestZeroAcceptsAllFactors() {
			IList<KeyValuePair<int, string>> factorsToTokens = new List<KeyValuePair<int, string>> {
					new KeyValuePair<int, string>(2, "Bear"),
					new KeyValuePair<int, string>(3, "Deer")
				};
			OutputTokenizer outputTokenizer = new OutputTokenizer(factorsToTokens);
			string actual = outputTokenizer.GetOutputString(0);
			Assert.AreEqual("BearDeer", actual);
		}

		[TestMethod]
		public void TestNoFactorsReturnsInput() {
			IList<KeyValuePair<int, string>> factorsToTokens = new List<KeyValuePair<int, string>> {
				new KeyValuePair<int, string>(2, "Bear"),
				new KeyValuePair<int, string>(3, "Deer")
			};
			OutputTokenizer outputTokenizer = new OutputTokenizer(factorsToTokens);
			string actual = outputTokenizer.GetOutputString(7);
			Assert.AreEqual("7", actual);
		}

		[TestMethod]
		public void TestEmptyFactorsToTokensReturnsInput() {
			IList<KeyValuePair<int, string>> factorsToTokens = new List<KeyValuePair<int, string>>();
			OutputTokenizer outputTokenizer = new OutputTokenizer(factorsToTokens);
			string actual = outputTokenizer.GetOutputString(55);
			Assert.AreEqual("55", actual);
		}

		[TestMethod]
		public void TestDuplicateFactorsAreAllowed() {
			IList<KeyValuePair<int, string>> factorsToTokens = new List<KeyValuePair<int, string>> {
				new KeyValuePair<int, string>(2, "Chicken"),
				new KeyValuePair<int, string>(2, "Turkey")
			};
			OutputTokenizer outputTokenizer = new OutputTokenizer(factorsToTokens);
			string actual = outputTokenizer.GetOutputString(2);
			Assert.AreEqual("ChickenTurkey", actual);
		}
	}
}
