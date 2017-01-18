namespace WarMachines
{
    using WarMachines.Engine;
    using WarMachines.Machines;

    public class WarMachinesProgram
    {
        public static void Main()
        {
            WarMachineEngine.Instance.Start();
           
            //testing return this.targets / new List<string>(this.targets)
            var machine = new Tank("T12", 20, 50);
            machine.Attack("blue");
            machine.Attack("yellow");
            machine.Targets.Add("pink");
            foreach (var target in machine.Targets)
            {
                System.Console.WriteLine(target);
            }
            //output from return this.targets->blue, yellow, pink
            // output from return this.targets->blue, yellow, pink, when this.targets is readonly
            //output from return new List<targets> - > blue, yellow


        }
    }
}
