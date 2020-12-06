namespace AdventOfCode2020.Model
{
    public class Group
    {
        public int Passengers { get; private set; }
        public int UniqueYesAnswers { get; private set; }

        public Group(int passengers, int uniqueYesAnswers)
        {
            Passengers = passengers;
            UniqueYesAnswers = uniqueYesAnswers;
        }
    }
}