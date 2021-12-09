<?php

declare(strict_types=1);

namespace Vscode\Day03;

class InputReader
{
    public static function ReadInput(string $fileName): array
    {
        $sequences = [];
        $handle = fopen($fileName, "r");
        if ($handle) {
            while (($line = fgets($handle)) !== false) {
                $sequence = [];
                for ($i = 0; $i < strlen($line); $i++) {
                    if (is_numeric($line[$i])) {
                        $sequence[] = (int)$line[$i];
                    }
                }
                $sequences[] = $sequence;
            }
            fclose($handle);
        } else {
            // error opening the file.
        }
        return $sequences;
    }
}
