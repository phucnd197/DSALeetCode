using System.Data;

namespace DSALeetCode;

public static class Search2DMatrix
{
    /// <summary>
    /// Solution idea
    /// [x,x,x]
    /// [x,x,x]
    /// [x,x,x]
    /// 1. find column that x are in range of or best case x is on the first row <br/>
    /// 2. binary search on column, if not found then x array doest not contains x <br/>
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static bool Solution(int[][] matrix, int target)
    {
        var col = FindColumn(matrix[0], target);
        if (col == -1)
        {
            return false;
        }
        
        if (matrix[0][col] == target)
        {
            return true;
        }

        var row = FindRow(matrix, target, col);
        if (row != -1)
        {
            return true;
        }

        return false;
    }

    private static int FindRow(int[][] matrix, int target, int colIndex)
    {
        int rowStart = 0, rowEnd = matrix[0].Length - 1;
        while (rowStart <= rowEnd)
        {
            var mid = (rowStart + rowEnd) / 2;
            if (matrix[mid][colIndex] == target)
            {
                return mid;
            }

            if (matrix[colIndex][mid] > target)
            {
                rowEnd = mid - 1;
            }
            else
            {
                rowStart = mid + 1;
            }
        }

        return -1;
    }

    private static int FindColumn(int[] row, int target)
    {
        int start = 0, end = row.Length - 1;
        while (start <= end)
        {
            var mid = (start + end) / 2;
            if (row[mid] == target)
            {
                return mid;
            }

            if (row[mid] > target)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        return start - 1;
    }
}