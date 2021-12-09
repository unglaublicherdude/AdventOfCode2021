<?php

declare(strict_types=1);

namespace Vscode\Day03;

include("vendor/autoload.php");

use Vscode\Day03\InputReader;
use Vscode\Day03\PowerConsumptionCalculator;

$sequences = InputReader::ReadInput("./input");
print(PowerConsumptionCalculator::Calc($sequences));
