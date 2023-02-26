using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine(@"
□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□
■                                                                                      ■
□              ●●●      ●●       ●●●   ●●●   ●    ●      ●●             □
■            ●           ●  ●     ●          ●     ●●  ●    ●    ●           ■  
□           ●           ●●●●     ●●●     ●     ● ● ●   ●      ●          □
■            ●         ●      ●         ●    ●     ●  ●●    ●    ●           ■
□              ●●●  ●        ●   ●●●   ●●●   ●    ●      ●●             □
■                                                                                      ■
□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□");
                Thread.Sleep(1300);
                Console.Clear();
                Console.WriteLine(@"
■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■
□                                                                                      □
■              ●●●      ●●       ●●●   ●●●   ●    ●      ●●             ■
□            ●           ●  ●     ●          ●     ●●  ●    ●    ●           □ 
■           ●           ●●●●     ●●●     ●     ● ● ●   ●      ●          ■
□            ●         ●      ●         ●    ●     ●  ●●    ●    ●           □
■              ●●●  ●        ●   ●●●   ●●●   ●    ●      ●●             ■
□                                                                                      □
■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■");
                Thread.Sleep(1300);
                Console.Clear();
            }

        }
    }
}
