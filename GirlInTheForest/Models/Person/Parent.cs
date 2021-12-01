using System;

namespace GirlInTheForest.Models
{
    class Parent : IPerson
    {
        public int XPos { get; set; } //TO REMOVE

        public int YPos { get; set; } //TO REMOVE

        public int Speed { get; set; }

        public string Name { get; set; }

        public char Abbreviation { get; set; }

        private int Size { get; set; } //TO REMOVE

        public Parent(
            int speed,
            string name,
            char abbreviation)
        {
            Speed = speed;

            Abbreviation = abbreviation;

            Name = name;
        }

        public void ChangeCoordParent()
        {
            var random = new Random();

            switch (random.Next(1, 5))

            {
                case 1:
                    YPos -= 2;

                    if (YPos < 0)
                    {
                        YPos = 0;
                    }
                    break;

                case 2:
                    XPos -= 2;

                    if (XPos < 0)
                    {
                        XPos = 0;
                    }
                    break;

                case 3:
                    XPos += 2;

                    if (XPos >= Size)
                    {
                        XPos = Size - 1;
                    }
                    break;

                case 4:
                    YPos += 2;

                    if (YPos >= Size)
                    {
                        YPos = Size - 1;
                    }
                    break;
            }
        }
    }
}
