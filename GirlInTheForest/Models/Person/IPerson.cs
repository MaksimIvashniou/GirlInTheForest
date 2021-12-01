namespace GirlInTheForest.Models
{
    public interface IPerson
    {
        char Abbreviation { get; set; }

        string Name { get; set; }

        int XPos { get; set; }

        int YPos { get; set; }

        int Speed { get; set; }
    }
}
