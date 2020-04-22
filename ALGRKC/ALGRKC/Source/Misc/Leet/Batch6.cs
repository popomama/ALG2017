using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Misc.Leet
{
    public class Batch6
    {


        //Leetcode 306: Addictive number
        //Additive number is a string whose digits can form additive sequence.
        //A valid additive sequence should contain at least three numbers.Except for the first two numbers, each subsequent number in the sequence must be the sum of the preceding two.

        //Given a string containing only digits '0'-'9', write a function to determine if it's an additive number.
        //Note: Numbers in the additive sequence cannot have leading zeros, so sequence 1, 2, 03 or 1, 02, 3 is invalid.
        //Example 1:
        //Input: "112358"
        //Output: true
        //Explanation: The digits can form an additive sequence: 1, 1, 2, 3, 5, 8. 
        //   1 + 1 = 2, 1 + 2 = 3, 2 + 3 = 5, 3 + 5 = 8
        //Example 2:
        //Input: "199100199"
        //Output: true
        //Explanation: The additive sequence is: 1, 99, 100, 199. 
        //  1 + 99 = 100, 99 + 100 = 199
        //Constraints:
        //        num consists only of digits '0'-'9'.
        //1 <= num.length <= 35
        public bool IsAdditiveNumber(string num)
        {
            int len =num.Length;

            for(int i=1;i<=len/2;i++)
                for(int j=1;j<=len/2;j++)
                {
                    if (IsAdditiveNumber(num.Substring(0, i), num.Substring(i, j), num.Substring(i+j)))
                        return true;
                }

            return false;
//            IsAdditiveNumber(num,0, )
        }

        private bool IsAdditiveNumber(string first, string second, string remaining)
        {
            if (first.Length > remaining.Length || second.Length > remaining.Length)
                return false;

            if ((first.StartsWith("0")&&(first.Length>1)) || (second.StartsWith("0")&&(second.Length>1)) || 
                (remaining.StartsWith("0")&&(remaining.Length>1)))
                return false;
           
            long firstN = atoi(first);
            long secondN = atoi(second);
            long sum = firstN + secondN;
            if (sum.ToString() == remaining)
                return true;

            if (!remaining.StartsWith(sum.ToString()))
                return false;

            return IsAdditiveNumber(second, sum.ToString(), remaining.Substring(sum.ToString().Length) );

        }

        long atoi(string s)
        {
            long temp = s[0] - '0';

            for (int i = 1; i < s.Length; i++)
                temp = temp * 10 + s[i] - '0';
            return temp;
        }

        

    }

    //Leetcode 304: Range Sum Query 2D
    //Given a 2D matrix matrix, find the sum of the elements inside the rectangle defined by its upper left corner (row1, col1) and lower right corner (row2, col2).

    //        Range Sum Query 2D
    //The above rectangle(with the red border) is defined by(row1, col1) = (2, 1) and(row2, col2) = (4, 3), which contains sum = 8.
    //Example:
    //Given matrix = [
    //  [3, 0, 1, 4, 2],
    //  [5, 6, 3, 2, 1],
    //  [1, 2, 0, 1, 5],
    //  [4, 1, 0, 1, 7],
    //  [1, 0, 3, 0, 5]
    //]

    //sumRegion(2, 1, 4, 3) -> 8
    //sumRegion(1, 1, 2, 2) -> 11
    //sumRegion(1, 2, 2, 4) -> 12
    //Note:
    //You may assume that the matrix does not change.
    //There are many calls to sumRegion function.
    //You may assume that row1 ≤ row2 and col1 ≤ col2.
    public class NumMatrix
    {


       

        int[,] dp;
    public NumMatrix (int[][] matrix)
    {
        int row = matrix.Length;
            if (row == 0) return;
        int col = matrix[0].Length;
            if (col == 0) return;
        //in order to avoid the boardline case, we expand the DP matrix by 1, so that we can uniformly handle all the borderline cases

        dp = new int[row + 1, col + 1]; // each cell is initialied to 0

        for (int i = 1; i <= row; i++)
            for (int j = 1; j <= col; j++)
            {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1] - dp[i - 1, j - 1] + matrix[i - 1][j - 1];

            }



    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
            return dp[row2 + 1, col2 + 1] - dp[row2 + 1, col1] - dp[row1, col2+1] + dp[row1, col1];

    }

}

    
}
