namespace prjMultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MultiplicationFunction mf = new MultiplicationFunction();

            Console.WriteLine("輸入想呈現的乘法表");
            mf.userInput = int.Parse(Console.ReadLine());
            Console.WriteLine($"當前乘數: {mf.userInput}");

            mf.MultiplicationTable(mf.userInput);

            while (true)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("如果要重新設定乘法表請輸入: reset");
                Console.WriteLine("如果想看當前乘數請輸入: show");
                Console.WriteLine("如果想離開請輸入: exit");
                string userInputStr = Console.ReadLine();

                if (userInputStr == "reset") { mf.NumberResert(); }
                else if (userInputStr == "show")
                {
                    Console.WriteLine($"當前乘數: {mf.nowNumber}");

                    mf.MultiplicationTable(mf.nowNumber);
                }
                else if (userInputStr == "exit") { break; }
                else { Console.WriteLine("無對應的項目"); }
            }
        }
    }
}