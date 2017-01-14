namespace WarMachines.Machines
{
    using System;
    using System.Text;

    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        private const double InitialHealthPoints = 100;
        private const double AttackPointsChange = 40;
        private const double DefencePointsChange = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleDefenseMode(); // TODO: check about this.ToggleDefenseMode
        }

        public bool DefenseMode { get; private set; }       

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;

            if (this.DefenseMode)
            {
                this.AttackPoints -= AttackPointsChange;
                this.DefensePoints += DefencePointsChange;
            }
            else
            {
                this.AttackPoints += AttackPointsChange;
                this.DefensePoints -= DefencePointsChange;
            }
        }

        public override string ToString()
        {
            var baseString = base.ToString();

            var result = new StringBuilder();
            result.Append(baseString);
            result.Append(string.Format(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF"));

            return result.ToString();
        }
    }
}
