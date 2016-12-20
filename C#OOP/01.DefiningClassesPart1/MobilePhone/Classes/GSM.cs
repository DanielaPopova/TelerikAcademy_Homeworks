namespace MobilePhone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MobilePhone.Classes;
    using MobilePhone.Enums;

    public class GSM
    {
        public static readonly GSM IPhoneS6 = new GSM(
            "iPhone 6s", "Apple", 1200, "Ivan Petkov", new Display(4.7, 16000000), new Battery("Unknown", BatteryType.LiIon, 96, 12));

        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;       

        public GSM(string model, string manufacturer)            
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.CallHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Display display, Battery battery)  
            : this(model, manufacturer)
        {            
            this.Price = price;
            this.Owner = owner;
            this.Display = display;
            this.Battery = battery;
        }

        public string Model 
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or empty string!");
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

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Manufacturer cannot be null or empty string!");
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
                    throw new ArgumentException("Price cannot be negative number!");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Owner cannot be null or empty string!");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Name of owner should be at least 3 symbols long!");
                }

                this.owner = value;
            }
        }        

        public Display Display { get; set; }

        public Battery Battery { get; set; }

        public List<Call> CallHistory { get; private set; }

        public string DisplayInfo()
        {
            return "**GSM Information**" + "\n" + this.ToString();
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

            Console.WriteLine("Enter number of phone call to delete 1 - {0}", this.CallHistory.Count);
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
            Console.WriteLine("Delete all call history yes/no");
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
            Console.WriteLine("*Call History*");

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
            StringBuilder info = new StringBuilder();

            string model = string.Format("Model: {0}", this.Model);
            string manufacturer = string.Format("Manufacturer: {0}", this.Manufacturer);
            string price = string.Format("Price: {0} BGN", this.Price == null ? "N/A" : this.Price.ToString());
            string owner = string.Format("Owner: {0}", this.Owner);
            string display = this.Display.ToString();
            string battery = this.Battery.ToString();

            info.AppendLine(manufacturer)
                .AppendLine(model)
                .Append(display)
                .Append(battery)
                .AppendLine(price)
                .AppendLine(owner);

            return info.ToString();
        }
    }
}
