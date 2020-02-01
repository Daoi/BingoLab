namespace BingoLab
{
    //Handle player information/stats
    public class Player
    {
        private string Name;
        private int avgTurns;
        private int wins;

        //Initalize values/Instantiate object
        public Player(string name)
        {
            this.Name = name;
            this.avgTurns = 0;
            this.wins = 0;
        }

        public int getWins()
        {
            return this.wins;
        }

        public int getAvgTurns()
        {
            return this.avgTurns;
        }

        public string getName()
        {
            return this.Name;
        }

        public void wonGame()
        {
            this.wins++;
        }

        public void updateTurns(int turns)
        {
            avgTurns = turns / wins;
        }

    }
}