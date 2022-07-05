using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int counter = 0;

            bool noCrash = false;

            int greenLightLeft = greenLight;

            string command = Console.ReadLine();

            while (command != "END")
            {
                cars.Enqueue(command);
                command = Console.ReadLine();
            }


            foreach (var car in cars)
            {
                int length = car.Length;

                if (car != "green")
                {
                    if (length <= greenLightLeft + freeWindow)
                    {
                        counter++;
                        greenLightLeft -= length;
                    }

                    else if (greenLightLeft < 0)
                    {

                    }

                    else
                    {
                        noCrash = true;
                        char symbol = car[greenLightLeft + freeWindow ];
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{car} was hit at {symbol}.");
                        break;
                    }

                }

                if (car == "green")
                {
                    greenLightLeft = greenLight;
                }
            }

            if (noCrash == false)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{counter} total cars passed the crossroads.");
            }


        }
    }
}
