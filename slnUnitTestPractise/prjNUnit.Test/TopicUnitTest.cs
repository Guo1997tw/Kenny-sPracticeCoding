using MyTestProgram;

namespace prjNUnit.Test
{
	[TestFixture]
	public class TopicUnitTest
	{
		[TestCase(3, 4, 7)]
		[TestCase(1, 4, 5)]
		[TestCase(6, 0, 6)]
		[TestCase(-2, 3, 1)]
		public void AddNumberTest(int num1, int num2, int expected)
		{
			// Act
			int result = AddNumberMethod(num1, num2);

			// Assert
			Assert.AreEqual(expected, result);
		}

		public int AddNumberMethod(int num1, int num2)
		{
			return num1 + num2;
		}
	}
}