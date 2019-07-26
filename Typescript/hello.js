var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
function sayHelloTwo(person) {
    return "Hello," + person;
}
var userinfo = "Hi";
//console.log(sayHello(user))
//alert('hello world in TypeScript!');
function add(left, right) {
    return left + right;
}
function areat(shape) {
    var area = shape.width * shape.height;
    return "Im:" + shape.name + "With area" + area + "cm squared";
}
//alert(area({name:"Readaw",width:20,height:30}))
var shape = {
    name: "rectangle",
    popup: function () {
        var _this = this;
        console.log("This inside popup():" + this.name);
        setTimeout(function () {
            console.log("This inside setTimeout():" + _this.name);
            console.log("Im a " + _this.name + "!");
        }, 3000);
    }
};
var Class2 = /** @class */ (function () {
    // 构造函数
    function Class2(name, width, height) {
        this.area = width * height;
        this.color = "Pink";
    }
    Class2.prototype.shoutout = function () {
        return "I'm " + this.color + this.area + " cm squared.";
    };
    return Class2;
}());
shape.popup();
var square = new Class2("square", 30, 30);
console.log(square.shoutout());
console.log("Area of Shape: " + square.area);
console.log("Color of Shape: " + square.color);
var Animal = /** @class */ (function () {
    function Animal(TheName) {
        this.name = TheName;
    }
    Animal.prototype.move = function (distanceInMeters) {
        if (distanceInMeters === void 0) { distanceInMeters = 0; }
        console.log(this.name + " moved " + distanceInMeters + "m.");
    };
    return Animal;
}());
// extends 关键字创建子类
var Snake = /** @class */ (function (_super) {
    __extends(Snake, _super);
    function Snake(name) {
        return _super.call(this, name) || this;
    }
    Snake.prototype.move = function (distanceInMeters) {
        if (distanceInMeters === void 0) { distanceInMeters = 5; }
        console.log("Slithering...");
        _super.prototype.move.call(this, distanceInMeters);
    };
    return Snake;
}(Animal));
var Horese = /** @class */ (function (_super) {
    __extends(Horese, _super);
    function Horese(name) {
        return _super.call(this, name) || this;
    }
    Horese.prototype.move = function (distanceInMeters) {
        if (distanceInMeters === void 0) { distanceInMeters = 45; }
        console.log("Galloping...");
        _super.prototype.move.call(this, distanceInMeters);
    };
    return Horese;
}(Animal));
var sam = new Snake("Sammy the Python");
var tom = new Horese("Tommy the Palomino");
sam.move();
tom.move();
var Greeter = /** @class */ (function () {
    function Greeter(message) {
        this.greeting = message;
    }
    Greeter.prototype.greet = function () {
        return "Hello," + this.greeting;
    };
    return Greeter;
}());
var greeter;
greeter = new Greeter("World");
console.log(greeter.greet());
