using System;
using System.Linq;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ");


            for (int i = 0; i < numbers.Length; i++)
            {
                bool isDifferentFromDigitPresent = numbers[i].Any(x => !char.IsDigit(x));

                if (isDifferentFromDigitPresent)
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                string number = numbers[i];


                if (number.Length == 7)
                {
                    StationaryPhone phone = new StationaryPhone(number);
                    Console.WriteLine(phone.AbilityToCall(number));
                }

                else if (number.Length == 10)
                {
                    
                    Smartphone phone = new Smartphone();
                    Console.WriteLine(phone.AbilityToCall(number));
                }

            }

            string[] websites = Console.ReadLine().Split(" ");

            for (int i = 0; i < websites.Length; i++)
            {
                try
                {
                    string website = websites[i];
                    Smartphone phone = new Smartphone();
                    Console.WriteLine(phone.AbilityToBrowse(website));
                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
