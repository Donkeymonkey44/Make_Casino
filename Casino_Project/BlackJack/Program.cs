namespace BlackJack
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(@"== 블랙잭 ==
A, 2 ~ 10, J, Q, K 의 카드로 딜러와 대결을 해서 카드의 합이 21에 더 가까운 쪽이 승리하는 게임입니다.
J, Q, K 는 10으로 간주하며, A는 1 또는 11 로 원하는 수로 정할 수 있습니다.
플레이어는 처음에 두 장의 카드를 받고 그 이후로 원하는 만큼 카드를 받을 수 있습니다.
딜러는 카드의 합이 16이 넘지 않으면 무조건 카드를 더 받고 21이 넘으면 패배합니다.
플레이어는 21이 넘으면 무조건 패배합니다. 딜러가 21이 넘어도 무승부가 아닌 패배로 간주합니다.
배당은 2배로 고정이며 패배하면 잃습니다. 예외로 처음 받은 두 카드로 21을 만들었을 시 2.5배의 배당을 갖습니다.
딜러와 플레이어의 수의 합이 같을 경우 무승부로 배팅금을 돌려받습니다.

베팅하실 금액을 입력해주세요.");

			Console.Write("베팅 금액 : ");
			int betMoney = Convert.ToInt32(Console.ReadLine());
			float getMoney;
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
					Console.WriteLine("\nDraw");
					getMoney = betMoney;
					return;
				}
				else
				{
					Console.WriteLine("\nDraw");
					getMoney = betMoney * 2.5f;
					return;
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
				else if (answer == "2")
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
				return;
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
				return;
			}
			else if (SumCard(dealerCard) > SumCard(playerCard))
			{
				Console.WriteLine("\nYou Lose...");
				getMoney = 0;
				return;
			}
			else if (SumCard(dealerCard) < SumCard(playerCard))
			{
				Console.WriteLine("\nYou Win!!!");
				getMoney = betMoney * 2;
				return;
			}
			else
			{
				Console.WriteLine("\nDraw");
				getMoney = betMoney * 2.5f;
				return;
			}
		}

		static int Dict(string Card)
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
		static int FoundA(string[] Card, int CardLength)
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
		static int SumCard(string[] Card)
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
		static void SpreadCardNodealer(string[] dealerCard, string[] playerCard)
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
		static void SpreadCard(string[] dealerCard, string[] playerCard)
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
}