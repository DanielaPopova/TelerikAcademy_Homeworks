/* globals module */

"use strict";

function solve(){
    class Product{
        constructor(productType, name, price){
            this.productType = productType;
            this.name = name;
            this.price = price;
        }
    }

    class ShoppingCart {
        constructor(){
            this.products = [];
        } 

        add(product){
            this.products.push(product);

            return this;
        }

        remove(product){

            if (this.products.length === 0) {
                throw new Error('There are no products in the shopping cart!');
            }

            if(!this.products.includes(product)){
                throw new Error('There is no such product in the shopping cart!');                
            }

            let index = this.products.findIndex(p => p.productType === product.productType && p.name === product.name && p.price === product.price);
            this.products.splice(index, 1);

            return this;
        }

        showCost(){
            return this.products.reduce(function(total, nextProduct){
                return total + nextProduct.price;
            }, 0);
        }

        showProductTypes(){
            return this.products.map(p => p.productType)                                
                                .sort()
                                .filter((product, index, products) => index === 0 || product !== products[index - 1]);
        }

        getInfo(){

            const groupedByName = {};

			this.products.forEach(p => {
				if(groupedByName.hasOwnProperty(p.name)) {
					groupedByName[p.name].quantity += 1;
					groupedByName[p.name].totalPrice += p.price;
				}
				else {
					groupedByName[p.name] = {
						name: p.name,
						quantity: 1,
					 	totalPrice: p.price
					};
				}
			});

            const groups = Object.keys(groupedByName)
                .sort()
                .map(n => {
                    return {
                        name: n,
                        quantity: groupedByName[n].quantity,
                        totalPrice: groupedByName[n].totalPrice
                    };
                });

            return {
                products: groups,
                totalPrice: this.showCost()
            }
        }
    }
    return {
        Product, ShoppingCart
    };
}

module.exports = solve;