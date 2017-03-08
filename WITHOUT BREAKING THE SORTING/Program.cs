using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITHOUT_BREAKING_THE_SORTING
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task
            //Suppose two sequences of numbers are given.All numbers in the first sequence are sorted.
            //For each element from the second sequence print the index where element must be inserted into the first sequence without breaking the sorting.
            //In case when element b of the second sequence is in first sequence, the lowest index for element b, wich does not break sorting must be printed. 
            //The indexes start from 0.The input data are integer numbers.All numbers are separated by spaces. First number n is the number of members of the first sequence.
            //Next n numbers are elements of the first sequence.Next number m is the number of members of the second sequence.Next m numbers are elements of the second sequence.
            //Input data guarantee that the inputs and the result will be less than 2 147 483 647.
            //Output data must be number of elements of the second sequence and indexes for each element of the second sequence,
            //where they must be inserted into the first sequence without breaking the sorting.
            //All numbers must be separated by spaces.
            #endregion

            string sourceSequence = "7 1 2 3 4 4 4 5 3 4 1 6"; //test string 

            int[] separatedSequence = GetIntArrayFromString(sourceSequence);

            int firstsecnumber = separatedSequence[0]; // 7. Number of elements in 1 sequence
            int secondsecnumber = separatedSequence[firstsecnumber + 1]; //3. Number of elements in 2 sequence

            string output = secondsecnumber.ToString() + " "; // Initialize output string

            var firstList = separatedSequence.Skip(1).Take(firstsecnumber).ToList(); // Get 1 sequence via Linq
            var secondList = separatedSequence.Skip(firstsecnumber + 2).Take(secondsecnumber).ToList(); // Get 2 sequence via Linq


            foreach (int el in secondList)
            {
                output += IndexSearch(firstList, el) + " "; // Get indexes
            }
            output = output.TrimEnd(' ');

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

        // Using binary search 
        public static int IndexSearch(List<int> arr, int x)
        {
            int first = 0; //first el number
            int last = arr.Count;


            while (first < last)
            {
                int mid = first + (last - first) / 2;

                if (x <= arr[mid])
                    last = mid;
                else
                    first = mid + 1;
            }


            if (arr[0] > x) // el is smaller than first element of array
            {
                return first;
            }
            else if (arr[arr.Count - 1] < x) // el is bigger than last element of array
            {
                return last;
            }
            else if (arr[last] == x) //element found
                return last;
            else // element not found but in scope of array
                return last;
        }
    }
}
