using System;
using System.Collections.Generic;
using System.Linq;

namespace bdd.workshop.calculator
{
    public static class Operator
    {
        public static void CommandManager(string command,out int a,out int b, out string operation)
        {

            var parts = command.Split(" ");
            if (parts.Count() != 3)
            {
                throw new InvalidOperationException("Ensure you're entering two integers and the operator split by blank space, in example, 3 + 4");
            }
            if (!int.TryParse(parts[0], out a))
            {
                throw new InvalidOperationException("First entity must be an integer");
            }
            if (!int.TryParse(parts[2], out b))
            {
                throw new InvalidOperationException("Last entity must be an integer");
            }
            operation = parts[1];
        }
        public static int Add(int a, int b) => a + b;

        public static int Multiply(int a, int b) => a * b;

        public static double Divide(int a, int b) => ((double)a) / ((double)b);

        public static int Substract(int a, int b) => a - b;

        public static double Sqrt(int a, int b) => Math.Pow(a, 1/b);

        public static PrimeNumberInfo IsPrimeNumber(int number)
        {
            var result = number == 0 ? PrimeNumberInfo.Unknown : number == 1 ? PrimeNumberInfo.No : PrimeNumberInfo.Yes ;            
            for (int i = 2; i < number; i++)
            {
                result = PrimeNumberInfo.Yes;
                if (number % i == 0)
                {
                    result = PrimeNumberInfo.No;
                    break;
                }
            }
            return result;
        }
    }
}
