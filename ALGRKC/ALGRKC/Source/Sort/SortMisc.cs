﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Sort
{
    struct Point
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
    class SortMisc
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
            int rowNumnber = arr.GetLength(0);
            int colNumber = arr.GetLength(1);

            Point p = new Point(1, -1);

            int currRow = 0, currCol = colNumber - 1;

            while(currCol>0 & currRow<rowNumnber)
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
    }
}
