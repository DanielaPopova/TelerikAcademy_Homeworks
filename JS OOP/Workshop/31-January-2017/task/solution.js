/*jshint esversion: 6*/
function solve() {
    function getProduct(productType, name, price) {

        return {
            productType: productType,
            name: name,
            price: price
        };
    }

	function getShoppingCart() {

      let products = [];

      function add(product) {        
           products.push(product);

           return this;
      }

      function remove(product) {

          if (!products) {
              throw new Error('There are no products in the shopping card!');
          }

          if (!products.includes(product)) {
              throw new Error('There is no such product in the shopping card!');
          } 

          for (let i = 0, len = products.length; i < len; i += 1) {
              let currProduct = products[i];

              if (product.productType === currProduct.productType &&
                  product.name === currProduct.name &&
                  product.price === currProduct.price) {
                  products.splice(i, 1);
                break;
              }
          }

          return this; 
      }

      function showCost() {
          
          let sum = 0;

          products.forEach(pr => {
              sum += pr.price;
          });

          return sum;
      }

      function showProductTypes() {
          
          uniqueProducts = [];

          for (let i = 0, len = products.length; i < len; i += 1) {
              let currProduct = products[i];

              if (!uniqueProducts.includes(currProduct.productType)) {
                  uniqueProducts.push(currProduct.productType);
              }
          }

          return uniqueProducts.sort();
      }

      function getInfo() {        
          
          let productInfo = {};              
                        
          for(const product of products) {

              if (!productInfo[product.name]) {
                  productInfo[product.name] = {
                      name: product.name,
                      totalPrice: 0,
                      quantity: 0
                  };
              }

              productInfo[product.name].totalPrice += product.price;
              productInfo[product.name].quantity += 1;
          } 
            
          let allProducts = Object.keys(productInfo).map(groupName => productInfo[groupName]);
              totalPrice = allProducts.reduce((total, current) => total + current.totalPrice, 0);

          return {
              totalPrice: totalPrice,
              products: allProducts
          };         
      }

      return {
          products: products,
          add: add,
          remove: remove,
          showCost: showCost,
          showProductTypes: showProductTypes,
          getInfo: getInfo
      };

      //helper function
      // function contains(item) {
          
      //     for (let product in products) {
      //         if (product.productType === item.productType &&
      //             product.name === item.name &&
      //             product.price === item.price) {

      //           return true;
      //         }
      //     }

      //     return false;
      // }

	}

	return {
		getProduct: getProduct,
		getShoppingCart: getShoppingCart
	};
}

module.exports = solve();

// const {getProduct, getShoppingCart} = solve();

// let cart = getShoppingCart();

// let pr1 = getProduct("Sweets", "Shokolad Milka", 2);
// cart.add(pr1);
// console.log(cart.showCost());
// // prints `2`

// let pr2 = getProduct("Groceries", "Salad", 0.5);
// cart.add(pr2);
// cart.add(pr2);

// console.log(cart.getInfo());

