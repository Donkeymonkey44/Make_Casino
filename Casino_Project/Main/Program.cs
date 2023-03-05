namespace Main
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Console.Write(@"
□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□
■                                                                                      ■
□              ●●●      ●●       ●●●   ●●●   ●    ●      ●●             □
■            ●           ●  ●     ●          ●     ●●  ●    ●    ●           ■  
□           ●           ●●●●     ●●●     ●     ● ● ●   ●      ●          □
■            ●         ●      ●         ●    ●     ●  ●●    ●    ●           ■
□              ●●●  ●        ●   ●●●   ●●●   ●    ●      ●●             □
■                                                                                      ■
□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□");
            Console.WriteLine("\nPress Enter...");
            Console.ReadLine();
			Console.Clear();
			Console.Write("이름을 입력해주세요 : ");
			string Nickname = Console.ReadLine();
			Console.Clear();
			if (Nickname.Length == 0)
			{
				Console.WriteLine("잘못된 이름입니다.");
				return;
			}

            float wallet = 0;
            var filepath = @$"C:/{Nickname}'s_Wallet";
			if (File.Exists(filepath))
			{
				using (var reader = new StreamReader(filepath))
				{
					while (!reader.EndOfStream)
					{
						string? readlineResult = reader.ReadLine();
						if(readlineResult != null)
						{
                            wallet = float.Parse(readlineResult);
                        }
                    }
				}
			}
			else
			{
				using (var writer = new StreamWriter(filepath))
				{
					writer.WriteLine("10000");
					wallet = 10000;
				}
			}
			if (wallet <= 0)
			{
				Console.WriteLine($@"{Nickname} 님의 소지금은 현재 0 원 입니다.
파일을 삭제합니다. 게임을 다시 시작해주세요.");
				File.Delete(filepath);
				Thread.Sleep(2000);
				return;
			}
			
			Blackjack blackjack = new Blackjack();
			Fivepoker fivepoker = new Fivepoker();
			Roulette roulette = new Roulette();
			string answer;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("카지노에 오신 것을 환영합니다!!");
			while (true)
			{
				if (wallet <= 0)
					break;
                Console.WriteLine($"{Nickname} 님의 현재 소지금 : {wallet} 원\n");
                Console.WriteLine(@"본 카지노의 게임은 총 세 가지 입니다.

1. BlackJack  블랙잭
2. FivePoker  파이브 포커
3. Roullette  룰렛

플레이 하실 게임을 선택해주세요(다른 선택을 하면 카지노를 나갑니다.) : ");
                Console.ForegroundColor = ConsoleColor.White;
                string ChoiceStr = Console.ReadLine();
                if (ChoiceStr.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("안녕히가세요.");
                    Thread.Sleep(2000);
                    using (var writer = new StreamWriter(filepath))
                        writer.WriteLine(wallet);
                    return;
                }
                int GameChoice = Convert.ToInt32(ChoiceStr);
                if (GameChoice == 1) //블랙잭
				{
					while (true)
					{
						Console.Clear();
						Console.WriteLine($"현재 소유금 : {wallet} 원\n");
						blackjack.Game();
                        Thread.Sleep(1500);
                        wallet -= blackjack.betMoney;
						if (wallet < 0)
						{
							Console.Clear() ;
							Console.WriteLine("소지금을 넘는 금액을 베팅할 수 없습니다.");
							Thread.Sleep(2000);
							break;
						}
						wallet += blackjack.getMoney;
                        if (wallet <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("돈을 모두 잃으셨습니다.");
                            Thread.Sleep(2000);
                            break;
                        }
                        Console.Write("\n게임을 계속 하시겠습니까? (Y or N) : ");
                        answer = Console.ReadLine();
                        if (answer == "N" || answer == "n")
                            break;
						else if (answer != "y" && answer != "Y")
						{
							Console.WriteLine("잘못된 답변은 N 으로 간주합니다.");
							Thread.Sleep(2000);
							break;
						}
                    }
				}
				else if (GameChoice == 2) //파이브포커
				{
					while (true)
					{
						Console.Clear();
                        Console.WriteLine($"현재 소유금 : {wallet} 원\n");
                        fivepoker.Game();
                        Thread.Sleep(1500);
                        wallet -= fivepoker.betMoney;
                        if (wallet < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("소지금을 넘는 금액을 베팅할 수 없습니다.");
                            Thread.Sleep(2000);
                            break;
                        }
						wallet += fivepoker.getMoney;
                        if (wallet <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("돈을 모두 잃으셨습니다.");
                            Thread.Sleep(2000);
                            break;
                        }
                        Console.Write("\n게임을 계속 하시겠습니까? (Y or N) : ");
						answer = Console.ReadLine();
						if (answer == "N" || answer == "n")
							break;
						else if (answer != "y" && answer != "Y")
						{
							Console.WriteLine("잘못된 답변은 N 으로 간주합니다.");
							Thread.Sleep(2000);
							break;
						}
					}
                }
				else if (GameChoice == 3) //룰렛
				{
					while (true)
					{
						Console.Clear();
                        Console.WriteLine($"현재 소유금 : {wallet} 원\n");
                        roulette.Game();
						Thread.Sleep(1500);
						wallet -= roulette.betMoney;
                        if (wallet < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("소지금을 넘는 금액을 베팅할 수 없습니다.");
                            Thread.Sleep(2000);
                            break;
                        }
						wallet += roulette.getMoney;
                        if (wallet <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("돈을 모두 잃으셨습니다.");
                            Thread.Sleep(2000);
                            break;
                        }
                        Console.Write("\n게임을 계속 하시겠습니까? (Y or N) : ");
						answer = Console.ReadLine();
						if (answer == "N" || answer == "n")
							break;
						else if (answer != "y" && answer != "Y")
						{
							Console.WriteLine("잘못된 답변은 N 으로 간주합니다.");
							Thread.Sleep(2000);
							break;
						}
					}
                }
				else 
				{
					Console.Clear();
					Console.WriteLine("안녕히가세요.");
					Thread.Sleep(2000);
                    using (var writer = new StreamWriter(filepath))
                        writer.WriteLine(wallet);
                    return;
				}
				Console.Clear();
			}
            using (var writer = new StreamWriter(filepath))
                writer.WriteLine(wallet);
        }
    }
	class Blackjack
	{
		public int betMoney;
		public float getMoney;
		public float Game()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(@"== 블랙잭 ==
A, 2 ~ 10, J, Q, K 의 카드로 딜러와 대결을 해서 카드의 합이 21에 더 가까운 쪽이 승리하는 게임입니다.
J, Q, K 는 10으로 간주하며, A는 1 또는 11 로 원하는 수로 정할 수 있습니다.
플레이어는 처음에 두 장의 카드를 받고 그 이후로 원하는 만큼 카드를 받을 수 있습니다.
딜러는 카드의 합이 16이 넘지 않으면 무조건 카드를 더 받고 21이 넘으면 패배합니다.
플레이어는 21이 넘으면 무조건 패배합니다. 딜러가 21이 넘어도 무승부가 아닌 패배로 간주합니다.
배당은 2배로 고정이며 패배하면 잃습니다. 예외로 처음 받은 두 카드로 21을 만들었을 시 2.5배의 배당을 갖습니다.
딜러와 플레이어의 수의 합이 같을 경우 무승부로 베팅금을 돌려받습니다.

베팅하실 금액을 입력해주세요.");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("베팅 금액 : ");
			betMoney = Convert.ToInt32(Console.ReadLine());
			Console.Clear();
			string[] Card = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

			Random random = new Random();
			string[] dealerCard = new string[11];
			string[] playerCard = new string[11];

			int dcNum = 0;
			int pcNum = 0;
			while (dcNum < 2)
			{
				dealerCard[dcNum] = Card[random.Next(0, 13)];
				playerCard[pcNum] = Card[random.Next(0, 13)];
				dcNum++; pcNum++;
			}

			SpreadCardNodealer(dealerCard, playerCard);

			if (SumCard(playerCard) == 21)
			{
				Console.WriteLine("\nBlackJack!!");
				while (SumCard(dealerCard) <= 16)
				{
					dealerCard[dcNum] = Card[random.Next(0, 13)];
					dcNum++;
					Thread.Sleep(1500);
					Console.Clear();
					SpreadCard(dealerCard, playerCard);
					Console.WriteLine("\nBlackJack!!");
				}
				if (SumCard(dealerCard) == 21)
				{
					Console.WriteLine($"\nDraw");
					getMoney = betMoney;
                    Console.WriteLine($"배당금은 {getMoney} 원 입니다.");
                    return getMoney;
				}
				else
				{
					Console.WriteLine("\nYou Win!!");
					getMoney = betMoney * 2.5f;
                    Console.WriteLine($"배당금은 {getMoney} 원 입니다.");
                    return getMoney;
				}
			}

			while (true)
			{
				Console.Write("\nHit(1) Or Stay(2) ?? : ");
				string answer = Console.ReadLine();
				if (answer == "1")
				{
					playerCard[pcNum] = Card[random.Next(0, 13)];
					pcNum++;
					Console.Clear();
					SpreadCardNodealer(dealerCard, playerCard);
					if (SumCard(playerCard) > 21)
						break;
				}
				else if (answer == "2" || answer.Length == 0)
					break;
				else
				{
					Console.WriteLine("잘못된 대답은 Hit(1) 로 간주합니다.");
					playerCard[pcNum] = Card[random.Next(0, 13)];
					pcNum++;
					Console.Clear();
					SpreadCardNodealer(dealerCard, playerCard);
				}
			}
			Console.Clear();
			SpreadCard(dealerCard, playerCard);
			if (SumCard(playerCard) > 21)
			{
				Console.WriteLine("\nYOU BUST!!!\nYou Lose...");
				getMoney = 0;
                Console.WriteLine($"배당금은 {getMoney} 원 입니다.");
                return getMoney;
			}
			//Thread.Sleep(1500);
			while (SumCard(dealerCard) <= 16)
			{
				dealerCard[dcNum] = Card[random.Next(0, 13)];
				dcNum++;
				Thread.Sleep(1500);
				Console.Clear();
				SpreadCard(dealerCard, playerCard);
			}
			if (SumCard(dealerCard) > 21)
			{
				Console.WriteLine("\nDealer BUST!!!\nYou Win!!");
				getMoney = betMoney * 2;
                Console.WriteLine($"배당금은 {getMoney} 원 입니다.");
                return getMoney;
			}
			else if (SumCard(dealerCard) > SumCard(playerCard))
			{
				Console.WriteLine("\nYou Lose...");
				getMoney = 0;
                Console.WriteLine($"배당금은 {getMoney} 원 입니다.");
                return getMoney;
			}
			else if (SumCard(dealerCard) < SumCard(playerCard))
			{
				Console.WriteLine("\nYou Win!!!");
				getMoney = betMoney * 2;
                Console.WriteLine($"배당금은 {getMoney} 원 입니다.");
                return getMoney;
			}
			else
			{
				Console.WriteLine("\nDraw");
				getMoney = betMoney;
                Console.WriteLine($"배당금은 {getMoney} 원 입니다.");
                return getMoney;
			}
		}

		private static int Dict(string Card)
		{
			int[] dict = { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };
			string[] card = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
			int i = 0;

			if (Card == null)
				return 0;

			while (i < 13)
			{
				if (card[i] == Card)
					return dict[i];
				i++;
			}
			return 0;
		}
		private static int FoundA(string[] Card, int CardLength)
		{
			int i = 0;

			while (i < CardLength)
			{
				if (Card[i] == "A")
					return 1;
				i++;
			}
			return 0;
		}
		private static int SumCard(string[] Card)
		{
			int[] Cardlist = new int[Card.Length];

			for (int i = 0; i < Card.Length; i++)
			{
				Cardlist[i] = Dict(Card[i]);
			}

			int a = 0;
			int sum = 0;
			while (a < Cardlist.Length)
			{
				sum += Cardlist[a];
				a++;
			}

			if (FoundA(Card, Card.Length) == 1 && sum > 21)
				sum -= 10;
			return sum;
		}
		private static void SpreadCardNodealer(string[] dealerCard, string[] playerCard)
		{
			Console.WriteLine("== 딜러의 카드 ==");
			Console.WriteLine($"??  {dealerCard[1]}\n");
			Console.WriteLine("== 플레이어의 카드 ==");
			int ind = 0;
			while (playerCard[ind] != null)
			{
				Console.Write($"{playerCard[ind]}  ");
				ind++;
			}
			Console.WriteLine("\n\n딜러 카드의 합 : ??");
			Console.WriteLine($"플레이어 카드의 합 : {SumCard(playerCard)}");
		}
		private static void SpreadCard(string[] dealerCard, string[] playerCard)
		{
			Console.WriteLine("== 딜러의 카드 ==");
			int Di = 0;
			while (dealerCard[Di] != null)
			{
				Console.Write($"{dealerCard[Di]}  ");
				Di++;
			}
			Console.WriteLine("\n\n== 플레이어의 카드 ==");
			int Pi = 0;
			while (playerCard[Pi] != null)
			{
				Console.Write($"{playerCard[Pi]}  ");
				Pi++;
			}
			Console.WriteLine($"\n\n딜러 카드의 합 : {SumCard(dealerCard)}");
			Console.WriteLine($"플레이어 카드의 합 : {SumCard(playerCard)}");
		}
	}
	class Roulette
	{
		public int betMoney;
		public float getMoney;
		public void Game()
		{
			int theNum;

			float[] Cut = { 1.5f, 2.5f, 5, 10 };
            Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(@"== 룰렛 ==
1 부터 100 까지 중 랜덤한 숫자가 정해집니다.
숫자를 맞추는 방식에 따라 배당이 달라집니다.
방식은 홀짝, 1/4. 10의 자리수 맞추기, 숫자 맞추기 가 있습니다.
배당은 순서대로 1.5배, 2.5배, 5배, 10배 입니다.");

            Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(@"
맞추는 방식을 선택해주세요
(1. 홀짝 맞추기   2. 1/4 맞추기   3. 10의 자리수 맞추기   4. 숫자 맞추기)");
			int Choice = Convert.ToInt32(Console.ReadLine()) - 1;
			Console.Clear();

			switch (Choice)
			{
				case 0:
					Odd_even odd_Even = new Odd_even();
					odd_Even.explain();
					betMoney = odd_Even.betMoney;
					theNum = SelectNum();
					theNum %= 2; odd_Even.choiceNum %= 2;
					getMoney = odd_Even.getmoney(theNum, odd_Even.choiceNum, odd_Even.betMoney, Cut[Choice]);
					break;
				case 1:
					Quarter quarter = new Quarter();
					quarter.explain();
					betMoney = quarter.betMoney;
					theNum = SelectNum();
					if (theNum < 26)
						theNum = 1;
					else if (theNum < 51)
						theNum = 2;
					else if (theNum < 76)
						theNum = 3;
					else
						theNum = 4;
					getMoney = quarter.getmoney(theNum, quarter.choiceNum, quarter.betMoney, Cut[Choice]);
					break;
				case 2:
					TenGuess tenGuess = new TenGuess();
					tenGuess.explain();
					betMoney = tenGuess.betMoney;
					theNum = SelectNum();
					theNum /= 10;
					getMoney = tenGuess.getmoney(theNum, tenGuess.choiceNum, tenGuess.betMoney, Cut[Choice]);
					break;
				case 3:
					PerfectGuess perfectGuess = new PerfectGuess();
					perfectGuess.explain();
					betMoney = perfectGuess.betMoney;
					theNum = SelectNum();
					getMoney = perfectGuess.getmoney(theNum, perfectGuess.choiceNum, perfectGuess.betMoney, Cut[Choice]);
					break;
			}
		}

		private static int SelectNum()
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
		public float getMoney;

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

		public virtual float getmoney(int theNum, int choiceNum, int betMoney, float cut)
		{
			if (theNum == choiceNum)
			{
				getMoney = betMoney * cut;
				Console.WriteLine("예상을 성공했습니다!");
			}
			else
			{
				getMoney = 0;
				Console.WriteLine("예상에 실패했습니다.");
			}
			Console.WriteLine($"배당금은 {getMoney} 원 입니다.");

			return getMoney;
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

		public override float getmoney(int theNum, int choiceNum, int betMoney, float cut)
		{
			return base.getmoney(theNum, choiceNum, betMoney, cut);
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
		public override float getmoney(int theNum, int choiceNum, int betMoney, float cut)
		{
			return base.getmoney(theNum, choiceNum, betMoney, cut);
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
		public override float getmoney(int theNum, int choiceNum, int betMoney, float cut)
		{
			return base.getmoney(theNum, choiceNum, betMoney, cut);
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
		public override float getmoney(int theNum, int choiceNum, int betMoney, float cut)
		{
			return base.getmoney(theNum, choiceNum, betMoney, cut);
		}
	}
	class Fivepoker
	{
		public int betMoney;
		public float getMoney;
		public void Game()
		{
			Random random = new Random();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"== 파이브 포커 ==
♠, ♣, ◈, ♥ 4종류 모양의 카드가 7 ~ 10, J, Q, K, A 총 32장의 카드로 플레이 합니다.
5장의 카드로 만드는 족보에 따른 배당률을 갖습니다.

배당률은 다음과 같습니다.
탑                                         0 배
원페어					 0.5 배
투페어					 1.0 배
트리플					 1.5 배
스트레이트				 2.5 배
플러시					 4.0 배
풀 하우스				 5.0 배
포카드					 7.5 배
스트레이트 플러시        	    	10.0 배
로얄 스트레이트 플러시               	15.0 배

베팅하실 금액을 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("베팅 금액 : ");
			betMoney = Convert.ToInt32(Console.ReadLine());
			Console.Clear();
			float[] cut = { 0, 0.5f, 1, 1.5f, 2.5f, 4, 5, 7.5f, 10, 15 };
			string[] Rank = { "Top", "One Pair", "Two Pair", "Triple", " Straight", "Flush", "Full House", "Four Card", "Straight Flush", "Royal Straight Flush" };
			string[] userP = new string[5];
			string[] userN = new string[5];
			int[] userC = new int[5];
			int RankInt;

			string[] Pattern = { "♠", "♣", "◈", "♥" };
			string[] Number = { "7", "8", "9", "10", "J", "Q", "K", "A" };

			for (int i = 0; i < 5; i++)
			{
				int Pint = random.Next(0, 4);
				int Nint = random.Next(0, 8);
				userP[i] = Pattern[Pint];
				userN[i] = Number[Nint];
			}
			while (true)
			{
				for (int i = 0; i < 5; i++)
					userC[i] = 0;
				for (int j = 0; j < 5; j++)
				{
					Console.Write($"{userP[j]}{userN[j]}   ");
				}
				Console.WriteLine("\n");
				RankInt = Calculate(userP[0], userN[0], userP[1], userN[1], userP[2], userN[2], userP[3], userN[3], userP[4], userN[4]);
				Console.WriteLine($"현재 점수는 {Rank[RankInt]} 입니다.");
				Console.WriteLine("\n");
				Console.WriteLine(@"바꾸실 카드를 선택해주세요. (1 ~ 5)
같은 숫자를 다시 입력하면 취소됩니다. 모두 선택하셨으면 0을 입력하세요. ");
				while (true)
				{
					string ChangeStr = Console.ReadLine();
					if (ChangeStr.Length == 0)
						break;
					int Change = Convert.ToInt32(ChangeStr) - 1;
					if (Change == -1)
						break;
					else if (!(Change >= -1 && Change <= 4))
					{
						Console.WriteLine("잘못된 입력은 0으로 간주합니다.");
						break;
					}
					else
					{
						if (userC[Change] == 0)
							userC[Change] = 1;
						else
							userC[Change] = 0;
					}
				}
				Console.Write("\n바꾸실 카드는 ");
				for (int i = 0; i < 5; i++)
				{
					if (userC[i] == 1)
						Console.Write($"{userP[i]}{userN[i]} ");
				}
				Console.Write("가 맞습니까? (Y or N) : ");
				string Chanswer = Console.ReadLine();
				if (Chanswer == "y" || Chanswer == "Y")
				{
					Console.Clear();
					break;
				}
				else if (Chanswer != "n" && Chanswer != "N")
				{
					Console.WriteLine("잘못된 답변은 Y로 간주합니다.");
					Thread.Sleep(2000);
					Console.Clear();
					break;
				}
				else
				{
					Console.Clear();
					Console.WriteLine("다시 선택합니다.");
				}
			}
			for (int i = 0; i < 5; i++)
			{
				if (userC[i] == 1)
				{
					int Pint = random.Next(0, 4);
					int Nint = random.Next(0, 8);
					userP[i] = Pattern[Pint];
					userN[i] = Number[Nint];
				}
			}
			Console.WriteLine("최종 카드는 \n");
			for (int j = 0; j < 5; j++)
			{
				Console.Write($"{userP[j]}{userN[j]}   ");
			}
			Console.WriteLine("\n입니다.");
			RankInt = Calculate(userP[0], userN[0], userP[1], userN[1], userP[2], userN[2], userP[3], userN[3], userP[4], userN[4]);

			Console.WriteLine();
			Console.WriteLine($"현재 점수는 {Rank[RankInt]} 입니다.");
			getMoney = betMoney * cut[RankInt];
			Console.WriteLine($"이번판에 얻게 되는 돈은 {getMoney} 원 입니다.");
		}

		private static int Calculate
			(string P1, string N1, string P2, string N2, string P3, string N3, string P4, string N4, string P5, string N5)
		{
			int[] Ndict = { 7, 8, 9, 10, 11, 12, 13, 14 };
			int n1 = Ndict[Dict(N1)];
			int n2 = Ndict[Dict(N2)];
			int n3 = Ndict[Dict(N3)];
			int n4 = Ndict[Dict(N4)];
			int n5 = Ndict[Dict(N5)];
			int[] cardArray = { n1, n2, n3, n4, n5 };
			Array.Sort(cardArray);

			if (P1 == P2 && P2 == P3 && P3 == P4 && P4 == P5 &&
				cardArray[0] == 10 && cardArray[1] == 11 && cardArray[2] == 12 && cardArray[3] == 13 && cardArray[4] == 14) // 로티플
				return 9;
			else if (P1 == P2 && P2 == P3 && P3 == P4 && P4 == P5 &&
				cardArray[4] - 1 == cardArray[3] && cardArray[3] - 1 == cardArray[2] && cardArray[2] - 1 == cardArray[1] &&
				cardArray[1] - 1 == cardArray[0]) // 스트레이트 플러시
				return 8;
			else if ((N1 == N2 && N2 == N3 && N3 == N4) || (N1 == N2 && N2 == N3 && N3 == N5) ||
				(N1 == N2 && N2 == N4 && N4 == N5) || (N1 == N3 && N3 == N4 && N4 == N5) ||
				(N2 == N3 && N3 == N4 && N4 == N5)) // 포카드
				return 7;
			else if (((N1 == N2 && N2 == N3) && (N4 == N5)) || ((N1 == N2 && N2 == N4) && (N3 == N5)) ||
				((N1 == N2 && N2 == N5) && (N3 == N4)) || ((N1 == N3 && N3 == N4) && (N2 == N5)) ||
				((N1 == N3 && N3 == N5) && (N2 == N4)) || ((N1 == N4 && N4 == N5) && (N2 == N3)) ||
				((N2 == N3 && N3 == N4) && (N1 == N5)) || ((N2 == N3 && N3 == N5) && (N1 == N4)) ||
				((N2 == N4 && N4 == N5) && (N1 == N3)) || ((N3 == N4 && N4 == N5) && (N1 == N2))) // 풀하우스
				return 6;
			else if (P1 == P2 && P2 == P3 && P3 == P4 && P4 == P5) // 플러시
				return 5;
			else if (cardArray[4] - 1 == cardArray[3] && cardArray[3] - 1 == cardArray[2] &&
				cardArray[2] - 1 == cardArray[1] && cardArray[1] - 1 == cardArray[0]) // 스트레이트
				return 4;
			else if ((N1 == N2 && N2 == N3) || (N1 == N2 && N2 == N4) || (N1 == N2 && N2 == N5) || (N1 == N3 && N3 == N4) ||
				(N1 == N3 && N3 == N5) || (N1 == N4 && N4 == N5) || (N2 == N3 && N3 == N4) || (N2 == N3 && N3 == N5) ||
				(N2 == N4 && N4 == N5) || (N3 == N4 && N4 == N5)) // 트리플
				return 3;
			else if ((N1 == N2 && N3 == N4) || (N1 == N2 && N3 == N5) || (N1 == N2 && N4 == N5) || (N1 == N3 && N2 == N4) ||
				(N1 == N3 && N2 == N5) || (N1 == N3 && N4 == N5) || (N1 == N4 && N2 == N3) || (N1 == N4 && N2 == N5) ||
				(N1 == N4 && N3 == N5) || (N1 == N5 && N2 == N3) || (N1 == N5 && N2 == N4) || (N1 == N5 && N3 == N4) ||
				(N2 == N3 && N4 == N5) || (N2 == N4 && N3 == N5) || (N2 == N5 && N3 == N4)) // 투페어
				return 2;
			else if (N1 == N2 || N1 == N3 || N1 == N4 || N1 == N5 || N2 == N3 || N2 == N4 || N2 == N5 ||
				N3 == N4 || N3 == N5 || N4 == N5) // 원페어
				return 1;
			else // 탑
				return 0;
		}

		static int Dict(string Number)
		{
			string[] dict = { "7", "8", "9", "10", "J", "Q", "K", "A" };
			int i = 0;
			while (i < 8)
			{
				if (dict[i] == Number)
					return i;
				i++;
			}
			return -1;
		}
	}
}