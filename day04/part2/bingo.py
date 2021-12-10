from typing import List


class Bingo:
    def __init__(self, path: str) -> None:
        input_file = open(path, "r")
        all_lines = input_file.readlines()
        input_file.close()

        self.called_numbers: List[int] = self._parse_number_sequence(all_lines)
        self.fields: List[List[List[int]]] = self._parse_fields(all_lines)

    def _parse_number_sequence(self, lines: List[str]) -> List[int]:
        number_strings: List[str] = lines[0].split(",")
        numbers: List[int] = []
        for number in number_strings:
            numbers.append(int(number))
        return numbers

    def _parse_fields(self, lines: List[str]) -> List[List[List[int]]]:
        fields: List[List[List[int]]] = []
        start_line: int = 2
        last_line: int = 0
        while start_line < len(lines):
            field: List[List[int]] = []
            if lines[start_line].strip() == "":
                start_line += 1
                break
            for iterator in range(start_line, len(lines)):
                if lines[iterator].strip() == "":
                    break
                numbers_line: List[int] = list(
                    map(
                        lambda x: int(x.strip()),
                        list(filter(None, lines[iterator].split(" "))),
                    )
                )
                if len(numbers_line) > 1:
                    field.append(numbers_line)
                last_line = iterator + 1
            start_line = last_line + 1
            fields.append(field)
        return fields

    def GetColumnsAndRows(
        self,
        field: List[List[int]],
    ) -> dict[str, List[List[int]]]:
        linesAndRows: dict[str, List[List[int]]] = {"columns": [], "rows": []}

        linesAndRows["columns"] = field

        for iterator in range(0, 5):
            row: List[int] = []
            for other_iterator in range(0, len(field)):
                row.append(field[other_iterator][iterator])
            linesAndRows["rows"].append(row)

        return linesAndRows

    def CalculateBingoScore(self) -> int:
        fields: List[List[List[int]]] = self.fields
        number_end: int = 5
        last_won_board: dict[str, List[List[int]]] = {}
        last_number_sequence: List[int] = []
        while number_end < len(self.called_numbers):
            for field in fields:
                columns_and_rows = self.GetColumnsAndRows(field)
                score: int = self.GetBingoScore(
                    self.called_numbers[0:number_end], columns_and_rows
                )
                if score > 0:
                    last_won_board = columns_and_rows
                    last_number_sequence = self.called_numbers[0:number_end]
                    fields.remove(field)
            number_end += 1
        return (
            self.GetBingoScore(last_number_sequence, last_won_board)
            * last_number_sequence[len(last_number_sequence) - 1]
        )

    def GetBingoScore(
        self, numbers: List[int], columns_and_rows: dict[str, List[int]]
    ) -> int:
        score: int = 0
        found: bool = False
        for column in columns_and_rows["columns"]:
            hits: int = 0
            for number in numbers:
                if number in column:
                    hits += 1
            if hits == 5:
                found = True

        if found == False:
            for row in columns_and_rows["rows"]:
                hits: int = 0
                for number in numbers:
                    if number in row:
                        hits += 1
                if hits == 5:
                    found = True

        if found == True:
            for column in columns_and_rows["columns"]:
                for number in column:
                    if number not in numbers:
                        score = score + number

        return score
