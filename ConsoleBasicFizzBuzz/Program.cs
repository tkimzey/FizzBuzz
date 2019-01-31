using FizzBuzzLibrary;

namespace RegularFizzBuzz {
	public class Program {
		public static void Main() {
			IFizzBuzzHelper fizzBuzzHelper = new FizzBuzzHelper();
			fizzBuzzHelper.PrintRange(1,100);
		}
	}
}
