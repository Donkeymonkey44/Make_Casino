using System.Runtime.InteropServices;

namespace test2
{
    class AsyncAwaitSimple
    {
        static void Main(string[] args)
        {
            AsyncFunc();
            Console.WriteLine("Main End");
            Console.Read();
        }

        public static async void AsyncFunc()
        {
            await Task.Delay(1000);
            Console.WriteLine("AsyncFunc End");
        }
    }
}