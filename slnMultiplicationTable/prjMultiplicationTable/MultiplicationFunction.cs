using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjMultiplicationTable
{
    internal class MultiplicationFunction
    {
        public int userInput;

        public int nowNumber { get; private set; }

        internal void MultiplicationTable(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                for (int j = 1; j <= num; j++)
                {
                    Console.Write($"{i * j},");
                }
                Console.WriteLine();
            }
        }

        internal int NumberResert()
        {
            Console.WriteLine("請輸入重新設定乘法表的值");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("重設成功!!");

            nowNumber = num;

            return num;
        }
    }
}