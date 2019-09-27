using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ulong> primes = new List<ulong>() { 5, 7 }; //prime list with first two primes (other than 2 & 3) DO NOT REMOVE!!!!!!!!!!!!!! 5 and 7 from list. 
            List<ulong> buddies = new List<ulong>() { 6 }; //buddy number list with first buddy already contained. nothing will break if 6 removed but will be missing from final result

            //how high you want to have the list of numbers
            ulong myLength = 100000000;         //Due to limitations in how lists are called, the max number that can be put as myLength is currently approximately 8 billion

            DateTime startTime = DateTime.Now; //check for how long this program takes to run without me needing to time it

            for (ulong i = 2; i <= myLength; i++) //DO NOT CHANGE INTITAL i!!!!!!! If i is lowered to 1, this loop has the serious potential to break depending on changes made to on the while conditions
            {
                bool minusOne = true;
                bool plusOne = true;
                int p = 0;
                bool escapeWhile = true;

                while (primes[p] * primes[p] <= 6*i +1 && escapeWhile)
                {
                    if (6*i % primes[p] == 1)
                    {
                        minusOne = false;
                        escapeWhile = false;
                    }
                    p++;
                }

                p = 0; //reset p and exit
                escapeWhile = true;

                while (primes[p] * primes[p] <= 6 * i + 1 && escapeWhile)
                {
                    if (6 * i % primes[p] == (primes[p]-1))
                    {
                        plusOne = false;
                        escapeWhile = false;
                    }
                    p++;
                }

                //expand primes list
                if (minusOne)
                {
                    primes.Add(6 * i - 1);
                }
                if (plusOne)
                {
                    primes.Add(6 * i + 1);
                }

                //expand buddies
                if (minusOne && plusOne)
                {
                    buddies.Add(6 * i);
                }

                //Console.WriteLine("progress report: " + 6*i);              //if you think it's not working or just want an onscreen update of where the program currently is at, un-comment this line
            }
            Console.Beep(); //just so I can code and know when this is done running
            Console.WriteLine("Computation complete. Computation time is : " + (DateTime.Now - startTime) + "\nPress enter to obtain list"); //speed checking line; compare with first line produced by program to check time it took. 
            Console.ReadLine();

            foreach (ulong buddy in buddies)
            {
                Console.WriteLine(buddy);
            }
            Console.WriteLine("Number of primes less than 1.8 billion: " + primes.Count);
            Console.WriteLine("Number of twin primes less than 1.8 billion: " +buddies.Count);
        }
    }
}
