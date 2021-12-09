package main

import (
	"io/ioutil"
	"strconv"
	"strings"
	"testing"
)

func Test_CountMeasurements(t *testing.T) {
	content, _ := ioutil.ReadFile("./input_test")
	lines := strings.Split(string(content), "\n")

	measurements := []int{}

	for _, line := range lines {
		integerValue, _ := strconv.Atoi(line)
		measurements = append(measurements, integerValue)
	}

	if countIncreasedMeasurements(measurements) != 7 {
		t.Error("Expeced 7 increases")
	}
}
