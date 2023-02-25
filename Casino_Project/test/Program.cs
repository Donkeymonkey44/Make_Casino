namespace test
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random();

			int randomInt;

			Console.WriteLine("Press Enter to Start");
			Console.ReadLine();

			for (int i = 0; i < 20; i++)
			{
				randomInt = random.Next(1, 101);
				Console.WriteLine(randomInt);
				Thread.Sleep(25 * i);
				Console.Clear();
			}
			randomInt = random.Next(1, 101);
			Console.WriteLine("최종 숫자는 {0}", randomInt);
		}
	}
}