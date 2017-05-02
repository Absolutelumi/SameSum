using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] someArray = { 0, 1, 2, 3, 4, 5 };
            int count = 0; 

            Console.WriteLine(SomeMethod(someArray, ref count) ? "True" : "False");
            Console.ReadLine(); 
        }

        static bool SomeMethod(int[] numbers, ref int count)
        {
            while (count != numbers.Length)
            {
                int[] TempArray1;
                int[] TempArray2;

                for (int i = 1; i < numbers.Length; i++)
                {
                    TempArray1 = new int[i];
                    TempArray2 = new int[numbers.Length - i];

                    TempArray1 = FillArray(numbers, TempArray1);
                    TempArray2 = FillArray(numbers, TempArray1);

                    if (TempArray1.Sum() == TempArray2.Sum())
                    {
                        return true;
                    }
                }

                #region Make New Array
                int[] tempArray = numbers;
                for (int i = 0; i <= numbers.Length; i++)
                {
                    if (i == 0)
                    {
                        numbers[i] = tempArray[numbers.Length - 1];
                    }
                    else
                    {
                        numbers[i] = tempArray[i - 1];
                    }
                }
                #endregion

                count++;
                SomeMethod(numbers, ref count);
            }
            return false;
        }

        static int[] FillArray(int[] filler, int[] filled)
        {
            for (int i = 0; i < filled.Length; i++)
            {
                filled[i] = filler[i]; 
            }
            return filled; 
        }
    }
}
