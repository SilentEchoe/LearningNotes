package main

import "fmt"





func main(){
	//var a int = 100
	//var b int = 200
	//b, a = a, b
	//fmt.Println(a, b)
	var C int ;
	a, _ := GetData()
	_, b := GetData()
	_ = C
    fmt.Println(a, b,C)

}
// := 操作符只能在声明变量的时候使用
// _ 为匿名对象，它可以接受任何类型的值，但任何赋给这个标识符的值都将抛弃，匿名值无法赋值给其他变量
// 匿名变量不占用内存空间，不会分配内存，不会因为多次声明而无法使用 
func GetData() (int, int) {
    return 100, 200
}

