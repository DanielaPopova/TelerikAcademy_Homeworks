namespace Cosmetics.Tests.Engine.Mocks
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Cosmetics.Engine;

    internal class CosmeticsEngineMock : CosmeticsEngine
    {
        public CosmeticsEngineMock(ICosmeticsFactory factory, IShoppingCart shoppingCart, ICommandParser commandParser)
            : base(factory, shoppingCart, commandParser)
        {
        }

        public IDictionary<string, ICategory> Categories
        {
            get
            {
                return base.categories;
            }
        }

        public IDictionary<string, IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
