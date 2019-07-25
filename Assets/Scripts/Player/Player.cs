namespace UseYourGifs
{
    public class Player
    {
        public string Name;
        public int Score;

        public Player(string name)
        {
            Name = name;
        }

        public Player(string name, int score) : this(name)
        {
            Score = score;
        }
    }
}