namespace Kitchen.Models.Utensils
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class Bowl : IUtensil
    {
        private ICollection<IVegetable> ingredients;

        public Bowl()
        {
            this.ingredients = new List<IVegetable>();
        }

        public void Add(IVegetable vegetable)
        {
            if (!vegetable.IsCut)
            {
                throw new ArgumentException("Cut the vegetable first!");
            }

            if (!vegetable.IsPeeled)
            {
                throw new ArgumentException("Peel the vegetable first!");
            }           

            this.ingredients.Add(vegetable);
        }
    }
}
