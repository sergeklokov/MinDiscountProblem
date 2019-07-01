using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinDiscount
{
    class Program
    {
        /// <summary>
        /// This is Minimum Discount Problem
        /// or Final Discounted Price
        /// see attached images with exact description of the task
        ///         
        /// Demoed by Serge Klokov in 2019
        /// 
        /// Note: I been sent this problem by Quicken Loan recruter on hackerrank.com
        /// 
        /// Some useful URL:
        /// https://leetcode.com/discuss/interview-question/algorithms/124783/coursera-hackerrank-question-min-discount
        /// https://leetcode.com/discuss/interview-question/algorithms/124783/coursera-hackerrank-question-min-discount/126008
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Tests
            //var prices = new List<int>() { 2, 3, 1, 2, 4, 2 };  // correct 
            //var prices = new List<int>() { 5, 1, 3, 4, 6, 2 };
            //var prices = new List<int>() { 1, 3, 3, 2, 5 };  // correct 
            //var prices = new List<int>() { 5, 1, 3, 4, 6, 2 };
            var prices = new List<int>() { 2147483645, 1, 3, 4, 6, 2147483647 };  // overflow test

            Print(prices);

            finalPrice(prices);

            Print(prices);

            Console.WriteLine();
            Console.WriteLine("Done. Please press any key to exit..");
            Console.ReadKey();
        }

        private static void Print(List<int> prices)
        {
            Console.WriteLine();

            for (int i = 0; i < prices.Count; i++)
            {
                Console.Write(prices[i] + ", ");
            }
            
            Console.WriteLine("        Sum = " + Sum(prices));
        }


        private static int findFirstLowerOrEqual(int startPos, int currentPrice, List<int> prices) {

            var minPrice = currentPrice;
            bool isFound = false;
            for (int i = startPos; i < prices.Count; i++)
            {
                if (prices[i] <= minPrice) {
                    minPrice = prices[i];
                    isFound = true;
                    break;
                }
            }

            if (isFound)
                return minPrice;

            return 0; // not found
        }

        private static void finalPrice(List<int> prices)
        {
            var notDiscountedIndices = new List<int>();
            for (int i = 0; i < prices.Count; i++)
            {
                var discount = findFirstLowerOrEqual(i + 1, prices[i], prices);
                if (discount == 0)
                    notDiscountedIndices.Add(i);
                
                prices[i] = prices[i] - discount;
            }

            //Console.WriteLine(prices.Sum());  // LINQ have overflow exception ???
            Console.WriteLine(Sum(prices));  // let's don't use LINQ

            for (int i = 0; i < notDiscountedIndices.Count; i++)
                Console.Write(notDiscountedIndices[i] + " ");
        }

        private static long Sum(List<int> prices) {
            long s = 0;

            for (int i = 0; i < prices.Count(); i++)
            {
                s += prices[i];
            }

            return s;
        }
    }
}
