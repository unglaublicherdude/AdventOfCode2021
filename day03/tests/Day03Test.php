<?php

declare(strict_types=1);

include("vendor/autoload.php");

use PHPUnit\Framework\TestCase;
use Vscode\Day03\InputReader;
use Vscode\Day03\PowerConsumptionCalculator;
use Vscode\Day03\LifeSupportRatingCalculator;

final class Day03Test extends TestCase
{
    public function testCanReadTestFile(): void
    {
        $result = InputReader::ReadInput("./input_test");

        $this->assertTrue(is_array($result));
        $this->assertTrue(is_array($result[0]));
        $this->assertEquals(12, sizeof($result));
        $this->assertEquals(5, sizeof($result[0]));
    }

    public function testPowerConsumptionCalculator(): void
    {
        $result = InputReader::ReadInput("./input_test");
        $powerConsumption = PowerConsumptionCalculator::Calc($result);

        $this->assertEquals(198, $powerConsumption);
    }

    public function testLifeSupportRatingCalculator(): void
    {
        $result = InputReader::ReadInput("./input_test");
        $oxigen = LifeSupportRatingCalculator::CalcOxigen($result);
        $scrubber = LifeSupportRatingCalculator::CalcScrubber($result);

        $this->assertEquals(23, $oxigen);
        $this->assertEquals(10, $scrubber);
        $this->assertEquals(230, $oxigen * $scrubber);
    }
}
