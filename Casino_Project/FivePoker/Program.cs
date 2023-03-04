namespace FivePoker
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Random random = new Random();
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
			Console.Write("베팅 금액 : ");
			int betMoney = Convert.ToInt32(Console.ReadLine());
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
					int Change = Convert.ToInt32(Console.ReadLine()) - 1;
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
			float getMoney = betMoney * cut[RankInt];
			Console.WriteLine($"이번판에 얻게 되는 돈은 {getMoney} 원 입니다.");
		}

		static int Calculate
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