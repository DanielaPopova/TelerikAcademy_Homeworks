namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private readonly ICollection<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(product, GlobalErrorMessages.ObjectCannotBeNull);
            this.products.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            if (this.products.Contains(product))
            {
                return true;
            }

            return false;
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(product, GlobalErrorMessages.ObjectCannotBeNull);
            this.products.Remove(product);
        }

        public decimal TotalPrice()
        {
            decimal sumProducts = this.products.Sum(p => p.Price);           

            return sumProducts;
        }
    }
}
