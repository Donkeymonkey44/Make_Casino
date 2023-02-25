namespace FivePoker
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// 카드는 4문양 7 ~ K, A
			// 5장을 받고 시작
			// 5장은 각각 한번씩 바꿀 수 있음
			// 카드를 받기 전에 돈을 걸고, 최종적으로 5장으로 만들어진 족보의 점수에 따라 배당금이 달라짐
			// 배당은 탑 0배, 원페어 0.5배, 투페어 1배, 트리플 1.5배, 스트레이트 2.5배
			// 플러시 3배, 풀하우스 4배, 포카드 5배, 스트레이트플러시 7배

			Random random = new Random();
			Console.WriteLine(@"==파이브 포커==
♠, ♣, ◈, ♥ 4종류 모양의 카드가 7 ~ 10, J, Q, K, A 총 32장의 카드로 플레이 합니다.
5장의 카드로 만드는 족보에 따른 배당률을 갖습니다.

배당률은 다음과 같습니다.
원페어					0.5 배
투페어					1.0 배
트리플					1.5 배
스트레이트				2.5 배
플러시					4.0 배
풀 하우스				5.0 배
포카드					7.5 배
스트레이트 플러시		10.0 배
로얄 스트레이트 플러시	15.0 배

배팅하실 금액을 입력해주세요 : ");
			Console.Write("베팅 금액 : ");
			int betMoney = Convert.ToInt32(Console.ReadLine());
			float[] cut = { 0.5f, 1, 1.5f, 2.5f, 4, 5, 7.5f, 10, 15 };
			string[] userP = new string[5];
			string[] userN = new string[5];

			string[] Pattern = { "♠", "♣", "◈", "♥" };
			string[] Number = { "7", "8", "9", "10", "J", "Q", "K", "A" };

		}
	}
}