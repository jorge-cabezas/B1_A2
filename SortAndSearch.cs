using System;
using System.Runtime.Serialization;
namespace SortAndSearch
{
    class SortAndSearch
    {
        static void Main()
        {
            const string MsgArrayGenerated = "Random array generated: ";
            const string MsgSearch = "Insert a natural number to see if its in the list and how many times: ";
            const string MsgNotFound = "\n{0} is not in the random list";
            const string MsgFound = "\n{0} appears {1} times";
            const string MsgSorted = "Sorted array: ";

            const int MinValue = 1,MaxValue = 9;

            // Exceptions
            const string MsgFormatException = "\n == ERROR ==\nMust enter a natural number";
            const string MsgOverflow = "\n == ERROR ==\nNumber to big";
            const string MsgNull = "\n == ERROR ==\nEmpty input, please select between {0} and {1}";
            const string MsgOutOfRange = "\n == ERROR ==\nThe option must be between {0} and {1}";
            
            int[] numList = new int[10], sortedNums = new int[10];
            int searchNum,counter = 0;
            bool validInput= false,found = false;
            
            Random rnd = new Random();

            // Program

            Console.WriteLine(MsgArrayGenerated);
            for (int i = 0; i < numList.Length; i++)
            {
                numList[i] = rnd.Next(MinValue,MaxValue+1);
                Console.Write(numList[i] + " ");
            }

            Console.WriteLine();
            // Array.Sort(numList); | Bubble-Sort 
            for (int i = 0; i < numList.Length-1; i++)
            {
                for (int j = 0; j < numList.Length-1-i; j++)
                {
                    if (numList[j] > numList[j+1])
                    {
                        int aux = numList[j];
                        numList[j] = numList[j+1];;
                        numList[j+1] = aux;
                    }
                }
            }

            do
            {
                Console.WriteLine(MsgSearch);

                try
                {
                    searchNum = int.Parse(Console.ReadLine());

                    if (searchNum < MinValue || searchNum > MaxValue)
                    {
                        throw new ArgumentOutOfRangeException(nameof(searchNum));
                    }

                    validInput = true;

                    for (int i = 0; i < numList.Length; i++)
                    {
                        if (searchNum == numList[i])
                        {
                            found = true;
                            counter++;
                        }
                    }

                    if (found)
                    {
                        Console.WriteLine(MsgFound,searchNum,counter);
                    }
                    else
                    {
                        Console.WriteLine(MsgNotFound,searchNum);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(MsgFormatException);
                }
                catch (OverflowException)
                {
                    Console.WriteLine(MsgOverflow);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine(MsgNull, MinValue, MaxValue);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine(MsgOutOfRange, MinValue, MaxValue);
                }                
            } while (!validInput);

            
            Console.Write(MsgSorted);
            foreach (int num in numList)
            {
                Console.Write(num + " ");
            }

        }
    }
}

