namespace Entrance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sign();

            
            Console.ReadLine();
        }

        static async Task Sign()
        {
            while (true)
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
                await Task.Delay(1250);
                Console.Clear();
                Console.Write(@"
■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■
□                                                                                      □
■              ●●●      ●●       ●●●   ●●●   ●    ●      ●●             ■
□            ●           ●  ●     ●          ●     ●●  ●    ●    ●           □  
■           ●           ●●●●     ●●●     ●     ● ● ●   ●      ●          ■
□            ●         ●      ●         ●    ●     ●  ●●    ●    ●           □
■              ●●●  ●        ●   ●●●   ●●●   ●    ●      ●●             ■
□                                                                                      □
■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■");
                Console.WriteLine("\nPress Enter...");
                await Task.Delay(1250);
                Console.Clear();
            }
        }
    }
}