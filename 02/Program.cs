using System;

namespace 김영휘16037010_과제02
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] arr = new int[10];
            int min = 0, max = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0} 번째 값을 입력하시오 : ", i + 1);
                arr[i] = Int32.Parse(Console.ReadLine());
                if (i == 0) 
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            Console.WriteLine("maximun = {0} , minimum = {1} ",max, min);
        }
    }
}
