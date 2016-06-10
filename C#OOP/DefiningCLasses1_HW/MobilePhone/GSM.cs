namespace MobilePhone
{
    using System;
    using System.Collections.Generic;

    public class GSM
    {
        private static readonly GSM IphoneS6 = new GSM(
            "iPhone 6s", "Apple", 1400, new Battery("Unknown", BatteryType.LiIon, 96, 12), new Display(4.7, 16000000));

        private string model;
        private string manufacturer;
        private decimal? price;
        private List<Call> callHistory = new List<Call>();
        
        public GSM(string model, string manucaturer)
            : this(model, manucaturer, null, null, null)
        {

        }

        public GSM(string model, string manufacturer, decimal? price, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Battery = battery;
            this.Display = display;
        }

        public static GSM IPhone6s
        {
            get
            {
                return IphoneS6;
            }
        }

        public Battery Battery { get; set; }

        public Display Display { get; set; }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    if (value == string.Empty)
                    {
                        throw new ArgumentException("Model can't be an empty string!");                        
                    }
                    else
                    {
                        throw new ArgumentException("Model can't be null!");
                    }
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    if (value == string.Empty)
                    {
                        throw new System.ArgumentException("Manufacturer can't be an empty string!");
                    }
                    else
                    {
                        throw new System.ArgumentException("Manufacturer can't be null!");
                    }
                }

                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Price can't negative!");
                }

                this.price = value;
            }
        }

        public List<Call> CallHistory 
        {
            get { return this.callHistory; }            
        }        

        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }

        // delete with menu
        public void DeleteCall()
        {
            Console.WriteLine("Current call history:");
            this.PrintCallHistory();

            Console.WriteLine("Enter number of call 1 - {0}", this.CallHistory.Count);
            int toDelete = int.Parse(Console.ReadLine()) - 1;

            if (toDelete >= 0 && toDelete < this.CallHistory.Count)
            {
                this.CallHistory.Remove(this.CallHistory[toDelete]);
                Console.WriteLine("Phone call removed!");
            }
            else
            {
                Console.WriteLine("You've entered wrong number!");
            }
        }

        public void DeleteCall(Call call)
        {
            this.CallHistory.Remove(call);
        }

        public void ClearHistory()
        {
            Console.WriteLine("Delete all call history Yes/No");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes")
            {
                this.CallHistory.Clear();
                Console.WriteLine("Call history deleted!");                
            }
            else
            {
                return;
            }
        }

        public void PrintCallHistory()
        {
            int count = 1;

            if (this.CallHistory.Count == 0)
            {
                Console.WriteLine("Call history is empty!");
            }
            else
            {
                for (int i = 0; i < this.CallHistory.Count; i++)
                {
                    Console.WriteLine(count + ". " + this.CallHistory[i]);
                    count++;
                }                
            }
        }

        public decimal CalculateCallPrice(decimal pricePerMinute)
        {
            decimal totalPrice = 0;
            int totalDurationInSeconds = 0;

            for (int i = 0; i < this.CallHistory.Count; i++)
            {
                totalDurationInSeconds += this.CallHistory[i].Duration;
            }

            totalPrice = totalDurationInSeconds * pricePerMinute / 60M;

            return totalPrice;
        }

        public override string ToString()
        {            
            return string.Format("Full Info:\nModel: {0}\nManufacturer: {1}\nPrice: {2} BGN\n{3}\n{4}", this.Model, this.Manufacturer, this.Price, this.Battery, this.Display);
        }
    }
}

/* 
Layout convention

Fields
Constructors
Finalizers (Destructors)
Delegates
Events
Enums
Interfaces
Properties
Indexers
Methods
Structs
Classes
*/