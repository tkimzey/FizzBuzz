using System.Collections.Generic;

namespace FizzBuzzLibrary {
	public interface IFizzBuzzHelper {
		void PrintRange(int begin, int end);
		void PrintSet(ISet<int> numberSet);
	}
}
