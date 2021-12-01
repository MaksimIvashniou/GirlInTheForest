namespace GirlInTheForest.Models
{
    class Map : IMap
    {
        public int Size { get; set; }

        const char defaultPoint = '•';

        private char[,] map;

        public char[,] GetMap()
        {
            return map;
        }

        public void SetMap(char[,] value)
        {
            map = value;

            SetDefaultMapValue(map);
        }

        public Map(int size)
        {
            Size = size;

            SetMap(new char[Size, Size]);
        }

        public static void SetDefaultMapValue(char[,] map)
        {
            for (int i = 0; i < map.GetUpperBound(0); i++)
            {
                for (int j = 0; j < map.GetUpperBound(1); j++)
                {
                    map[i, j] = defaultPoint;
                }
            }
        }

        public char GetMapValue(int i, int j)
        {
            return map[i, j];
        }
    }
}
