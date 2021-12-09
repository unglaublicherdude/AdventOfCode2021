<?php

declare(strict_types=1);

namespace Vscode\Day03;

class PowerConsumptionCalculator
{
    public static function Calc(array $sequences): int
    {
        $gamma = $epsilon = "";
        $amountOfNumbers = sizeof($sequences[0]);
        for ($i = 0; $i < $amountOfNumbers; $i++) {
            $zeros = 0;
            $ones = 0;
            foreach ($sequences as $sequence) {
                if ($sequence[$i] == 1) {
                    $ones++;
                } else {
                    $zeros++;
                }
            }
            $gamma .= $zeros > $ones ? "0" : "1";
            $epsilon .= $zeros < $ones ? "0" : "1";
        }

        return bindec($gamma) * bindec($epsilon);
    }
}
