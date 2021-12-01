using System;

namespace GirlInTheForest.Models
{
    class Girl : IPerson
    {
        public int XPos { get; set; }

        public int YPos { get; set; }

        public int Speed { get; set; }

        public char Abbreviation { get; set; }

        private int Size { get; set; } //Remove

        public string Name { get; set; }

        public Girl(
            int speed,
            string name,
            char abbreviation)
        {
            Speed = speed;

            Abbreviation = abbreviation;

            Name = name;
        }

        public void ChangeCoordGirl()
        {
            var rnd = new Random();

            int d = rnd.Next(-1, 1);

            XPos = Math.Abs(XPos + (d * Speed));

            YPos = Math.Abs(YPos + (d * Speed));

            if (XPos > Size - 1)
            {
                XPos /= 2;
            }

            else if (YPos > Size - 1)
            {
                YPos /= 2;
            }
        }
    }
}
