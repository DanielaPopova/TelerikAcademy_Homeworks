namespace Mines.Models
{
    using System;

    using Mines.Contracts;

    public class Score : IScore
    {        
        public Score()
        {
        }

        public Score(string name, int result)
        {
            this.Name = name;
            this.Result = result;
        }

        public string Name { get; set; }        

        public int Result { get; set; }
    }
}
