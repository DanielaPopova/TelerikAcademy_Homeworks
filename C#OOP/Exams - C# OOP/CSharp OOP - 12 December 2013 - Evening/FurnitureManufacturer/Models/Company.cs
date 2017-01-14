namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or emprty!");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("Name cannot be with less than 5 symbols!");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                if (value == null || value.Length != 10)
                {
                    throw new ArgumentException("Registration number must be exactly 10 symbols!");
                }

                if (!this.ContainsOnlyDigits(value))
                {
                    throw new ArgumentException("registration number must contain only digits!");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
        }       

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
        }

        public string Catalog()
        {
            var info = new StringBuilder();
            
            info.AppendLine(string.Format("{0} - {1} - {2} {3}",
                            this.Name,
                            this.RegistrationNumber,
                            this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                            this.Furnitures.Count != 1 ? "furnitures" : "furniture"));

            if (this.Furnitures.Count >= 1)
            {
                foreach (var furniture in this.furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model))
                {
                    info.AppendLine(furniture.ToString());
                }
            }            

            return info.ToString().TrimEnd();
        }

        private bool ContainsOnlyDigits(string value)
        {
            foreach (var symbol in value)
            {
                if (!char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;            
        }
    }    
}
