using GirlInTheForest.Models;
using System;

namespace GirlInTheForest
{
    delegate void St();

    class Event
    {
        public event St Step;

        public void OnStep()
        {
            Step?.Invoke();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Размерность леса: ");
            int mapSize = int.Parse(Console.ReadLine());

            Console.Write("Скорость девочки: ");
            int speed = int.Parse(Console.ReadLine());

            var random = new Random();

            Girl girl = new Girl(
                speed: speed,
                name: "Girl",
                abbreviation: '1');

            Parent father = new Parent(
                speed: 2 * speed,
                name: "Father",
                abbreviation: 'f');

            Parent mother = new Parent(
                speed: 2 * speed,
                name: "Mother",
                abbreviation: 'm');

            Parent grandMother = new Parent(
                speed: 2 * speed,
                name: "GrandMother",
                abbreviation: '+');

            Parent grandFather = new Parent(
                speed: 2 * speed,
                name: "GrandFather",
                abbreviation: '@');

            char[,] forestArray = new char[mapSize, mapSize];

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    forestArray[i, j] = '•';
                }
            }

            Forest forest = new Forest(mapSize);

            forest.AddToLostInForest(girl);

            Event evn = new Event();

            evn.Step += girl.ChangeCoordGirl;

            evn.Step += mother.ChangeCoordParent;

            evn.Step += father.ChangeCoordParent;

            evn.Step += grandMother.ChangeCoordParent;

            Forest.NearLine += _girlSearched;

            Forest.Searched += _girlSearched;

            Forest.SearchedGirls += _girlSearched;

            bool direction = true;

            bool _girl1 = true;

            while (direction)
            {
                if (direction)
                {
                    forestArray[girl.XPos, girl.YPos] = girl.Abbreviation;

                    forestArray[father.XPos, father.YPos] = father.Abbreviation;

                    forestArray[mother.XPos, mother.YPos] = mother.Abbreviation;

                    forestArray[grandMother.XPos, grandMother.YPos] = grandMother.Abbreviation;

                    forestArray[grandFather.XPos, grandFather.YPos] = grandFather.Abbreviation;

                    for (int i = 0; i < mapSize; i++)
                    {
                        for (int j = 0; j < mapSize; j++)
                        {
                            Console.Write(forestArray[i, j] + " ");
                        }

                        Console.WriteLine();
                    }

                    _girl1 = forest.IsSavedByOutOfMap(girl);

                    forest.IsSavedByParents(father);

                    forest.IsSavedByParents(mother);

                    forest.IsSavedByParents(grandMother);

                    forest.IsSavedByParents(grandFather);

                    if (!_girl1)
                    {
                        evn.Step -= girl.ChangeCoordGirl;
                    }

                    direction = forest.FindGirls();

                    if (!direction)
                    {
                        break;
                    }
                }

                Console.ReadKey();

                Console.Clear();

                forestArray[girl.XPos, girl.YPos] = '.';

                forestArray[father.XPos, father.YPos] = '.';

                forestArray[mother.XPos, mother.YPos] = '.';

                forestArray[grandMother.XPos, grandMother.YPos] = '.';

                forestArray[grandFather.XPos, grandFather.YPos] = '.';

                evn.OnStep();
            }
        }

        static void _girlSearched(string messege)
        {
            Console.WriteLine(messege);
        }
    }
}
