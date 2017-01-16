namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Text;

    using WarMachines.Common;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        private const string StringCannotBeNullOrEmpty = "{0} cannot be null or empty!";

        private string name;
        private IPilot pilot;       
        private ICollection<string> targets;

        protected  Machine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, GlobalErrorMessages.StringCannotBeNullOrEmpty);

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                Validator.CheckIfNull(value, GlobalErrorMessages.ObjectCannotBeNull);

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }        

        public double AttackPoints { get; protected set; }        

        public double DefensePoints { get; protected set; }        

        public IList<string> Targets
        {
            get
            {
                // return this.targets -> basically I allow for everyone to change my list by using all built-in List methods
                return new List<string>(this.targets);
            }
        }

        public void Attack(string target)
        {
            Validator.CheckIfStringIsNullOrEmpty(target, GlobalErrorMessages.StringCannotBeNullOrEmpty);
            this.targets.Add(target);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            var targetsAsString = this.targets.Count > 0 ? string.Join(", ", this.targets) : "None";

            result.AppendLine(string.Format("- {0}", this.Name));
            result.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            result.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            result.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            result.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            result.AppendLine(string.Format(" *Targets: {0}", targetsAsString));

            return result.ToString();
        }
    }
}
