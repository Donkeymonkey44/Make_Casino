using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
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
            string[] Card = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        }
    }
}
