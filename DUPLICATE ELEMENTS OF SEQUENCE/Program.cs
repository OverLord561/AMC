using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPLICATE_ELEMENTS_OF_SEQUENCE
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task
            //Suppose two sequences of numbers A[0], A[1], ... , A[n] and B[0], B[1], ..., B[m] are given. 
            //All elements in sequence B are different. 
            //For all i, print element A[i] one time if i is not a member of sequence B, and two times if i is a member of sequence B. 
            //The input data are positive integer numbers - the elements of the sequences. All numbers are separated by spaces.
            //The number of members of the sequences isn't known in advance. First numbers are elements of sequence A.
            //In the end of the sequence A there is a number -1. -1 is not a member of the sequence A or the sequence B.
            //Next numbers are elements of the sequence B. In the end of the sequence B there is a number -1.
            //-1 is not a member of the sequence B. Input data guarantee that the inputs and the result will be less than 2 147 483 647.
            //Output data must be the elements of the sequence A obtained after using the described operations, separated by spaces.
            //Sequence must end with number -1.
            #endregion

            string output = "";
            string sourceSequence = "1 2 3 4 5 6 -1 3 4 -1"; //test string
            int[] separatedSequence = GetIntArrayFromString(sourceSequence);

            var separatedSequenceList = separatedSequence.ToList();
            int firstSequenceLength = separatedSequenceList.IndexOf(-1); //Get first sequence length

            var firstSequenceList = separatedSequence.Take(firstSequenceLength).ToList(); //Get 1 sequence via Linq

            var secondSequenceList = separatedSequence.Skip(firstSequenceLength + 1)
                                                      .Take(separatedSequence.Length - firstSequenceLength - 2)
                                                      .ToList(); //Get 2 sequence via Linq


            foreach (int el in firstSequenceList)
            {
                output += el + " ";
                if (secondSequenceList.IndexOf(el) != -1)
                {
                    output += el + " ";
                }

            }
            output += "-1";

            Console.WriteLine(output);
            Console.ReadLine();

        }
        // Convert string sequence of numbers into int array 
        public static int[] GetIntArrayFromString(string sourceString)
        {
            string[] separatedNumbers = sourceString.Split(' ');
            int[] separatedSequence = Array.ConvertAll<string, int>(separatedNumbers, int.Parse); //Convert string array into int array
            return separatedSequence;
        }

    }
}
