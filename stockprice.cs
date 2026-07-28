using System;

class Program
{
    static void Main()
    {
        int[] stockPrices = { 4, 2, 5, 1, 7, 0 };

        var result = MaxProfitDetails(stockPrices);

        Console.WriteLine($"Buy Price: {result.buy}");
        Console.WriteLine($"Sell Price: {result.sell}");
        Console.WriteLine($"Max Profit: {result.maxProfit}");
    }

    static (int buy, int sell, int maxProfit) MaxProfitDetails(int[] price)
    {
        int minPrice = price[0];
        int buy = price[0];
        int sell = price[0];
        int maxProfit = 0;

        for (int i = 1; i < price.Length; i++)
        {
            if (price[i] < minPrice)
            {
                minPrice = price[i];
            }
            else if (price[i] - minPrice > maxProfit)
            {
                maxProfit = price[i] - minPrice;
                buy = minPrice;
                sell = price[i];
            }
        }

        return (buy, sell, maxProfit);
    }
}