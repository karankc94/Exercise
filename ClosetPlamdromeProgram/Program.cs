using System;

namespace ClosetPlamdromeProgram
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    int i = 1;
        //    int j = 0;
        //    string input;
        //    int.TryParse(Console.ReadLine(), out j);
        //    do
        //    {
        //        input = Console.ReadLine();
        //        Console.WriteLine(new Palindrome().ClosestPalindrom(input));
        //        i++;
        //    } while (i <= j);
        //    Console.ReadLine();

        //}

    }
    public class Palindrome
    {
        public string ClosestPalindrom(string n)
        {
            int order = (int)Math.Pow(10, n.Length / 2);
            long original = long.Parse(n);
            long mirrored = Mirror(original);

            long larger = Mirror((original / order) * order + order + 1);
            long smaller = Mirror((original / order) * order - 1);

            if (mirrored >= original)
            {
                larger = Math.Min(mirrored, larger);
            }
            else if (mirrored < original)
            {
                smaller = Math.Max(mirrored, smaller);
            }

            return Convert.ToString(original - smaller <= larger - original ? smaller : larger);
        }

        public long Mirror(long pStr)
        {
            char[] charArray = pStr.ToString().ToCharArray();
            int start = 0;
            int end = charArray.Length - 1;
            while (start < end)
            {
                charArray[end--] = charArray[start++];
            }
            return long.Parse(new string(charArray));
        }
    }
}
