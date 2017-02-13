namespace Cosmetics.Tests.Products.Mocks
{
    using System.Collections.Generic;

    using Cosmetics.Products;
    using Contracts;

    internal class ShoppingCartMock : ShoppingCart
    {
        public IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
