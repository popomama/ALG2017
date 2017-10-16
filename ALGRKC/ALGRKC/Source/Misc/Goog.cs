using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALGRKC.Source.Sort;

namespace ALGRKC.Source.Misc
{
    public class Goog
    {
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
                else if (currMax > max)
                {
                    max = currMax;

                }
                currIndex++;


            }

            return max;
        }

        // Implementation of Kadane's algorithm for 1D array. The function 
        // returns the maximum sum and stores starting and ending indexes of the 
        // maximum sum subarray at addresses pointed by start and finish pointers 
        // respectively.
        public static int Kadane(int[] arr, out int start, out int finish)
        {
            int count = arr.Length;
            int max = Int32.MinValue, maxCurrentRun = 0;
            int currentStart = 0;
            start = 0;
            finish = 0;

            for(int i=0;i<count;i++)
            {
                maxCurrentRun += arr[i];
                if (maxCurrentRun < 0)
                {
                    maxCurrentRun = 0;
                    currentStart = i + 1;
                }
                else if (max < maxCurrentRun)
                {
                    max = maxCurrentRun;
                    start = currentStart;
                    finish = i;
                }

            }

            //spectial case: if all elements are negative
            if(max<0)
            {
                for(int i=0;i<count;i++)
                    if(max<arr[i])
                    {
                        max = arr[i];
                        start = i;
                        finish = i;
                    }
            }

            return max;

        }


        //Design and implement an efficient program to find a contiguous subarray within 
        //a one-dimensional array of integers which has the largest sum. It also finds the start/end index
        //Please note that there is at least one positive integer in the input array.
        public static Tuple<int, int, int> LargestSubArraySum2(int[] arr)
        {
            int max = 0, currMax = 0, startIndex = 0, endIndex = 0, currStart = 0;

            int currIndex = 0;
            // int temp;
            while (currIndex < arr.Length)
            {
                currMax = currMax + arr[currIndex];
                if (currMax < 0)
                {
                    currMax = 0;
                    currStart = currIndex + 1;
                }
                else if (currMax > max)
                {
                    max = currMax;
                    startIndex = currStart;
                    endIndex = currIndex;
                }
                currIndex++;


            }

            return new Tuple<int, int, int>(max, startIndex, endIndex);
        }

        //Find a sub-array whose sum is closest to zero rather than that with maximum sum. 
        //Please note that closest to zero doesn’t mean minimum sum
        //solution: The idea is to (1) calculate the sum of the prefix array
        //(2) order the sums 
        //(3) pick up the smallest difference of the two adjacent sums
        //Complexity is O(NlgN), as it's determined by the sorting
        //Note: if all the elements are integer, we may use Hashtable to store the preFix sum array.
        // and check if the value is already in the hashtable/hasmap everytime we get a(next) prefix sum.
        // so the complexity can be O(N)
        public static int SubArrayClosestToZero(int[] arr)
        {
            int[] prefixSum = new int[arr.Length];

            //calculate the prefix sum , O(N)
            prefixSum[0] = arr[0];
            for(int i =1;i<arr.Length;i++)
            {
                prefixSum[i] = prefixSum[i - 1] + arr[i];
            }

            //sort the sums(O(NlgN))
            QuickSort qc = new QuickSort();
            qc.QC(prefixSum, 0, prefixSum.Length - 1);

            int min = Int32.MaxValue;
            int currDiff = 0;
            //find the min difference -- O(N)
            for(int i=1;i<prefixSum.Length;i++)
            {
                currDiff = (prefixSum[i] - prefixSum[i - 1]);
                if (currDiff < min)
                    min = currDiff;
            }

            return min;

        }

        //Find a sub-array whose sum is equal to K.
        //the array only contains integers
        //Stragegy: use prefix array and hashtable
        public static Tuple<int, int>  SubArraySum(int[] arr, int sum)
        {
            Tuple<int, int> pair;// = new Tuple<int, int>();
            int[] prefixSum = new int[arr.Length];

            //calculate the prefix sum , O(N)
            prefixSum[0] = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + arr[i];
            }

            HashSet<int> ht = new HashSet<int>();
            for(int i =0;i<arr.Length;i++)
            {
                if (prefixSum[i] == sum)
                {
                    pair = new Tuple<int, int>(0, i);
                    return pair;
                }
                else if (ht.Contains(sum - prefixSum[i]) || ht.Contains(prefixSum[i] - sum))
                {
                    pair = new Tuple<int, int>(0, i);// needs to recode here
                    return pair;
                }
                else
                    ht.Add(prefixSum[i]);
                
                
            }

            return new Tuple<int, int>(-1, -1);//no found



        }

        //Given a 2D array, find the maximum sum subarray in it
        //The main function that finds maximum sum rectangle in M[][]
        //Solution: fix the left column and right column, calculate the sum of each row, call 1-D Kadane method.
        //Complexity: O(N^3)
        //The brutal force method will cost O(N^4)
        void FindMaxSum2D(int[,] M)
        {
            int rowNum = M.GetLength(0);
            int colNum = M.GetLength(1);
            int[] rowSum = new int[rowNum];
            int max = Int32.MinValue;
            int currentMax;
            int rowStart=-1, rowEnd=-1, colStart=-1, colEnd=-1, currentStart, currentEnd;

            for (int leftC = 0; leftC < colNum; leftC++)
            {
                for (int i = 0; i < rowNum; i++)
                    rowSum[i] = 0;
                for (int rightC = leftC; rightC < colNum; rightC++)
                {
                    //to each row, calculate the rowsum bewtween the leftColumn and the rightCollumnn 
                    for (int i = 0; i < rowNum; i++)
                        rowSum[i] += M[i, rightC];

                    currentMax = Kadane(rowSum, out currentStart, out currentEnd);
                    if (currentMax > max)
                    {
                        rowStart = currentStart;
                        rowEnd = currentEnd;
                        colStart = leftC;
                        colEnd = rightC;

                    }
                }

            }

            Console.WriteLine("Rows : " + rowStart + ", " + rowEnd);
            Console.WriteLine("Columns : " + colStart + ", " + colEnd);
            Console.WriteLine("Sum : " + max);
        }


        //find all permutaions of a string, assuming there is no dup in the original strings.
        //assuming there is no duplicates
        public static void GetPerms(string org)
        {
            int length = org.Length;
            char[] result = new char[length];
            char[] orgArr= org.ToCharArray();
            GetPerms(orgArr, 0, length - 1, result);
        }

        //assuming there is no duplicate.
        static void GetPerms(char[] orgString, int start, int end, char[] result)
        {
            if (start == end) //last element of the string
            {
                //print;
                result[start] = orgString[start];
                Console.WriteLine(result);
                return;
            }


            for (int i = start; i <= end; i++)
            {
                //if (!(orgString[start] == orgString[i] && i != start))//only process when the two elements are not equal. this eliminates the duplicates
                //{

                swap(orgString, start, i);//swap the current with the ones right one by one
                //the basic idea is to fix the ith element, and recursively call to permutate (ith+1,end)
                result[start] = orgString[start];
                GetPerms(orgString, start + 1, end, result);
                swap(orgString, start, i);// swap it back
                //}


            }

            

        }


        //we now address the string that has duplicates and find all the permutations.
        static public void GetPerm(char[] org, int start, int end, char[] result)
        {

        }


        //the idea is to recursive call this method. To every call, it loop through the characters in the rest string,
        //from index 0 to the whole lengh one by one. When picking the j(index) character in the rest, the code compares
        //the j(index) element with those to its left(index 0 to j-1), if one of the elements(0 to j-1) is equal to j element,
        //then we skip this element as its a duplicate
        static public void GetPermsForDups(String prefix, String rest)
        {
            int nLeft = rest.Length;
            if(nLeft == 0)// nothing is left, so prefix passed is one permutation
            {
                Console.WriteLine(prefix);
                return;
            }


            //now go through the rest string from left to right, pick one at a time and append it to prefix
            for(int i =0;i<rest.Length;i++ )
            {
                char current = rest[i];
                bool bDuplicate = false;
                for(int j=0;j<i;j++)
                {
                    if (rest[j] == current)// this means the current is a duplicate, which has appeared already at this level, we can ignore.
                        bDuplicate = true;  
                }

                if(!bDuplicate) //continue processing only if current is NOT a duplicate at this level
                {
                    string newPrefix = prefix + current;//it's important to create a new variable to record both newPrefix and new Rest
                    string newRest = rest.Remove(i, 1);// changing the value on the original variable will impact the caller!!
                    GetPermsForDups(newPrefix, newRest);
                    
                }
            }
        }

       static public void PermutateDuplicate(String prefix, String rest)
        {
            int N = 0;
            if (rest != null)
                N = rest.Length;
            if (N == 0)
            {
                Console.WriteLine(prefix);
            }
            else
            {
                for (int i = 0; i < rest.Length; i++)
                {


                    //test if rest[i] is unique.
                    bool found = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (rest[i] == rest[j]) //rest[j]==rest[i]
                        {
                            found = true;
                        }
                    }
                    if (found)
                        continue;
                    String newPrefix = prefix + rest[i];
                    String newRest = rest.Substring(0, i) + rest.Substring(i + 1, N-1-rest.Substring(0,i).Length);
                    PermutateDuplicate(newPrefix, newRest);
                }
            }
        }

        static void swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        //Array f[0..F - 1] contains the names of people who work at Cornell, in alphabetical order.
        //Array g[0..G - 1] contains the names of people on welfare at Ithaca, in alphabetical order. 
        //Thus, neither array contains duplicates and both arrays are monotonically increasing: 
        //f[0] < f[1] < f[2] < … < f[F - 1]
        //g[0] < g[1] < g[2] < … < g[G - 1]
        //Count the number of people who are presumably not crooks: those that appear in at least one array but not in both.
        static public List<int> FindNonCrooksNumber(int[] F, int[] G)
        {
            //we simply the siturmation by assuming that F and G contains integer and both are monotonically increasing.
            int numF = F.Length;
            int numG = G.Length;
            //int totalNonCrooks = 0;
            List<int> result = new List<int>();

            int i = 0, j = 0;
            while(i<numF&&j<numG)
            {
                if(F[i]==G[j])
                {
                    //found non-Crook
                    i++;
                    j++;
                }
                else if (F[i]<G[j])
                {
                    
                    result.Add(F[i]);
                    i++;
                }
                else
                {
                
                    result.Add(G[j]);
                    j++;

                }

            }

            while(i<numF)
                result.Add(F[i++]);
            while (j < numG)
                result.Add(G[j++]);

            return result;
        }


        //Let X[1, . . . , n] and Y[1, . . . , n] be two arrays, each containing n numbers already in sorted
        //order.Give an O(log n)-time algorithm to find the median of all 2n elements in arrays X and Y
        static public double FindMedianNumber(int[] X, int[] Y, int n)
        {
            //solution 1(straighforward):
            //go through the two arrays until it finds the nth and n+1th element
            //cost is O(N)

            //solution2:
            //initialize FindMedianHelp(X,0,n-1,Y,0,n-1) call FindMedianHelp(X,xStart,xEnd, Y, yStart, yEnd)
            //find the median of both arrays m1, m2
            //if(m1==m2) then return m1 as m1 as the median
            //if(m1<m2) then recurse FindMedian(X,m1, xEnd, Y, yStart, m2);
            //if(m1>m2) then resurce FindMedian(X, xStart, m1, m2, yEnd);
            //repeat the above until both X and Y have 2 numbers left.
            //Now it turns to FindMedian(X[xStart], X[xEnd], Y[yStart], Y[yEnd]) == (max(X[xStart], Y[yStart]) + min(X[xEnd], Y[yEnd]))/2,
            //Cost O(lnN)

            return FindMedianHelper(X, 0, n-1, Y, 0, n-1);

        }

        //Let X[1, . . . , n] and Y[1, . . . , n] be two arrays, each containing n numbers already in sorted
        //order.Give an O(log K)-time algorithm to find the k-the elements in combined arrays X and Y
        static public int FindKthNumber(int[] X, int[] Y, int K)
        {
            //the normal way is to go through X and Y (similar to merge sort) to get the K-th element (O(K))
            //use divide and conquer will give O(logK)
            int nXLength = X.Length;
            int nYLength = Y.Length;

            return FindKthNumberHelper(X, 0, nXLength - 1, Y, 0, nYLength - 1, K);

        }

        private static int FindKthNumberHelper(int[] X, int xStart, int xEnd, int[] Y, int yStart, int yEnd, int K)
        {
            int xLength = xEnd - xStart + 1;
            int yLength = yEnd - yStart + 1;

            if ((K < 0) || K > (xLength + yLength)) 
                 throw new Exception("Wrong Data");

            //first process the bordline cases.
            if(K == 0)
                return Math.Min(X[0], Y[0]);

            if (K == 1)
            {
                if (X[0] < Y[0])
                {
                    if (xLength > 1)
                        return Math.Min(X[1], Y[0]);
                    else
                        return Y[0];
                }
                else
                {
                    if (yLength > 1)
                        return Math.Min(X[0], Y[1]);
                    else
                        return X[0];
                }
            }


            //now process the normal case
            
            int nMid = K / 2;
            int i = Math.Min(nMid, xEnd - xStart);
            int j = Math.Min(nMid, yEnd - yStart);
            if (X[i-1] < Y[j-1])// the 2nd half of Y is out
                return FindKthNumberHelper(X, xStart, xEnd, Y, yStart, j, K / 2);
            else//the 2nd half of X is out
                return FindKthNumberHelper(X, xStart, i, Y, yStart, yEnd, K / 2);
        }



        //helper function for FindMedianNumber
        static double  FindMedianHelper(int[] X, int xStart, int xEnd, int[] Y, int yStart, int yEnd)
        {
            if((xEnd-xStart)==2) // each array only has 2 elements left, we come to the basic case;
                return (Math.Max(X[xStart], Y[yStart]) + Math.Min(X[xEnd], Y[yEnd]) )/2;

            int xMedianIndex =(xStart+xEnd)/2;
            int yMedianIndex = (yStart+yEnd)/2;
            int m1 = X[xMedianIndex], m2 = Y[yMedianIndex];

            if(m1==m2)
                return m1;
            if(m1<m2)
                return FindMedianHelper(X, xMedianIndex, xEnd, Y, yStart, yMedianIndex);
            else//m1>m2
                return FindMedianHelper(X, xStart, xMedianIndex, Y, yMedianIndex, yEnd);

            
        }

        //Get the Missing and Duplicate elements from an Array
        //Given an unsorted array of size n. Array elements are in range from 1 to n. One number from set {1, 2, …n} is missing and 
        //one number occurs twice in array. Find these two numbers.
        //      Examples:
        //          arr[] = {3, 1, 3}
        //          Output: 2, 3   // 2 is missing and 3 occurs twice 
        //          arr[] = {4, 3, 6, 2, 1, 1}
        //          Output: 1, 5  // 5 is missing and 1 occurs twice 
        static public void GetDupAndMissingElements(int[] arr)
        {
            int length = arr.Length;
            //assuming the missing one and the duplicate one are x and y(or y and x , as we don't know which is which)
            int result;
            int nBits = (int)Math.Ceiling(Math.Log(2, length));

            //step 1
            //XOR each number in the array with 1-n, the result will be x ^ y as all the other numbers arr nullified
            result = arr[0];
            for (int i = 1; i < length; i++)
                result = result ^ arr[i];

            for (int i = 1; i <= length; i++)
                result = result ^ i;


            //step 2
            //find the first bit that is 1, which means on that bit x and y has different value(one has 1 and the other has 0)
            int j = 1;
            while((j & result)==0 && j>0)
            {
                j = j << 1;
            }

            //step 3
            //Divide the original array into two parts. One has 0 value on the j-th bit, the other has 1 value on the j-th bit 
            int oneOnJth = 0, zeroOnJth = 0;

            for(int i=0;i<length;i++)
            {
                if ((j & arr[i]) == 0) //arr[i] has 0 on the j-th bit
                    oneOnJth ^= arr[i];
                else //arr[i] has 1 on the j-th bit
                    zeroOnJth ^= arr[i];
            }

           //step 4
           //now we XOR oneOnJth with each element from 1-n whose j-th bit is one, the result is the missing one or the duplicate one
           for(int i=1;i<=length;i++)
           {
                if ((i & j) == 1)
                    oneOnJth ^= i;
           }
            //now we XOR oneOnJth with each element from 1-n whose j-th bit is zero, the result is the missing one or the duplicate one
            for (int i = 1; i <= length; i++)
            {
                if ((i & j) == 0)
                    zeroOnJth ^= i;
            }

            Console.WriteLine("dup or missing : " + zeroOnJth);
            Console.WriteLine("dup or missing : " + oneOnJth);

            return;
        }
    }

}
