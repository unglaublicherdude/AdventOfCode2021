import unittest

from bingo import Bingo
from typing import List


class TestBingo(unittest.TestCase):
    def test_parse_number_sequence(self):
        bingo = Bingo("./input_test")

        self.assertEqual(7, bingo.called_numbers[0])
        self.assertEqual(5, bingo.called_numbers[3])
        self.assertEqual(1, bingo.called_numbers[26])
        self.assertEqual(27, len(bingo.called_numbers))

    def test_parse_fields(self):
        bingo = Bingo("./input_test")
        self.assertEqual(22, bingo.fields[0][0][0])
        self.assertEqual(19, bingo.fields[0][4][4])
        self.assertEqual(3, bingo.fields[1][0][0])
        self.assertEqual(6, bingo.fields[1][4][4])
        self.assertEqual(14, bingo.fields[2][0][0])
        self.assertEqual(7, bingo.fields[2][4][4])

    def test_get_columns_and_rows(self):
        bingo = Bingo("./input_test")
        lines_and_rows: dict[str, List[List[int]]] = bingo.GetColumnsAndRows(
            bingo.fields[0]
        )

        self.assertEqual(22, lines_and_rows["columns"][0][0])
        self.assertEqual(19, lines_and_rows["columns"][4][4])
        self.assertEqual(22, lines_and_rows["rows"][0][0])
        self.assertEqual(19, lines_and_rows["rows"][4][4])

    def test_get_bingo_score(self):
        bingo = Bingo("./input_test")
        score: int = bingo.GetBingoScore(
            [1, 2, 3, 4, 5],
            {
                "columns": [
                    [1, 2, 3, 4, 6],
                    [1, 2, 3, 4, 6],
                    [1, 2, 3, 4, 6],
                    [1, 2, 3, 4, 5],
                    [1, 2, 3, 4, 6],
                ],
                "rows": [
                    [1, 2, 3, 4, 6],
                    [1, 2, 3, 4, 6],
                    [1, 2, 3, 4, 6],
                    [1, 2, 3, 4, 6],
                    [1, 2, 3, 4, 6],
                ],
            },
        )
        self.assertEqual(24, score)

    def test_calculate_bingo_score(self):
        bingo = Bingo("./input_test")
        self.assertEqual(4512, bingo.CalculateBingoScore())


if __name__ == "__main__":
    unittest.main()
