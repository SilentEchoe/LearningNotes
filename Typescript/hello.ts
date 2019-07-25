function sayHello(person: string) {
    return 'Hello,' + person;
}

let user = 'Tom'

console.log(sayHello(user))
alert('hello world in TypeScript!');


function Add(left: number, right: number): number {
    return left + right

}


interface Shape {
    name: string;
    width: number;
    height: number;
    color?: string;
}

function area(shape: Shape) {
    var area = shape.width * shape.height;
    return "Im:" + shape.name + 'With area' + area + "cm squared"
}


alert(area({name:"Readaw",width:20,height:30}))

