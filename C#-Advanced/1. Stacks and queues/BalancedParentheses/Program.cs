using System;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string given = Console.ReadLine();

            char[] input = given.ToCharArray();

            int counter = 0;

            for (int i = 0; i < input.Length/2; i++)
            {
                if (input[i] == '{')
                {
                    if (input[input.Length - i - 1] == '}')
                    {
                        counter++;
                    }

                }

                else if (input[i] == '[')
                {
                    if (input[input.Length - i - 1] == ']')
                    {
                        counter++;
                    }

                }

                else if (input[i] == '(')
                {
                    if (input[input.Length - i - 1] == ')')
                    {
                        counter++;
                    }

                }
            }

            if (counter == input.Length/2)
            {
                Console.WriteLine("YES");
            }

            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
