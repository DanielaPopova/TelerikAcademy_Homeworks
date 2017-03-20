namespace Mines.Models
{  
    using Mines.Contracts;

    public class Player : IPlayer
    {        
        public Player()
        {
        }

        public Player(string name, int result)
        {
            this.Name = name;
            this.Result = result;
        }

        public string Name { get; set; }        

        public int Result { get; set; }
    }
}
