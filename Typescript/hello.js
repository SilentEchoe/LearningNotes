// function sayHelloTwo(person: string) {
//   return "Hello," + person;
// }
// let userinfo = "Hi";
// //console.log(sayHello(user))
// //alert('hello world in TypeScript!');
// function add(left: number, right: number): number {
//   return left + right;
// }
// interface Shape {
//   name: string;
//   width: number;
//   height: number;
//   color?: string;
// }
// function areat(shape: Shape) {
//   var area = shape.width * shape.height;
//   return "Im:" + shape.name + "With area" + area + "cm squared";
// }
// //alert(area({name:"Readaw",width:20,height:30}))
// var shape = {
//   name: "rectangle",
//   popup: function() {
//     console.log("This inside popup():" + this.name);
//     setTimeout(() => {
//       console.log("This inside setTimeout():" + this.name);
//       console.log("Im a " + this.name + "!");
//     }, 3000);
//   }
// };
// class Class2 {
//   area: number;
//   color: string;
//   // 构造函数
//   constructor(name: string, width: number, height: number) {
//     this.area = width * height;
//     this.color = "Pink";
//   }
//   shoutout() {
//     return "I'm " + this.color + this.area + " cm squared.";
//   }
// }
// shape.popup();
// var square = new Class2("square", 30, 30);
// console.log(square.shoutout());
// console.log("Area of Shape: " + square.area);
// console.log("Color of Shape: " + square.color);
// class Animal {
//   name: string;
//   constructor(TheName: string) {
//     this.name = TheName;
//   }
//   move(distanceInMeters: number = 0) {
//     console.log(`${this.name} moved ${distanceInMeters}m.`);
//   }
// }
// // extends 关键字创建子类
// class Snake extends Animal {
//   constructor(name: string) {
//     super(name);
//   }
//   move(distanceInMeters = 5) {
//     console.log("Slithering...");
//     super.move(distanceInMeters);
//   }
// }
// class Horese extends Animal {
//   constructor(name: string) {
//     super(name);
//   }
//   move(distanceInMeters = 45) {
//     console.log("Galloping...");
//     super.move(distanceInMeters);
//   }
// }
// let sam = new Snake("Sammy the Python");
// let tom: Animal = new Horese("Tommy the Palomino");
// sam.move();
// tom.move();
var Greeter = (function () {
    function Greeter(message) {
        this.greeting = message;
    }
    Greeter.prototype.greet = function () {
        return "Hello, " + this.greeting;
    };
    return Greeter;
})();
var greeter;
greeter = new Greeter("World");
console.log(greeter.greet());
