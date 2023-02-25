namespace Roulette
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// 1 ~ 100 까지 랜덤하게 나옴 (확률은 같음)
			// 선택지는 홀짝 중에 선택 or 1~25, 26~50, 51~75, 76~100 중에 선택 or 10의자리 맞추기 선택 or 숫자 하나 맞추기 선택
			// 배당은 차례대로 1.5배, 2배, 3.5배, 5배
			int theNum;

			float[] Cut = {1.5f, 2, 3.5f, 10};
			Console.WriteLine(@"== 룰렛 ==
1 부터 100 까지 중 랜덤한 숫자가 정해집니다.
숫자를 맞추는 방식에 따라 배당이 달라집니다.
방식은 홀짝, 1/4. 10의 자리수 맞추기, 숫자 맞추기 가 있습니다.
배당은 순서대로 1.5배, 2배, 3.5배, 5배 입니다.

맞추는 방식을 선택해주세요
(1. 홀짝 맞추기   2. 1/4 맞추기   3. 10의 자리수 맞추기   4. 숫자 맞추기)");
			int Choice = Convert.ToInt32(Console.ReadLine()) - 1;
			Console.Clear();

			switch (Choice)
			{
				case 0:
					Odd_even odd_Even = new Odd_even();
					odd_Even.explain();
					theNum = SelectNum();
					theNum %= 2; odd_Even.choiceNum %= 2;
					odd_Even.getMoney(theNum, odd_Even.choiceNum, odd_Even.betMoney, Cut[Choice]);
					break;
				case 1:
					Quarter quarter = new Quarter();
					quarter.explain();
					theNum = SelectNum();
					if (theNum < 26)
						theNum = 1;
					else if (theNum < 51)
						theNum = 2;
					else if (theNum < 76)
						theNum = 3;
					else
						theNum = 4;
					quarter.getMoney(theNum, quarter.choiceNum, quarter.betMoney, Cut[Choice]);
					break; 
				case 2:
					TenGuess tenGuess = new TenGuess();
					tenGuess.explain();
					theNum = SelectNum();
					theNum /= 10;
					tenGuess.getMoney(theNum, tenGuess.choiceNum, tenGuess.betMoney, Cut[Choice]);
					break;
				case 3:
					PerfectGuess perfectGuess = new PerfectGuess();
					perfectGuess.explain();
					theNum = SelectNum();
					perfectGuess.getMoney(theNum, perfectGuess.choiceNum, perfectGuess.betMoney, Cut[Choice]);
					break;
			}
			Console.WriteLine("Press Enter..");
			Console.Read();
		}

		static int SelectNum()
		{
			Random random = new Random();
			int theNum;

			for (int i = 0; i < 20; i++)
			{
				theNum = random.Next(1, 101);
				Console.WriteLine("숫자가 선택되는 중입니다...");
				Console.WriteLine(theNum);
				Thread.Sleep(25 * i);
				Console.Clear();
			}

			theNum = random.Next(1, 101);
			Console.WriteLine("최종 숫자는 {0} 입니다!!", theNum);
			Console.WriteLine();
			return theNum;
		}
	}
	class Betting
	{
		public int choiceNum;
		public int betMoney;

		public virtual void explain()
		{
			while (true)
			{
				Console.WriteLine();
				Console.Write("숫자를 선택해주세요 : ");
				choiceNum = Convert.ToInt32(Console.ReadLine());
				Console.Write("베팅할 금액을 선택해주세요 : ");
				betMoney = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine();
				Console.Write($"선택하신 숫자는 {choiceNum}, 베팅한 금액은 {betMoney} 원 이 맞습니까? (Y or N) : ");
				string answer = Console.ReadLine();
				if (answer == "Y" || answer == "y")
					break;
				else if (answer != "n" && answer != "N")
					Console.WriteLine("잘못된 답변은 N 으로 간주합니다.");
			}
		}

		public virtual float getMoney(int theNum, int choiceNum, int betMoney, float cut)
		{
			float getmoney;

			if (theNum == choiceNum)
			{
				getmoney = betMoney * cut;
				Console.WriteLine("예상을 성공했습니다!");
			}
			else
			{
				getmoney = 0;
				Console.WriteLine("예상에 실패했습니다.");
			}
			Console.WriteLine($"배당금은 {getmoney} 원 입니다.");

			return getmoney;
		}
	}
	class Odd_even : Betting
	{
		public override void explain()
		{
			Console.WriteLine(@"홀짝을 선택하셨습니다.
홀짝은 숫자가 홀수인지 짝수인지를 맞추면 배당금을 얻고 틀리면 잃습니다.
배당은 1.5배입니다.
홀수를 예상하시면 1, 짝수를 예상하시면 2를 선택해주세요.");
			base.explain();
		}

		public override float getMoney(int theNum, int choiceNum, int betMoney, float cut)
		{
			return base.getMoney(theNum, choiceNum, betMoney, cut);
		}
	}
	class Quarter : Betting
	{
		public override void explain()
		{
			Console.WriteLine(@"1/4을 선택하셨습니다.
1/4는 숫자가 1~25, 26~50, 51~75, 76~100 중 어디에 위치하는지 맞추면 배당금을 얻고 틀리면 잃습니다.
배당은 2배 입니다.
1~25 를 예상하시면 1, 26~50 을 예상하시면 2, 51~75 를 예상하시면 3, 76~100을 예상하시면 4를 선택해주세요.");
			base.explain();
		}
		public override float getMoney(int theNum, int choiceNum, int betMoney, float cut)
		{
			return base.getMoney(theNum, choiceNum, betMoney, cut);
		}
	}
	class TenGuess : Betting
	{
		public override void explain()
		{
			Console.WriteLine(@"10의 자리수 맞추기를 선택하셨습니다.
10의 자리수 맞추기는 숫자의 10의 자리수를 맞추면 배당금을 얻고 틀리면 잃습니다.
배당은 3.5배 입니다.
예상하시는 숫자의 10의 자리수를 선택해주세요.");
			base.explain();
		}
		public override float getMoney(int theNum, int choiceNum, int betMoney, float cut)
		{
			return base.getMoney(theNum, choiceNum, betMoney, cut);
		}
	}
	class PerfectGuess : Betting
	{
		public override void explain()
		{
			Console.WriteLine(@"숫자맞추기를 선택하셨습니다.
숫자맞추기는 숫자를 완벽히 맞추면 배당금을 얻고 틀리면 잃습니다.
배당은 5배 입니다.
예상하시는 숫자를 선택해주세요.");
			base.explain();
		}
		public override float getMoney(int theNum, int choiceNum, int betMoney, float cut)
		{
			return base.getMoney(theNum, choiceNum, betMoney, cut);
		}
	}

}