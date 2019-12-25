﻿using System;
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
            List<Tuple<int, int, int>> treeList = new List<Tuple<int, int, int>>();


            for (int row = 0; row < forest.Count; row++)
                for (int col = 0; col < forest[row].Count; col++)
                {
                    if (forest[row][col] > 1)
                        treeList.Add(new Tuple<int, int, int>(forest[row][col], row, col));

                }

            treeList.Sort();

            int steps = 0;

            int sourceX = 0, sourceY = 0;
            for (int i = 0; i < treeList.Count; i++)
            {
                int currSteps = BFSTree(forest, sourceX, sourceY, treeList[i].Item2, treeList[i].Item3);
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
            Tuple<int, int>[] directions =
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
            workingQueue.Enqueue(new Tuple<int, int>(sx, sy));



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
                                || isVisited[newX][newY] || forest[newX][newY] == 0) //out of the bound or already visited, pr blocked.
                                continue;

                            workingQueue.Enqueue(new Tuple<int, int>(newX, newY));


                        }


                    }
                }
                step++;
            }


            return -1;
        }


        //Leetcode 127: Word Ladder
        //Given two words (beginWord and endWord), and a dictionary's word list, find the length of shortest transformation sequence from beginWord to endWord, such that:
        //    Only one letter can be changed at a time.
        //    Each transformed word must exist in the word list.Note that beginWord is not a transformed word.

        //Note:
        //    Return 0 if there is no such transformation sequence.
        //   All words have the same length.
        //   All words contain only lowercase alphabetic characters.
        //   You may assume no duplicates in the word list.
        //   You may assume beginWord and endWord are non-empty and are not the same.

        //Example 1:
        //Input:
        //beginWord = "hit",
        //endWord = "cog",
        //wordList = ["hot", "dot", "dog", "lot", "log", "cog"]
        //Output: 5
        //Explanation: As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
        //return its length 5.
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {

            if (wordList.Count == 0)
                return 0; // there is no word in the wordlist
            Dictionary<string, List<string>> candidates = new Dictionary<string, List<string>>();
            int wordLength = wordList[0].Length;
            string newKey;
            Dictionary<string, bool> isVisited = new Dictionary<string, bool>();
           


            //precompute what is inside the dictionary by using * as the key
            //for example, h*t will include hat, hot, hit, etc
            foreach (string w in wordList)
            {
                isVisited.Add(w, false);
                for (int i = 0; i < wordLength; i++)
                {
                    newKey = w.Substring(0, i) + '*' + w.Substring(i + 1);
                    if (!candidates.ContainsKey(newKey))
                        candidates.Add(newKey, new List<string>());
                    candidates[newKey].Add(w); // add the current word to the corressponding * list
                }
            }

            //now use the BFS to search from the beginWord until it finds the endWord
            Queue<KeyValuePair<string, int>> queue = new Queue<KeyValuePair<string, int>>();
            queue.Enqueue(new KeyValuePair<string, int>(beginWord, 1));

            KeyValuePair<string, int> currentPair;
            int currentLevel;
            string currentWord;
            string currentKey;

            while (queue.Count != 0)
            {
                currentPair = queue.Dequeue();
                currentWord = currentPair.Key;
                currentLevel = currentPair.Value;

                if (currentWord == endWord)
                    return currentLevel; // we find a match and return the level;

                isVisited[currentWord] = true;
                for (int i = 0; i < wordLength; i++)
                {
                    currentKey = currentWord.Substring(0, i) + '*' + currentWord.Substring(i + 1);
                    if (candidates.ContainsKey(currentKey))
                    {
                        List<string> currentNabors = candidates[currentKey];
                        foreach (string s in currentNabors)
                        {
                            if (isVisited[s] == false)
                                queue.Enqueue(new KeyValuePair<string, int>(s, currentLevel + 1));
                        }
                    }
                }
                //we didn't find match
            }

            return 0;
        }

       
    }

    public class Ladder2
    {
        Dictionary<string, List<string>> candidates;
        int wordLength;
        public Ladder2()
        {
            candidates = new Dictionary<string, List<string>>();

        }
 //       Dictionary<string, List<string>> candidates = new Dictionary<string, List<string>>();
        //int wordLength = wordList[0].Length;

        //this 2nd method uses Bidirectional-BFS to reduce the expansion of the child nodes search
        public int LadderLength2(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
                return 0;
           // Dictionary<string, List<string>> candidates = new Dictionary<string, List<string>>();
             wordLength = wordList[0].Length;
            string newKey;
          
            Dictionary<string, int> isVisitedBegin = new Dictionary<string, int>();
            Dictionary<string, int> isVisitedEnd = new Dictionary<string, int>();

            //precompute what is inside the dictionary by using * as the key
            //for example, h*t will include hat, hot, hit, etc
            foreach (string w in wordList)
            {
               // isVisitedBegin.Add(w, -1);
               // isVisitedEnd.Add(w, -1);
                for (int i = 0; i < wordLength; i++)
                {
                    newKey = w.Substring(0, i) + '*' + w.Substring(i + 1);
                    if (!candidates.ContainsKey(newKey))
                        candidates.Add(newKey, new List<string>());
                    candidates[newKey].Add(w); // add the current word to the corressponding * list
                }
            }

            Queue<KeyValuePair<string, int>> queueBegin = new Queue<KeyValuePair<string, int>>();
            queueBegin.Enqueue(new KeyValuePair<string, int>(beginWord, 1));
            
            Queue<KeyValuePair<string, int>> queueEnd = new Queue<KeyValuePair<string, int>>();
            queueEnd.Enqueue(new KeyValuePair<string, int>(endWord, 1));


            isVisitedBegin.Add(beginWord, 1);
            isVisitedEnd.Add(endWord, 1);


            int level;

            while(queueBegin.Count>0 && queueEnd.Count>0)
            {
                level = CheckVisited(isVisitedBegin, isVisitedEnd, queueBegin);
                if (level > 0) // we find a match
                    return level;
                level = CheckVisited(isVisitedEnd, isVisitedBegin, queueEnd);
                if (level > 0) // we find a match
                    return level;
            }

            return 0;

        }

        int CheckVisited(Dictionary<string, int> beginVisited, Dictionary<string, int> endVisited, Queue<KeyValuePair<string, int>> queue )
        {
            KeyValuePair<string, int> current = queue.Dequeue();
            string currentWord = current.Key;
            int currentLevel = current.Value;

            if (endVisited.ContainsKey(currentWord))//we find a match
                return currentLevel + endVisited[currentWord]-1;

            //if(beginVisited[currentWord]<=0)//not visited yet
            //{
                //if(!beginVisited.ContainsKey(currentWord))
                //    beginVisited.Add(currentWord, currentLevel);
                string currentKey;// = currentWord.Substring(0, i) + '*' + currentWord.Substring(i + 1);
                for (int i = 0; i < wordLength; i++)
                {
                    currentKey = currentWord.Substring(0, i) + '*' + currentWord.Substring(i + 1);
                    if (candidates.ContainsKey(currentKey))
                    {
                        List<string> currentNabors = candidates[currentKey];
                    foreach (string s in currentNabors)
                    {
                        if (!beginVisited.ContainsKey(s))
                        {
                            beginVisited.Add(s, currentLevel + 1);
                            queue.Enqueue(new KeyValuePair<string, int>(s, currentLevel + 1));
                        }
                    }
                    }
                }
            //}

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

    //leetcode 547 Friend Circles
    // There are N students in a class. Some of them are friends, while some are not. Their friendship is transitive in nature. For example, 
    // if A is a direct friend of B, and B is a direct friend of C, then A is an indirect friend of C. And we defined a friend circle is a group of 
    //students who are direct or indirect friends.

    //Given a N* N matrix M representing the friend relationship between students in the class. If M[i][j] = 1, then the ith and jth students are 
    //direct friends with each other, otherwise not.And you have to output the total number of friend circles among all the students.

    //Example 1:

    //    Input: 
    //[[1,1,0],
    // [1,1,0],
    // [0,0,1]]
    //Output: 2
    //Explanation:The 0th and 1st students are direct friends, so they are in a friend circle.
    //The 2nd student himself is in a friend circle.So return 2.

    public class FriendsSearch
    {
        int groupNumber = 0;
        bool[] grouped;

        public int FindCircleNum(int[][] M)
        {
            grouped = new bool[M.Length];

            //use DFS to go through each person
            for (int i = 0; i < M.Length; i++)
            {
                if (!grouped[i])
                { 
                    grouped[i] = true;
                    groupNumber++;
                }
                Queue<int> q = new Queue<int>();
                q.Enqueue(i);
                while(q.Count>0)
                {
                    int current = q.Dequeue();
                    for(int j=0;j<M[current].Length;j++)
                    {
                        if(j != current && M[current][j]==1 && !grouped[j])
                        {
                            grouped[j] = true;
                            q.Enqueue(j);
                        }
                    }
                }

                 //for(int j=0;j<M[i].Length;j++)
                 //{
                 //    if (M[i][j] == 1) // find a new group
                 //    {

                    //        groupNumber--;
                    //        M[i][j] = groupNumber; // mark the groupNumber
                    //        DFSSearch2(i, j, M);

                    //    }
            }
            return groupNumber;


        }

        void DFSSearch2(int sx, int sy, int[][] M)
        {
            Queue<Tuple<int,int>> q = new Queue<Tuple<int, int>>();
            q.Enqueue(Tuple.Create<int, int>(sx, sy));

        }
        void DFSSearch(int sx, int sy, int[][] M)
        {
            Tuple<int,int>[] directions = 
                { Tuple.Create<int, int>(1, 0), Tuple.Create<int, int>(-1, 0), Tuple.Create<int, int>(0, 1), Tuple.Create <int,int>(0,-1) };
            for(int i=0;i<directions.Length;i++)
            {
                int curX = sx + directions[i].Item1;
                int curY = sy + directions[i].Item2;

                if (curX < 0 || curX >= M.Length || curY < 0 || curY >= M[0].Length)
                {
                    continue;
                }
                else
                {
                    if(M[curX][curY]==1)
                    {
                        M[curX][curY] = groupNumber;
                        DFSSearch(curX, curY, M);
                    }
                    //we ignore the current curr point, if it has either 0 or negative#(already visited)
                }


            }
        }
    }

   
}
