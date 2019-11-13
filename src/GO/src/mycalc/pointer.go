//package main

import(
	"flag"
	"fmt"
)
// 指针
// go 语言中的指针提供控制“数据结构”指针的能力，但是并不能进行指针运算
// go 语言允许你控制特定集合的数据结构，分配的数量以及内存访问模式

// 两个核心：
// 类型指针，允许对这个指针类型的数据进行修改，传递数据可以直接使用指针，而无需拷贝数据，类型指针不能进行偏移和运算
// 切片：由指向起始元素的原始指针，元素数量和容器组成
// go语言中在变量名前面添加 & 操作符（前缀）来获取变量的内存地址
// ptr:=&v //v的类型为T

var mode = flag.String("dotnet","","-v")

type weekday int
// 类似实现C# 中的枚举
const (
	Sunday weekday = iota
	Tuesday
	Wednesday
	Thursday
	Friday
	Saturday

)

func main()  {
	 // 准备一个字符串类型
	 var house = "Malibu Point 10880, 90265"
	 // 对字符串取地址, ptr类型为*string
	 ptr := &house
 	// 打印ptr的类型
	 fmt.Printf("ptr type: %T\n", ptr)
	 
	 // 对指针进行取值操作
	 value := *ptr

	 // 取值后的类型
	 fmt.Printf("value type: %T\n", value)

	// 指针取值后就是指向变量的值
	fmt.Printf("value: %s\n", value)

	// 准备两个变量, 赋值1和2
    x, y := 1, 2
    // 交换变量值
    swap(&x, &y)
    // 输出变量值
	fmt.Println(x, y)
	
	// 解析命令行参数
	flag.Parse()
	// 输出命令行参数
	fmt.Println(*mode)

    strTest := new(string)

    *strTest = "Go"

    fmt.Println(*strTest)

}



func swap(a,b *int)  {
	t := *a
	// *a 的意思不是取a指针的值，而是“a 指向的变量”
	*a = *b

	*b = t
}