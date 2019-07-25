function sayHelloTwo(person) {
    return 'Hello,' + person;
}
var userinfo = 'Hi';
//console.log(sayHello(user))
//alert('hello world in TypeScript!');
function add(left, right) {
    return left + right;
}
function areat(shape) {
    var area = shape.width * shape.height;
    return "Im:" + shape.name + 'With area' + area + "cm squared";
}
//alert(area({name:"Readaw",width:20,height:30}))
var shape = {
    name: "rectangle",
    popup: function () {
        var _this = this;
        console.log('This inside popup():' + this.name);
        setTimeout(function () {
            console.log('This inside setTimeout():' + _this.name);
            console.log('Im a ' + _this.name + '!');
        }, 3000);
    }
};
var Class2 = /** @class */ (function () {
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
console.log('Area of Shape: ' + square.area);
console.log('Color of Shape: ' + square.color);
