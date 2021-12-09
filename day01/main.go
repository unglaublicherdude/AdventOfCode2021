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
	lines := strings.Split(string(content), "\n")

	measurements := []int{}

	for _, line := range lines {
		integerValue, _ := strconv.Atoi(line)
		measurements = append(measurements, integerValue)
	}

	fmt.Println(countIncreasedMeasurements(measurements))
}

func countIncreasedMeasurements(measurements []int) int {
	increased := 0
	for i := 0; i < len(measurements); i++ {
		if i != 0 {
			if measurements[i] > measurements[i-1] {
				increased++
			}
		}
	}
	return increased
}
