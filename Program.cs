using System;

namespace HelloWorld;

internal class Program
{
    enum Cash{
        Twenty,
        Ten,
        Five,
        One,
        Quarter,
        Dime,
        Nickle,
        Penny
    }
    static void Main(string[] args)
    {
        var rand = new Random();

        for (int ctr = 0; ctr <= 4; ctr++)
        {
            // moneygiven random between 0 to 100 dollars including cents.
            int cashInCents = rand.Next(10000);

            // Now we determine how an random charge value.
            int chargeInCents = rand.Next(cashInCents);

            int change = cashInCents - chargeInCents;

            Console.Write("Cash${0} - Charge${1} = Change${2} ", cashInCents, chargeInCents, change);
            int[] values = [2000, 1000, 500, 100, 25, 10, 5, 1];
            int[] changeValues = [];
            foreach( int cashValue in values)
            {
                int cashReturn = getCashReturn(change, cashValue);
                change -= cashReturn * cashValue;
                Array.Resize(ref changeValues, changeValues.Length + 1);
                changeValues[changeValues.GetUpperBound(0)] = cashReturn;
            }

            foreach (var item in Enum.GetValues(typeof(Cash)))
            {
                var name = item.ToString();
                var value = (int)item;
                Console.Write("{0} = {1} ,", name, changeValues[value]);
            }
            Console.WriteLine();


        }
    }

    private static int getCashReturn(float change, float cashValue)
    {
            if (change < cashValue)
            {
                return 0;
            }
            return (int)Math.Floor(change / cashValue);
    }
}