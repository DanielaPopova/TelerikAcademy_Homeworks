/*jshint esversion: 6*/
function solve() {
    let library = (function() {
        let books = [];
        let categories = [];

        function listBooks(optional) {

            let result = [];

            if (!optional) {
                result = books;
            } else if (optional && optional.category) {
                result = books.filter(function(book) {
                    return book.category === optional.category;
                });
            } else if (optional && optional.author) {
                result = books.filter(function(book) {
                    return book.author === optional.author;
                });
            }

            result = result.sort((firstBook, secondBook) => {
                return firstBook.ID - secondBook.ID;
            });

            return result;
        }

        function addBook(book) {

            //validate title
            if (!book.title || book.title.length < 2 || book.title.length > 100) {
                throw new Error('Book title must be between 2 and 100 characters!');
            }

            if (isTitleUnique(book)) {
                throw new Error('This title already exists!');
            }

            //validate author
            if (!book.author) {
                throw new Error('Author must not be a non-empty string!');
            }

            //validate isbn
            if (!book.isbn || book.isbn.length !== 10 && book.isbn.length !== 13) {
                throw new Error('Book ISBN must contain either 10 or 13 digits!');
            }

            if (!isNumber(book.isbn)) {
                throw new Error('Book ISBN must be a valid number!');
            }

            if (isIsbnUnique(book)) {
                throw new Error('This isbn already exists!');
            }

            //vaidate category
            if (categories.indexOf(book.category) === -1) {
                categories.push(book.category);
            }

            book.ID = books.length + 1;
            books.push(book);

            return book;
        }

        function listCategories() {
            return categories;
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };

        // Helper functions        
        function isNumber(num) {
            return !isNaN(parseFloat(num)) && isFinite(num);
        }

        function isTitleUnique(someBook) {

            return books.some(b => {
                return b.title === someBook.title;
            });
        }

        function isIsbnUnique(someBook) {

            return books.some(b => {
                return b.isbn === someBook.isbn;
            });
        }

    }());

    return library;
}

module.exports = solve;

// testing library
var book = {
    title: 'the good parts',
    isbn: '1234567890',
    author: 'Crockford',
    category: 'javascript'
};

var book1 = {
    title: 'the art of unit testing',
    isbn: '5456897456321',
    author: 'Osherove',
    category: 'c#'
};

var testCategory = {    
    category: 'javascript'    
};

var testAuthor = {    
    author: 'Osherove'    
};

var library = solve();
library.books.add(book);
library.books.add(book1);

console.log(library.books.list(testCategory));
console.log(library.books.list(testAuthor));
console.log(library.categories.list());
