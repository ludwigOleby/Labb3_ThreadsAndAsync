using System;
using System.Collections.Generic;
using System.Threading;

namespace labb3
{

    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("********Välkommen till biltävlingen!********");
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent under tävlingen för att se tävlingens status...");
            Console.WriteLine("Tryck på valfri tangent för att starta...");
            Console.ReadKey();
            Console.WriteLine("3....");
            Thread.Sleep(1000);
            Console.WriteLine("2....");
            Thread.Sleep(1000);
            Console.WriteLine("1....");
            Thread.Sleep(1000);
            int distance = 10000;
            int carDistance = 0;


            Bil b1 = new Bil() { Name = "Ludwig", Speed = 120 };
            Bil b2 = new Bil() { Name = "Syntax error", Speed = 120 };



            Thread t1 = new Thread(() =>
            {
                race(b1, distance);
                winCondition(b1, b2);
            });
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                race(b2, distance);
            });
            t2.Start();

            Thread statusThread = new Thread(() =>
            {
                Bil.raceStatus(b1, b2, distance, carDistance);
            });
            statusThread.Start();


        }

        public static void race(Bil bil, int distance)  // Metod för race loop
        {
            DateTime startTime = DateTime.Now;


            Console.WriteLine(bil.Name + " startar!");
            while (bil.carDistance <= distance)
            {

                bil.carDistance = bil.carDistance + bil.Speed;
                double raceDuration = (DateTime.Now - startTime).Seconds;
                Thread.Sleep(1000);

                if (raceDuration == 30 || raceDuration == 00)
                {
                    randomEvent(bil);
                }

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(bil.Name + " Gick i mål!");
            Console.ForegroundColor = ConsoleColor.Gray;
            bil.GoalTime = DateTime.Now - startTime;


        }
        public static void randomEvent(Bil bil) // Metod för händelserna som kan inträffa
        {
            Random eventNum = new Random();
            int num = eventNum.Next(0, 50);


            if (num == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(bil.Name + " Behöver tanka och stannar i 30 sekunder!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(30000);
            }
            if (num == 2 || num == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(bil.Name + " Behöver byta däck och stannar i 20 sekunder!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(20000);
            }
            if (num >= 4 && num <= 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(bil.Name + " Behöver tvätta vindrutan och stannar i 10 sekunder!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(10000);
            }
            if (num >= 9 && num <= 18)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(bil.Name + " Har fel på motorn! hastigheten sänks med 1km/h!");
                Console.ForegroundColor = ConsoleColor.Gray;
                bil.Speed = bil.Speed - 1;
            }
            if (num > 18 && num < 50)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ingen händelse inträffade för " + bil.Name);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public static void winCondition(Bil b1, Bil b2)
        {
            int x = b1.GoalTime.CompareTo(b2.GoalTime);
            int y = b2.GoalTime.CompareTo(b1.GoalTime);

            if (x == -1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(b1.Name + " Vann racet!");
            }
            if (y == -1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(b2.Name + " Vann racet!");
            }
        }







    }
}
