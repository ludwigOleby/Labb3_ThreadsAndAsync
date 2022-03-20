using System;
using System.Collections.Generic;
using System.Text;

namespace labb3
{
    public class Bil
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public TimeSpan GoalTime { get; set; }
        public int carDistance { get; set; }


        public static void raceStatus(Bil b1, Bil b2, int distance, int carDistance)
        {
            while (true)
            {
                Console.ReadKey();
                Console.WriteLine(b1.Name + " Kör i hastighet " + b1.Speed + " km/h och har " + (distance - b1.carDistance) + " km kvar till mål!");
                Console.WriteLine(b2.Name + " Kör i hastighet " + b2.Speed + " km/h och har " + (distance - b2.carDistance) + " km kvar till mål!");
            }
        }

    }
}
