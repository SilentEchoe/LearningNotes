package Test

import "fmt"


func main()  {
	str := "string类型"
	fmt.Println(str)

	const stra = `第一行
	第二行
	第三行
	\r\n
	`
	fmt.Println(stra)
}

// 反引号 ` 两个反引号间的字符串将被原样赋值到stra 变量中 