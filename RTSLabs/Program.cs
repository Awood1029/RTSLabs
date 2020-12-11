using System;

namespace RTSLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Answer to questions 3 provided in text file

            // Problem 1
            Console.WriteLine(AboveAndBelowProblem(new int[] { 5, 4, 2, 6, 34, 1 }, 5));
            Console.WriteLine(AboveAndBelowProblem(new int[] { 1, 5, 2, 1, 10 }, 6));
            Console.WriteLine(AboveAndBelowProblem(new int[] { 0, -10, 10 }, -5));
            Console.WriteLine(AboveAndBelowProblem(new int[] { }, 5));

            // Problem 2
            Console.WriteLine(RotateStringProblem("MyString", 2));
            Console.WriteLine(RotateStringProblem("MyString", 10));
            Console.WriteLine(RotateStringProblem("Rotate", 10));
            Console.WriteLine(RotateStringProblem("Rotate", 0));
            Console.WriteLine(RotateStringProblem("M", 2));
            Console.WriteLine(RotateStringProblem("", 2));
        }

        // Print the number of integers in an array that are above the given input 
        // and the number that are below, e.g. for the array [1, 5, 2, 1, 10] with input 6,
        // print “above: 1, below: 4”."
        public static string AboveAndBelowProblem(int[] arr, int targetNum)
        {
            if (arr.Length == 0)
            {
                return "Above: 0, Below: 0:";
            }

            int belowCount = 0;
            int aboveCount = 0;

            foreach (var x in arr)
            {
                if (x == targetNum)
                {
                    continue;
                }
                else if (x < targetNum)
                {
                    belowCount++;
                }
                else
                {
                    aboveCount++;
                }
            }

            return String.Format("Above: {0}, Below: {1}", aboveCount, belowCount);
        }

        // Rotate the characters in a string by a given input and have the overflow appear
        // at the beginning, e.g. “MyString” rotated by 2 is “ngMyStri”.
        public static string RotateStringProblem(string str, int rotateCount)
        {

            if (rotateCount == 0 || rotateCount == str.Length
               || str.Length <= 1)
            {
                return str;
            }


            char[] charArray = str.ToCharArray();

            // It's important to note that if rotateCount is larger than charArray, we don't actually need to rotate that many times.
            // Instead we will rotate the remainder.
            // Example: charArray.Length = 6, rotateCount = 10. We only need to rotate 4 times.

            rotateCount %= charArray.Length;

            // rotateCount = (10 % charArray.Length) = 4, str = "rotate"
            // [r,o,t,a,t,e] -> [e,t,a,t,o,r]
            Reverse(charArray, 0, charArray.Length - 1);
            // [e,t,a,t,o,r] -> [t,a,t,e,o,r]
            Reverse(charArray, 0, rotateCount - 1);
            // [t,a,t,e,o,r] -> [t,a,t,e,r,o]
            Reverse(charArray, rotateCount, charArray.Length - 1);

            return new string(charArray);

        }

        public static void Reverse(char[] charArray, int start, int end)
        {
            while (start < end)
            {
                char temp = charArray[start];
                charArray[start] = charArray[end];
                charArray[end] = temp;
                start++;
                end--;
            }
        }
    }
}
