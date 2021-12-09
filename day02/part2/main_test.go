package main

import (
	"io/ioutil"
	"strings"
	"testing"
)

func Test_CalculatePoisition(t *testing.T) {
	content, _ := ioutil.ReadFile("./../input_test")
	commands := strings.Split(string(content), "\n")

	horizontal, depth := calculatePoisition(commands)

	if horizontal != 15 {
		t.Error("Expeced horziontal to be 15 but got ", horizontal)
	}
	if depth != 60 {
		t.Error("Expeced depth to be 60 but got ", depth)
	}
	if (horizontal*depth) != 900 {
		t.Error("Expeced product to be 900 but got ", (horizontal*depth))
	}
}
