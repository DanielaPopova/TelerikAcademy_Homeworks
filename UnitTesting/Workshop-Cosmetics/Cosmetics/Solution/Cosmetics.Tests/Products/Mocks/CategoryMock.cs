namespace Cosmetics.Tests.Products.Mocks
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Cosmetics.Products;    

    internal class CategoryMock : Category
    {
        public CategoryMock(string name)
            : base(name)
        {

        }

        public IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
