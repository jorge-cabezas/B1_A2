using System;
namespace ReverseArray
{
    class ReverseArray
    {
        static void Main()
        {
            const string MsgArrayGenerated = "Random array generated: ";
            const string MsgReversed = "\nReversed array: ";

            const int MinValue = 1,MaxValue = 9;

            Random rnd = new Random();

            int[] numList = new int[10];
            
            Console.WriteLine(MsgArrayGenerated);
            for (int i = 0; i < numList.Length; i++)
            {
                numList[i] = rnd.Next(MinValue,MaxValue+1);
                Console.Write(numList[i] + " ");
            }

            Console.WriteLine(MsgReversed);
            for (int i = numList.Length - 1; i >= 0 ; i--)
            {
                Console.Write(numList[i] + " ");
            }
        }
    }
}

