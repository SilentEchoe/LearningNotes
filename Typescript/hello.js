function sayHello(person) {
    return 'Hello,' + person;
}
var user = 'Tom';
console.log(sayHello(user));
alert('hello world in TypeScript!');
function Add(left, right) {
    return left + right;
}
function area(shape) {
    var area = shape.width * shape.height;
    return "Im:" + shape.name + 'With area' + area + "cm squared";
}
alert(area({ name: "Readaw", width: 20, height: 30 }));
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
shape.popup();
