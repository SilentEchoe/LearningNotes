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
    return "Im" + shape.name + 'With area' + area + "cm squared";
}
alert(area({ name: "Readaw", width: 20, height: 30 }));
