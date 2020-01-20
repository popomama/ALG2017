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

        //Leetcode  1129: Shortest path with alternating color
        //Consider a directed graph, with nodes labelled 0, 1, ..., n-1.  In this graph, each edge is either red or blue, and there could be self-edges or parallel edges.

        //Each [i, j] in red_edges denotes a red directed edge from node i to node j.  Similarly, each [i, j] in blue_edges denotes a blue directed edge from node i to node j.

        //Return an array answer of length n, where each answer[X] is the length of the shortest path from node 0 to node X such that the edge colors alternate along the path (or -1 if such a path doesn’t exist).

        //Example 1:

        //Input: n = 3, red_edges = [[0,1],[1,2]], blue_edges = []
        //Output: [0,1,-1]
        //Example 2:

        //Input: n = 3, red_edges = [[0,1]], blue_edges = [[2,1]]
       // Output: [0,1,-1]
       // Example 3:

        //Input: n = 3, red_edges = [[1,0]], blue_edges = [[2,1]]
        //Output: [0,-1,-1]
        //Example 4:

        //Input: n = 3, red_edges = [[0,1]], blue_edges = [[1,2]]
        //Output: [0,1,2]
        //Example 5:

        //Input: n = 3, red_edges = [[0,1],[0,2]], blue_edges = [[1,0]]
        //Output: [0,1,1]
        //Constraints:

        //1 <= n <= 100
        //red_edges.length <= 400
        //blue_edges.length <= 400
        //red_edges[i].length == blue_edges[i].length == 2
        //0 <= red_edges[i][j], blue_edges[i][j] < n
        public int[] ShortestAlternatingPaths(int n, int[][] red_edges, int[][] blue_edges) {

            //isVisitedRbool[] isVisitedR, isVisitedB;
            int[] answer = Enumerable.Repeat(-1, n).ToArray<int>(); //initialize the answer to -1;
            //Dictionary<int, int[]> redList, blueList;

            HashSet<int>[] redList, blueList;
            redList = new HashSet<int>[n];
            blueList = new HashSet<int>[n];
            for(int i=0;i<n;i++)
            {
                redList[i] = new HashSet<int>();
                blueList[i] = new HashSet<int>();
            }



            for (int i =0;i<red_edges.Length;i++)
            {
                //if (redList[red_edges[i][0]] == null)
                //    redList[red_edges[i][0]] = new HashSet<int>();
                redList[red_edges[i][0]].Add(red_edges[i][1]);
            }
            for (int i = 0; i < blue_edges.Length; i++)
            {
                //if (blueList[blue_edges[i][0]] == null)
                //    blueList[blue_edges[i][0]] = new HashSet<int>();
                blueList[blue_edges[i][0]].Add(blue_edges[i][1]);
            }

            bool[] seen_red = Enumerable.Repeat(false,n).ToArray<bool>(), seen_blue = Enumerable.Repeat(false,n).ToArray<bool>();

            //each item in the queue denotes a node, key is the node #, value denotes the color of the edge via which the node is reached
            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();

            queue.Enqueue(new KeyValuePair<int, int>(0, 0)); // 0 denotes we get to the currentNode via red edge
            queue.Enqueue(new KeyValuePair<int, int>(0, 1)); // 1 denotes we get to the currentNode via blue edge

            KeyValuePair<int, int> current;
            int currentNode, corlorReachedToCurrent, currentCount, colorNext;
            int steps = 0;
            while(queue.Count>0) // Use BFS, check if we still have node to process at current level
            {
                currentCount = queue.Count;

                while (currentCount > 0) // loop the nodes at the current level one by one
                {
                    current = queue.Dequeue(); // get the current pair
                    corlorReachedToCurrent = current.Value;
                    currentNode = current.Key;


                    answer[currentNode] = answer[currentNode] >= 0 ? Math.Min(answer[currentNode], steps) : steps; // if the currentNode was visited before, then it may already have a value. In this case, we takes the smaller between the last value and the current steps.
                    colorNext = 1 - corlorReachedToCurrent;

                    HashSet<int>[] nextBatch = colorNext == 0 ? redList : blueList; //
                    bool[] seenList = colorNext == 0 ? seen_red : seen_blue;
                    foreach (int i in nextBatch[currentNode])
                    {
                        if (seenList[i]) 
                            continue;
                        else
                        {
                            seenList[i] = true;
                            queue.Enqueue(new KeyValuePair<int, int>(i, colorNext));
                        }
                    }

                    currentCount--; // decrement of the count in the queue for current level



                }

                steps++; // we finish processing the current level, and will go to the next level


            }


            return answer;
        }

        //Leetcode 1125 Smallest Sufficient Team
        //In a project, you have a list of required skills req_skills, and a list of people.  The i-th person people[i] contains a list of skills that person has.
        //        Consider a sufficient team: a set of people such that for every required skill in req_skills, there is at least one person in the team who has that skill.We can represent these teams by the index of each person: for example, team = [0, 1, 3] represents the people with skills people[0], people[1], and people[3].
        //Return any sufficient team of the smallest possible size, represented by the index of each person.
        //        You may return the answer in any order.  It is guaranteed an answer exists.


        //        Example 1:
        //Input: req_skills = ["java", "nodejs", "reactjs"], people = [["java"], ["nodejs"], ["nodejs","reactjs"]]
        //Output: [0,2]
        //        Example 2:
        //Input: req_skills = ["algorithms","math","java","reactjs","csharp","aws"], people = [["algorithms","math","java"],["algorithms","math","reactjs"],["java","csharp","aws"],["reactjs","csharp"],["csharp","math"],["aws","java"]]
        //Output: [1,2]
        public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people)
        {
            int skillNum = req_skills.Length;
            int totalCombinations = 1 << skillNum;

            List<int>[] path = new List<int>[totalCombinations];
            path[0] = new List<int>();

            //build skill set hashtable
            Dictionary<string, int> skillsHash = new Dictionary<string, int>();
            for (int i = 0; i < req_skills.Length; i++)
                skillsHash.Add(req_skills[i], i);

            for (int i = 0;i < people.Count;i++)
            {
                List<string> p = people[i].ToList<string>(); // get the skill list of the current person

                int currentPersonSkill = 0;

                //convert each person's skill to an integer(bit representation)
                foreach (string skill in p)
                {
                    currentPersonSkill |= 1 << skillsHash[skill]; // OR each skill to get the unio
                }

                if(currentPersonSkill==0) // current person doesn't contain any skill, so just skip this person
                {
                    continue; 
                }

                for(int skills=0;skills< totalCombinations; skills++)
                {
                    int skilljoin = skills | currentPersonSkill; // union current peroon's skill with each skill combbination

                    if (skilljoin == skills || path[skills] == null) // if the unioned skill equals the current combination(no new skills added) or the existing combined skills can't be reached
                        continue;

                    List<int> candidate = new List<int>(path[skills]);

                    if(path[skilljoin] ==null  || path[skilljoin].Count> candidate.Count )
                    {
                        candidate.Add(i);
                        path[skilljoin] = candidate;
                    }

                    


                }

            }

            //now, get the result
            int minPersonNumber = path[totalCombinations - 1].Count;
            int[] result = new int[minPersonNumber];
            for (int i = 0; i < minPersonNumber; i++)
                result[i] = path[totalCombinations - 1][i];


            return result;
            




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



        //Leetcode 1024: Stiching Video
        //You are given a series of video clips from a sporting event that lasted T seconds.  These video clips can be overlapping with each other and have varied lengths.

        //        Each video clip clips[i] is an interval: it starts at time clips[i][0] and ends at time clips[i][1].  We can cut these clips into segments freely: for example, a clip[0, 7] can be cut into segments[0, 1] + [1, 3] + [3, 7].

        //Return the minimum number of clips needed so that we can cut the clips into segments that cover the entire sporting event ([0, T]).  If the task is impossible, return -1.



        //Example 1:

        //Input: clips = [[0,2],[4,6],[8,10],[1,9],[1,5],[5,9]], T = 10
        //Output: 3
        //Explanation: 
        //We take the clips [0,2], [8,10], [1,9]; a total of 3 clips.
        //Then, we can reconstruct the sporting event as follows:
        //We cut [1,9]
        //        into segments [1,2] + [2,8] + [8,9].
        //Now we have segments [0,2] + [2,8] + [8,10]
        //        which cover the sporting event [0, 10].

        //Example 2:

        //Input: clips = [[0,1],[1,2]], T = 5
        //Output: -1
        //Explanation: 
        //We can't cover [0,5] with only [0,1] and [0,2].
        public int VideoStitching2(int[][] clips, int T)
        {

            if (clips.Length == 0) return -1;
            IComparer< int[]> myComparer = new ReverseComparer(); ;
            Array.Sort(clips, myComparer);
            
            int start = clips[0][0], end = clips[0][1], i = 1, count = 1;
            if (start > 0) return -1;
            else if (end >= T) return 1;
            while(i<clips.Length && end<T && clips[i][0] <= end) {
                int max = end;
                while(i<clips.Length && clips[i][0] <= end) {
                    max = Math.Max(max, clips[i][1]);
                    i++;
                }
                end = max;
                count++;
            }
            return end >= T? count : -1;
        }

        public int VideoStitching(int[][] clips, int T)
        {

            if (clips.Length == 0) return -1;
            IComparer<int[]> myComparer = new ReverseComparer(); ;
            Array.Sort(clips, myComparer);

            int start = clips[0][0], end = clips[0][1];
            int max=end, count = 1;
            int current = 1; 
            if (start > 0) return -1;
            else if (end >= T) return 1;
            while (current < clips.Length && max <T && clips[current][0] <= end)
            {                
                while(current<clips.Length &&   clips[current][0]<=end) // there is still overlap
                {
                    if (clips[current][1] > max)
                        max = clips[current][1];
                    current++;
                }

                count++;// we need another clip
                end = max;

            }

            if (max >= T)
                return count;
            else
                return -1;
           

            
        }

        //Leetcode 1019: Next greater Node in Linked List
        //We are given a linked list with head as the first node.  Let's number the nodes in the list: node_1, node_2, node_3, ... etc.

        //Each node may have a next larger value: for node_i, next_larger(node_i) is the node_j.val such that j > i,
        //node_j.val > node_i.val, and j is the smallest possible choice.  If such a j does not exist, the next larger 
        //value is 0.
        // Return an array of integers answer, where answer[i] = next_larger(node_{ i + 1}).

        //Note that in the example inputs(not outputs) below, arrays such as [2,1,5] represent the serialization of a linked list with a head node value of 2, second node value of 1, and third node value of 5.
        //Example 1:

        //Input: [2,1,5]
        //        Output: [5,5,0]

        //        Example 2:
        //Input: [2,7,4,3,5]
        //        Output: [7,0,5,5,0]

        //        Example 3:
        //Input: [1,7,5,1,9,2,5,1]
        //        Output: [7,9,9,9,0,5,0,0]
        //        Note:

        //    1 <= node.val <= 10^9 for each node in the linked list.
        //    The given list has length in the range[0, 10000].

        public int[] NextLargerNodes(ListNode head)
        {
            int nextIndex = 1;

            if (head == null)
                return null;
            List<KeyValuePair<int, int>> result = new List<KeyValuePair<int, int>>();
            //key is the index and value is the value of the node
            Stack<KeyValuePair<int, int>> s = new Stack<KeyValuePair<int, int>>();
            s.Push(new KeyValuePair<int, int>(0, head.val));
            ListNode nextNode = head.next;

            while(s.Count !=0 && nextNode!=null)
            {
                KeyValuePair<int, int> currentLast = s.Peek();
                if(nextNode.val<=currentLast.Value)
                {
                    s.Push(new KeyValuePair<int, int>(nextIndex, nextNode.val));
                }
                else
                {
                    result.Add(new KeyValuePair<int, int>(currentLast.Key, nextNode.val)); //add to the result
                    s.Pop();//pop the currentLast;
                    while(s.Count!=0)
                    {
                        currentLast = s.Peek();
                        if (nextNode.val > currentLast.Value)
                        {
                            result.Add(new KeyValuePair<int, int>(currentLast.Key, nextNode.val)); //add to the result
                            s.Pop();//pop the currentLast;
                        }
                        else
                            break;
                       
                           

                    }

                    s.Push(new KeyValuePair<int, int>(nextIndex, nextNode.val)); 
                }

                nextIndex++;
                nextNode = nextNode.next;
            }

            while(s.Count!=0) // all remaining ones doesn't have next bigger value, so set them to 0
            {
                KeyValuePair<int, int> currentPair = s.Pop();
                result.Add(new KeyValuePair<int, int>(currentPair.Key, 0));
            }

            int[] resultArr = new int[nextIndex];
            for(int i=0;i<nextIndex;i++)
            {
                resultArr[result[i].Key] = result[i].Value;
            }

            return resultArr;


        }


    }

    public class ListNode
    {
     public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
    }
     public class ReverseComparer : IComparer<int[]>
    {
        //each element in this case is 1-DIM array including 2 numbers(start, end in an interval))
        // first compare the start position and then compare the end position
        public int Compare(int[] a, int[] b)
        {
            if (a[0] != b[0]) 
                return a[0] - b[0];
            else 
                return b[1] - a[1];
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
