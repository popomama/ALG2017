using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Misc.Leet
{
    class Batch5
    {
        // Leetcode 675. Cut off trees for golf event
        // You are asked to cut off trees in a forest for a golf event. The forest is represented as a non-negative 2D map, in this map:

        //    0 represents the obstacle can't be reached.
        //    1 represents the ground can be walked through.
        //    The place with number bigger than 1 represents a tree can be walked through, and this positive number represents the tree's height.

        //You are asked to cut off all the trees in this forest in the order of tree's height - always cut off the tree with lowest height first. And after cutting, the original place has the tree will become a grass (value 1).
        //You will start from the point (0, 0) and you should output the minimum steps you need to walk to cut off all the trees.If you can't cut off all the trees, output -1 in that situation.
        //You are guaranteed that no two trees have the same height and there is at least one tree needs to be cut off.

        //Example 1:

        //Input: 
        //[
        // [1,2,3],
        // [0,0,4],
        // [7,6,5]
        //]
        //Output: 6

        //IDEA: use BFS to search the path.
        public int CutOffTree(IList<IList<int>> forest)
        {
            //first we need to sort the tree hight for each location.
            List<Tuple<int, int, int>> treeList = new List<Tuple<int, int, int>> ();
            
            
            for(int row=0; row< forest.Count; row++)
                for(int col=0;col< forest[row].Count; col++)
                {
                    if (forest[row][col] > 1)
                        treeList.Add(new Tuple<int, int, int>(forest[row][col], row, col));

                }

            treeList.Sort();

            int steps=0;

            for (int i = 0; i < treeList.Count; i++)
            {
                int currSteps = BFSTree(forest, 0, 0, treeList[i].Item2, treeList[i].Item3);
                if (currSteps == -1)
                    return -1;
                else
                    steps += currSteps;
            }
            return steps;



        }

        private int BFSTree(IList<IList<int>> forest, int sx, int sy, int dx, int dy)
        {
            int step = 0;
           
//            Tuple<int, int, int> dest = treeList[0];

           // var add = new[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            Tuple<int,int>[] directions =
                { Tuple.Create( -1, 0 ), Tuple.Create( 1, 0 ), Tuple.Create( 0, -1 ), Tuple.Create( 0, 1 ) };

            Queue<Tuple<int, int>> workingQueue = new Queue<Tuple<int, int>>();
            IList<IList<bool>> isVisited = new List<IList<bool>>();
            for (int row = 0; row < forest.Count; row++)
                for (int col = 0; col < forest[row].Count; col++)
                {
                    isVisited[row][col] = false;

                }

            //dx,dy denotes the destination
            workingQueue.Enqueue(new Tuple<int, int>(sx,sy));
            
            while(workingQueue.Count>0)
            {
                Tuple<int, int> current = workingQueue.Dequeue();
                step++;
                if (current.Item1 == dx && current.Item2 == dy)  //we find the destinamtion;
                    return step;
                else
                {
                    if (isVisited[sx][sy] || forest[sx][sy] == 0)
                        return -1;

                    isVisited[sx][sy] = true;
                    for (int i = 0; i < 4; i++) // loop the direction;
                    {
                        int newX = current.Item1 + directions[i].Item1;
                        int newY = current.Item2 + directions[i].Item2;
                        if (newX < 0 || newX >= forest.Count || newY < 0 || newY >= forest[0].Count || isVisited[newX][newY]) //out of the bound or already visited
                            continue;

                        workingQueue.Enqueue(new Tuple<int, int>(newX, newY));

                    }


                }
            }

            return -1;
        }
    }
}
