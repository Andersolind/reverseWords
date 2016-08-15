using System;
using System.Linq;

namespace Canada
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string questionOne = "I would really like to work at your company";
            var c = new Common();
            var getReversedString = c.ReverseString(questionOne);
            //Question 2
            var getValue = c.GetNumberOfPrime(45);
            //Question 3 
            var numberOne = "sindy";
            var numberTwo = "Anderson";
            //Question 3
            var getResult = c.OrderByNSq(numberOne.ToCharArray(), numberTwo.ToCharArray());
            var getResult2 = c.OrderByN(numberOne.ToCharArray(), numberTwo.ToCharArray());
        }
    }

    internal interface ICommon
    {
        string ReverseString(string input);
        int GetNumberOfPrime(int start);
        char[] OrderByNSq(char[] a, char[] b);

        char[] OrderByN(char[] a, char[] b);
    }

    public class Common : ICommon
    {
        public string ReverseString(string input)
        {
            //Convert the sting into a character set
            var inputChars = input.ToCharArray();
            //Lets reverse it
            Array.Reverse(inputChars);
            //Return your value
            return new string(inputChars);
        }

        public int GetNumberOfPrime(int start)
        {
            var isPrime = 0;
            for (var j = 2; j <= start; j++)
            {
                for (var k = 2; k <= start; k++)
                {
                    if (j == k)
                    {
                        isPrime++;
                        break;
                    }
                    if (j%k == 0)
                    {
                        break;
                    }
                }
            }
            return isPrime;
        }

        public char[] OrderByNSq(char[] a, char[] b)
        {
            var ret = "";

            foreach (var t in a)
                if (b.Any(t1 => t == t1))
                {
                    if (ret.IndexOf(t) == -1)
                        ret += t;
                }

            return ret.ToCharArray();
        }

        public char[] OrderByN(char[] a, char[] b)
        {
            var ret = "";
            var flags = new int[256];

            foreach (var t in b)
                flags[t] = 1;

            foreach (var t in a)
                if (flags[t] == 1)
                {
                    ret += t;
                    flags[t] = 0;
                }
            return ret.ToCharArray();
        }
    }
}