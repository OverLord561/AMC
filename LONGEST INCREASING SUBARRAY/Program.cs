using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LONGEST_INCREASING_SUBARRAY
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task
            //Suppose a sequence of numbers is given.Find the longest increasing subsequence in a given sequence which consists of contiguous elements.
            //The input data are integer numbers. All numbers are separated by spaces.
            //First number is number of members of the sequence.Next numbers are elements of the sequence.
            //Input data guarantees that the inputs and the result will be less than 2 147 483 647.
            //Output data must be the number of members of the longest increasing subsequence of contiguous elements of the sequence.
            #endregion


            string sourceSequence = "5 2 1 5 3 4"; //test string 
                                                   //string sourceSequence = "18 2 3 4 5 1 5 3 4 5 6 1 5 6 7 8";
            string[] separatedValues = sourceSequence.Split(' ');
            int[] separatedSequence = Array.ConvertAll<string, int>(separatedValues, int.Parse);

            Console.WriteLine(MaxLength(separatedSequence));
            Console.ReadLine();

        }

        //Get max length of increasing subsequence
        static int MaxLength(int[] sequence)
        {
            int count = 1;
            int maxCount = 1;

            for (int i = 1; i < sequence.Length - 1; i++)
            {

                if (sequence[i] - sequence[i + 1] == -1)
                {
                    count++;

                    if (maxCount < count)
                    {
                        maxCount = count; //update max length count of increasing subsequence
                    }
                }
                else
                {
                    count = 1; //reset the counter
                }
            }

            return maxCount;

        }


    }
}
