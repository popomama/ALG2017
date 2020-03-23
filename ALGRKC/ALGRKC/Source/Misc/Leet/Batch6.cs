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

    
}
