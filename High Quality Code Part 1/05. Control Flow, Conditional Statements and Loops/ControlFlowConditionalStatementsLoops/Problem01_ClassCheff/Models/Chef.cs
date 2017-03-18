namespace Kitchen.Models
{
    using System.Collections.Generic;
     
    using Contracts;
    using Products;
    using Utensils;

    public class Chef : IChef
    { 
        public void Cook(ICollection<IVegetable> vegetables, IUtensil utensil)
        {
            foreach (var vegetable in vegetables)
            {
                this.Cut(vegetable);
                this.Peel(vegetable);

                utensil.Add(vegetable);
            }

            // Just for testing purpose -> StartUp
            System.Console.WriteLine("All is cooked!");            
        }

        public void Cut(IVegetable vegetable)
        {
            vegetable.IsCut = true;
        }

        public void Peel(IVegetable vegetable)
        {
            vegetable.IsPeeled = true;
        }
    }
}
