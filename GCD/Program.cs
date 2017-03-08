using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task
            //Given two positive numbers a and b.Find the greatest common divisor of a and b.
            //The input data is two positive integer numbers separated by spaces -number a and number b. 
            //Input data guarantee that all input numbers and the result will be less than 2 147 483 647.
            //Output data must be one integer number -the greatest common divisor of a and b.
            #endregion

            string sourceSequence = "24 18"; //test string 
            int[] separatedSequence = GetIntArrayFromString(sourceSequence);

            SortNumbers(ref separatedSequence); // To reduce the number of dividing
            GCD(separatedSequence);// My own method
            GCDInternet(separatedSequence);// Using the Internet           

            Console.ReadLine();

        }

        // Convert string sequence of numbers into int array 
        public static int[] GetIntArrayFromString(string sourceString)
        {
            string[] separatedNumbers = sourceString.Split(' ');
            int[] separatedSequence = Array.ConvertAll<string, int>(separatedNumbers, int.Parse); //Convert string array into int array
            return separatedSequence;
        }

        // My own method
        static void GCD(int[] numbers)
        {

            int first = numbers[0];
            int second = numbers[1];
            int count = 0;

            int maxNumber = 1;

            for (int i = first; i >= 1; i--)
            {
                count++;
                if (second % i == 0 && first % i == 0)
                {
                    maxNumber = i;
                    break;
                }
            }
            Console.WriteLine("My own result: {0}, comparing count: {1}", maxNumber, count);
        }

        static void SortNumbers(ref int[] numbers)
        {
            int first = numbers[0];
            int second = numbers[1];

            if (first > second)
            {
                int temp = second;
                numbers[1] = numbers[0];
                numbers[0] = temp;
            }

        }

        // Using the Internet
        static void GCDInternet(int[] numbers)
        {

            int a = numbers[0];
            int b = numbers[1];

            int Remainder;
            int count = 0;
            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
                count++;
            }

            Console.WriteLine("Internet result: {0}, comparing count: {1}", a, count);
        }
    }
}
