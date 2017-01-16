namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Toothpaste : Product, IToothpaste
    {
        private const int IngredientNameLengthMin = 4;
        private const int IngredientNameLengthMax = 12;

        private readonly ICollection<string> ingredients;        

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.ValidateIngredients(ingredients);
            this.ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ", this.ingredients);
            }
        }
        
        public override string Print()
        {
            string baseString = base.Print();

            var result = new StringBuilder();
            result.AppendLine(baseString);
            result.AppendLine(string.Format("  * Ingredients: {0}", this.Ingredients));            

            return result.ToString().Trim();
        }

        private void ValidateIngredients(IList<string> ingredients)
        {
            if (ingredients.Any(i => i.Length < IngredientNameLengthMin || i.Length > IngredientNameLengthMax))
            {
                throw new IndexOutOfRangeException(string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", IngredientNameLengthMin, IngredientNameLengthMax));
            }
        }
    }
}
