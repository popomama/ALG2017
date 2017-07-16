using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Sort
{
    public struct Point
    {
        int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return y; }
            set { this.y = value; }
        }
    }
    public class SortMisc
    {

        //SaddleSort
        //Design and implement an efficient algorithm to search for a given integer x in a 2-dimensional sorted 
        //array a[0..m][0..n].
        //Example Array
        //  1   3   5   7   9
        //  2   5   8   10  17
        //  5   8   8   12  20
        //  10  12  20  25  27
        public static Point SaddleSearch(int[][] arr, int target)
        {
            //the strategy is starting fromt the top-right corner, if the element > target, go left(col-1);
            //if element>target, go below(row+1); if element==target, find match;
            //the complexity is O(m+n)
            //Finds any occurrence that is corresponding to the smallest row index and the highest column index
            int rowNumnber = arr.GetLength(0);
            int colNumber = arr.GetLength(1);

            Point p = new Point(1, -1);

            int currRow = 0, currCol = colNumber - 1;

            while(currCol>=0 & currRow<rowNumnber)
            {
                if (arr[currRow][currCol] == target)
                {
                    //Console.WriteLine("found match at row " + currRow + ", " + currCol);
                    p.X = currRow;
                    p.Y = currCol;

                    return p;

                }
                else if (arr[currRow][currCol] > target)
                    currCol--;
                else
                    currRow++;
            }

            return p;

        }


        //SaddleSearchCount
        //Design and implement an efficient algorithm to search the count for a given integer x in a 2-dimensional sorted 
        //array a[0..m][0..n].
        //Example Array
        //  1   3   5   7   9
        //  2   5   8   10  17
        //  5   8   8   12  20
        //  10  12  20  25  27
        public static Stack<Point> SaddleSearchCount(int[][] arr, int target)
        {
            //the strategy is starting fromt the top-right corner, if the element > target, go left(col-1);
            //if element>target, go below(row+1); if element==target, find match;
            //once the first match is found, it scan the element to its left to find more (this step may use binary search)
            //after that it will repeat each row below
            //the complexity is O(mn)  (Note if the same row search uses the binary search, then the complexity can be O(mlgn) ).
            int rowNumnber = arr.GetLength(0);
            int colNumber = arr.GetLength(1);

            Point p;// = new Point(1, -1);

            Stack<Point> s = new Stack<Point>();

            int currRow = 0, currCol = colNumber - 1;

            while (currCol >= 0 & currRow < rowNumnber)
            {
                if (arr[currRow][currCol] == target)
                {
                    p = new Point(currRow, currCol);
                    //Console.WriteLine("found match at row " + currRow + ", " + currCol);
                    //p.X = currRow;
                    //p.Y = currCol;

                    s.Push(p);

                    //now try to find out if there is any other element that has the same value in this row
                    int col = currCol;
                    while (col>=0)//this step may use binary search to get better performance.
                    {
                        if (arr[currRow][col] == target)
                        {
                            p = new Point(currRow, currCol);
                            s.Push(p);
                            col--;
                        }
                        else
                            col = -1;
                    }
                    currRow++;
                }
                else if (arr[currRow][currCol] > target)
                    currCol--;
                else
                    currRow++;
            }

            return s;

        }

        //Design and implement an efficient program to find a contiguous subarray within 
        //a one-dimensional array of integers which has the largest sum.
        //Please note that there is at least one positive integer in the input array.
        public static int LargestSubArraySum(int[] arr)
        {
            int max = 0, currMax = 0;

            int currIndex = 0;
           // int temp;
            while (currIndex < arr.Length)
            {
                currMax = currMax + arr[currIndex];
                if (currMax < 0)
                {
                    currMax = 0;
                }
                else if(currMax > max)
                {
                    max = currMax;

                }
                currIndex++;


            }

            return max;
        }
    }
}
