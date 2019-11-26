using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Misc.Leet
{
    public class Batch5
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

            int sourceX=0, sourceY=0;
            for (int i = 0; i < treeList.Count; i++)
            {
                int currSteps = BFSTree(forest, sourceX,sourceY, treeList[i].Item2, treeList[i].Item3);
                if (currSteps == -1)
                    return -1;
                else
                    steps += currSteps;
                sourceX = treeList[i].Item2;
                sourceY = treeList[i].Item3;
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
            {
                isVisited.Add(new List<bool>());
                for (int col = 0; col < forest[row].Count; col++)
                {

                    isVisited[row].Add(false); 

                }
            }
            //dx,dy denotes the destination
            workingQueue.Enqueue(new Tuple<int, int>(sx,sy));



            while (workingQueue.Count > 0)
            {
                int currentLevelQueueSize = workingQueue.Count;
                for (int num = 0; num < currentLevelQueueSize; num++)
                {
                    Tuple<int, int> current = workingQueue.Dequeue();
                    //step++;
                    if (current.Item1 == dx && current.Item2 == dy)  //we find the destinamtion;
                        return step;
                    else
                    {
                        if (isVisited[current.Item1][current.Item2])
                            continue;

                        isVisited[current.Item1][current.Item2] = true;
                        for (int i = 0; i < 4; i++) // loop the direction;
                        {
                            int newX = current.Item1 + directions[i].Item1;
                            int newY = current.Item2 + directions[i].Item2;
                            if (newX < 0 || newX >= forest.Count || newY < 0 || newY >= forest[0].Count 
                                || isVisited[newX][newY] || forest[newX][newY]==0) //out of the bound or already visited, pr blocked.
                                continue;

                            workingQueue.Enqueue(new Tuple<int, int>(newX, newY));


                        }


                    }
                }
                step++;
            }


            return -1;
        }

       


    }

    //leetcode 380: Insert/delete/getrandom O(1)
    //Design a data structure that supports all following operations in average O(1) time.
    //insert(val) : Inserts an item val to the set if not already present.
    // remove(val): Removes an item val from the set if present.
    // getRandom: Returns a random element from current set of elements.Each element must have the same probability of being returned.
    public class RandomizedSet
    {
        Dictionary<int, int> dict; //the value  of the dict contains the index of the key in the array/list
        List<int> list; // the value of the list contains the key that is mapped to the list

        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            dict = new Dictionary<int, int>();
            list = new List<int>();

        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if(!dict.ContainsKey(val))
            {
                list.Add(val);

                dict.Add(val, list.Count-1);
                
                return true;
            }

            return false;   

        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if(dict.ContainsKey(val))
            {
                int indexForDeleted = dict[val];  
                if(indexForDeleted == list.Count-1) // the last one in the array, then we only need to remove the key from both the dictionary and array{
                {
                    dict.Remove(val);
                    list.RemoveAt(list.Count - 1);
                }
                else //it's not the last one, we need to swap the last one and the one to be deleted in the array
                {
                    int keyForLast = list[list.Count - 1];
                    dict[keyForLast] = indexForDeleted;
                    dict.Remove(val);
                    list.RemoveAt(list.Count - 1);
                    list[indexForDeleted] = keyForLast;
                }

                return true;
            }
            return false;   
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            Random r = new Random();
       
            int index = r.Next() % list.Count;

            return list[index];

        }
    }


    //leetcode 381: Insert/delete/getrandom O(1) -- Duplicated allowed
    //Note: Duplicate elements are allowed.
    // insert(val): Inserts an item val to the collection.
    // remove(val): Removes an item val from the collection if present.
    // getRandom: Returns a random element from current collection of elements.The probability of each element being returned 
    //is linearly related to the number of same value the collection contains.

    public class RandomizedCollection
    {
        Dictionary<int, List<int>> dict; //key, index list pair(list of the index in the array/list
        List<Tuple<int,int>> listKeyPair; //1st is the key, 2nd is the position in the list in dict
        /** Initialize your data structure here. */
        public RandomizedCollection()
        {
            dict = new Dictionary<int, List<int>>();
            listKeyPair = new List<Tuple<int, int>>(); 
        }

        /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
        public bool Insert(int val)
        {
            List<int> currList;
            if (dict.ContainsKey(val))
            {
                currList = dict[val];
//                int lastIndex = listKeys.Count - 1;
                currList.Add(listKeyPair.Count);
                listKeyPair.Add(Tuple.Create(val, currList.Count-1));
                return false;
            }
            else
            {
                currList = new List<int>();
                currList.Add(listKeyPair.Count);
                dict.Add(val, currList);
                listKeyPair.Add(Tuple.Create(val, currList.Count - 1)); //the 2nd of the Tuple is always 0 in this case

                return true;
            }
        }

        /** Removes a value from the collection. Returns true if the collection contained the specified element. */
        public bool Remove(int val)
        {
            if(dict.ContainsKey(val))
            {
                List<int> currList = dict[val];
                int currDeletedIndex = currList[currList.Count - 1];//get the index of the last occurrence in the array.
                if (currList.Count == 1) //this key only contains 1 element, so the key should be removed from the dict
                    dict.Remove(val);
                else
                    currList.RemoveAt(currList.Count - 1); //remove the last appearance from the list;

                //now process the listKeys
                if (listKeyPair.Count == 1) // this is the last item, we only need to remove the key in the list
                    listKeyPair.RemoveAt(0);
                else// there is more than 1 items in the listKey array
                {
                    if (currDeletedIndex != listKeyPair.Count - 1)
                    {
                        listKeyPair[currDeletedIndex] = listKeyPair[listKeyPair.Count - 1]; // move the last item in the list to the currentdeletedIndex;
                        Tuple<int, int> movedItem = listKeyPair[listKeyPair.Count - 1];

                        listKeyPair.RemoveAt(listKeyPair.Count - 1);

                        //now update the orginal key/list information

                        int updateKey = movedItem.Item1;
                        int updateIndex = movedItem.Item2;
                        dict[updateKey][updateIndex] = currDeletedIndex;
                    }
                    //else it's the last item in the array already, we dont' need to move, just remove the last one
                    else {
                        listKeyPair.RemoveAt(listKeyPair.Count - 1);
                    }

                }


                return true;

            }

            return false;
        }

        /** Get a random element from the collection. */
        public int GetRandom()
        {
            Random r = new Random();

            int index = r.Next() % listKeyPair.Count;

            return listKeyPair[index].Item1;

        }
    }

    /**
     * Your RandomizedCollection object will be instantiated and called as such:
     * RandomizedCollection obj = new RandomizedCollection();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */


}
