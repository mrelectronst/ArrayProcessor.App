namespace App;

public static class ArrayProcess
{
    static char[] validChars = { '0', '1', ',', ';' };

    public static bool IsInputStringValid(string? inputString)
    {
        if (string.IsNullOrEmpty(inputString))
            return false;
        bool containsValidChars = inputString.ToCharArray().All(c => validChars.Contains(c));
        return containsValidChars;
    }

    public static int GetAreasCount(string matrixString)
    {
        var matrix = ConvertMatrix(matrixString);
        return CountAreas(matrix);
    }

    static int[][] ConvertMatrix(string matrixString)
    {
        string[] rows = matrixString.Split(';');
        int rowCount = rows.Length;
        int[][] matrix = new int[rowCount][];

        for (int i = 0; i < rowCount; i++)
        {
            string[] rowValues = rows[i].Split(',');
            int columnCount = rowValues.Length;
            matrix[i] = new int[columnCount];

            for (int j = 0; j < columnCount; j++)
            {
                int value = int.Parse(rowValues[j]);
                matrix[i][j] = value;
            }
        }
        return matrix;
    }

    static int CountAreas(int[][] matrix)
    {
        int areaCount = 0;
        int rowCount = matrix.Length;
        int columnCount = matrix[0].Length;

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                if (matrix[i][j] == 1)
                {
                    areaCount++;
                    ScoreArea(matrix, i, j);
                }
            }
        }
        return areaCount;
    }

    static void ScoreArea(int[][] matrix,
                          int row,
                          int column)
    {
        if (IsOutOfBorders(matrix, row, column))
            return;

        matrix[row][column] = 0;
        ScoreArea(matrix, row - 1, column);
        ScoreArea(matrix, row + 1, column);
        ScoreArea(matrix, row, column - 1);
        ScoreArea(matrix, row, column + 1);
    }

    static bool IsOutOfBorders(int[][] matrix,
                               int row,
                               int column)
    {
        int rowCount = matrix.Length;
        int columnCount = matrix[0].Length;
        return (row < 0 ||
                row >= rowCount ||
                column < 0 ||
                column >= columnCount ||
                matrix[row][column] == 0);
    }
}

