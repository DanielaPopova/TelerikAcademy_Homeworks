/*jshint esversion: 6*/

class listNode {

    constructor(value) {
        this._value = value;
        this._next = null;
    }

    get value() {
        return this._value;
    }

    get next() {
        return this._next;
    }
}

class LinkedList {

    constructor() {
        this._length = 0;
        this._head = null;

        //return this;
    }

    get first(){
        //return this._head;
    }

    get last() {

    }

    get length() {
        return this._length;
    }

    append(...elements) {

        for (const element of elements) {
            let node = new listNode(element);

            if (this._head === null) {
                this._head = node;
            } else {
                let current = this._head;

                while (current._next) {      //current is a node with _value and _next
                    current = current._next;
                }
                current._next = node;
            }

            this._length += 1;
        }

        return this;
    }
}

// var node = new listNode(5);
// console.log(node._value);
let list = new LinkedList();
list.append(7).append(8, 9, 10);
console.log(list);
//module.exports = LinkedList;