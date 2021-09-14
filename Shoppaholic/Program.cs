using System;
using System.Collections.Generic;

namespace Shoppaholic
{
    class Program
    {
        static void Main(string[] args)
        {
            int itemsNumber = Convert.ToInt32(Console.ReadLine());
            var itemPriceInput = Console.ReadLine().Split(' ');
            List<long> allPrices = new List<long>();
            List<long> sortedPrices = new List<long>();

            for (int i = 0; i < itemsNumber; i++)
            {
                long itemPrice = (long)Convert.ToInt32(itemPriceInput[i]);
                allPrices.Add(itemPrice);
            }

            sortedPrices = allPrices.OrderByDescending(i => i).ToList();
            long maxDiscount = 0;

            for (int i = 0; i < sortedPrices.Count; i++)
            {
                if (i % 3 == 2)
                {
                    maxDiscount += sortedPrices[i];
                }
            }

            Console.WriteLine(maxDiscount);
        }
    }
}
