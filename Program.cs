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
        byte[] bytes = new byte[5];
        rand.NextBytes(bytes);
        Console.WriteLine("Five random byte values:");
        foreach(byte byteValue in bytes)
        {
            Console.Write("{0, 5}", byteValue);
        }
        Console.WriteLine();

        Console.WriteLine("Five random integers between 0 and 100:");
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
                //changeValues.push();
            }
            /*
            foreach (var name in Enum.GetNames(typeof(Cash)))
            {
                Console.WriteLine("{0} = ",name  );
            }

            foreach (var val in Enum.GetValues(typeof(Cash)))
            {
                Console.WriteLine((int)val);
            }*/

            foreach (var item in Enum.GetValues(typeof(Cash)))
            {
                var name = item.ToString();
                var value = (int)item;
                Console.Write("{0} = {1} ,", name, changeValues[value]);
            }
            Console.WriteLine();
            //            Console.WriteLine(changeValues[(int)Cash.One]);
            /* int cashValue;
             // Check if we give back $20
             cashValue = 2000;
             int TwentyDollars = getCashReturn(change, cashValue);
             change -= TwentyDollars * cashValue;
             // check if we give back $10
             cashValue = 1000;
             int TenDollars = getCashReturn(change, cashValue);
             change -= TenDollars * cashValue;
             // Check if we give back $5
             cashValue = 500;
             int FiveDollars = getCashReturn(change, cashValue);
             change -= FiveDollars * cashValue;
             // Check if we give back $1
             cashValue = 100;
             int OneDollars = getCashReturn(change, cashValue);
             change -= OneDollars * cashValue;

             // .25
             cashValue = 25;
             int Quarters = getCashReturn(change, cashValue);
             change -= Quarters * cashValue;

             // .10
             cashValue = 10;
             int Dimes = getCashReturn(change, cashValue);
             change -= Dimes * cashValue;

             // .5
             cashValue = 5;
             int Nickles = getCashReturn(change, cashValue);
             change -= Nickles * cashValue;

             // leftover value is cents.
             cashValue = 1;
             int Pennies = getCashReturn(change, cashValue);
             change -= Pennies * cashValue;

             Console.WriteLine("20$ = {0} 10$ = {1} $5 = {2} $1 = {3}", TwentyDollars, TenDollars, FiveDollars, OneDollars);
             Console.WriteLine(".25 = {0} .10 = {1} .05 = {2} .01 = {3}", Quarters, Dimes, Nickles, Pennies);*/

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