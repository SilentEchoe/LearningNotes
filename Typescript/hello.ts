function sayHello(person: string) {
    return 'Hello,' + person;
}

let user = 'Tom'

//console.log(sayHello(user))
//alert('hello world in TypeScript!');


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


//alert(area({name:"Readaw",width:20,height:30}))

var shape = 
{
    name:"rectangle",
    popup:function()
    {
        console.log('This inside popup():'+ this.name)

        setTimeout(()=>
        {
            console.log('This inside setTimeout():'+ this.name);
            console.log('Im a '+ this.name + '!');

        },3000)
   
    }

}


class Class1
{
    area : number;
    color: string;

    constructor(name:string,width:number,height:number)
    {
        this.area = width * height;
        this.color = "Pink";
    }

    shoutout()
    {
        return "I'm " + this.color + this.area + " cm squared.";
    }

}


shape.popup();

var square = new Class1("square", 30, 30);

console.log( square.shoutout() );
console.log( 'Area of Shape: ' + square.area );
console.log( 'Color of Shape: ' + square.color );
