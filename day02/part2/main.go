package main

import (
	"fmt"
	"io/ioutil"
	"strconv"
	"strings"
)

func main() {
	content, err := ioutil.ReadFile("./input")
	if err != nil {
		panic(err)
	}
	commands := strings.Split(string(content), "\n")

	horizontal, depth := calculatePoisition(commands)
	fmt.Println(horizontal*depth)
}

func calculatePoisition(commands []string) (horizontal int, depth int) {
	horizontal = 0
	depth = 0
	aim := 0
	for _, command := range commands {
		parts := strings.Split(command, " ")
		wordCommand := parts[0]
		stepNumber, _ := strconv.Atoi(parts[1])

		switch wordCommand {
		case "forward":
			horizontal = horizontal+stepNumber
			depth = depth+(aim*stepNumber)
			break
		case "down":
			aim = aim + stepNumber 
			break
		case "up":
			aim = aim - stepNumber
			break
		}
	}
	return horizontal, depth
}
