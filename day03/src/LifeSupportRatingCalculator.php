<?php

declare(strict_types=1);

namespace Vscode\Day03;

class LifeSupportRatingCalculator
{
    public static function CalcOxigen(array $numbers, int $position = 0): int
    {
        if (sizeof($numbers) == 1) {
            return bindec(implode("", $numbers[0]));
        }
        if (sizeof($numbers[0]) < $position) {
            return 0;
        }
        $zeroNumbers = $oneNumbers = [];
        $zeros = $ones = 0;
        foreach ($numbers as $number) {
            if ($number[$position] == 1) {
                $ones++;
                $oneNumbers[] = $number;
            } else {
                $zeros++;
                $zeroNumbers[] = $number;
            }
        }

        return self::CalcOxigen($ones >= $zeros ? $oneNumbers : $zeroNumbers, ($position + 1));
    }

    public static function CalcScrubber(array $numbers, int $position = 0): int
    {
        if (sizeof($numbers) == 1) {
            return bindec(implode("", $numbers[0]));
        }
        if (sizeof($numbers[0]) < $position) {
            return 0;
        }
        $zeroNumbers = $oneNumbers = [];
        $zeros = $ones = 0;
        foreach ($numbers as $number) {
            if ($number[$position] == 1) {
                $ones++;
                $oneNumbers[] = $number;
            } else {
                $zeros++;
                $zeroNumbers[] = $number;
            }
        }

        return self::CalcScrubber($zeros <= $ones ? $zeroNumbers : $oneNumbers, ($position + 1));
    }
}
