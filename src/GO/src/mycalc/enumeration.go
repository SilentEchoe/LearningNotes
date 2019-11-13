package main

import (
	"fmt"
)

type Weapon int

const (
	Arrow Weapon = iota // 开始生成枚举
	Shuriken
	SniperRifle
	Rifle
	Blower
)

func main() {
	fmt.Println(Arrow, Shuriken, SniperRifle, Rifle, Blower)

	// 使用枚举类型并赋初值
	var weapon Weapon = Blower
	fmt.Println(weapon)

}
