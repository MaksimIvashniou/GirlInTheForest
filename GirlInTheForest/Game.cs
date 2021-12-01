using GirlInTheForest.Models;
using System;

namespace GirlInTheForest
{
    enum Direction
    {
        Vertical,
        Horisontal,
    }

    public static class Game
    {
        public static void Init()
        {
            Console.Write("Размерность леса: ");

            int mapSize = int.Parse(Console.ReadLine());

            Map map = new Map(mapSize);

            Console.Write("Скорость девочки: ");

            int speed = int.Parse(Console.ReadLine());

            IPerson girl = new Girl(
                speed: speed,
                name: "Girl",
                abbreviation: '1');

            SetFirstPersonPosition(girl);
        }

        public static void SetFirstPersonPosition(IPerson person)
        {
            var random = new Random();

            person.XPos = random.Next();

            person.YPos = random.Next();
        }

        public static void ChangePosition(IPerson person)
        {
            var random = new Random();

            Direction dir = (Direction)(int)random.Next(0, 1);

            int value = random.Next(-1, 1);

            switch (dir)
            {
                case Direction.Vertical:

                    person.YPos += value * person.Speed;

                    if (person.YPos > 20)
                    {
                        person.YPos = 20;
                    }

                    if (person.YPos < 0)
                    {
                        person.YPos = 0;
                    }

                    break;

                case Direction.Horisontal:

                    person.XPos += value * person.Speed;

                    if (person.XPos > 20)
                    {
                        person.XPos = 20;
                    }

                    if (person.XPos < 0)
                    {
                        person.XPos = 0;
                    }

                    break;
            }
        }
    }
}
