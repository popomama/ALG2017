using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGRKC.Source.Misc.Leet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ALGRKC.Source.Misc.Leet.Tests
{
    [TestClass()]
    public class Batch5Tests
    {
        [TestMethod()]
        public void CutOffTreeTest()
        {

            Batch5 b5 = new Batch5();
            List<IList<int>> forest = new List<IList<int>>();
            forest.Add(new List<int> { 1, 2, 3 });
            forest.Add(new List<int> { 0, 0, 0 });
            forest.Add(new List<int> { 7, 6, 5 });
            //forest = {
            //    { 1,2,3},
            //    { 0,0,4},
            //    { 7,6,5}
            //};

            int steps = b5.CutOffTree(forest);
            // [
            // [1,2,3],
            // [0,0,4],
            // [7,6,5]
            //]


        }

        [TestMethod()]
        public void RandomizedSetTest()
        {
            RandomizedSet rs = new RandomizedSet();
            bool result;
            result = rs.Insert(1);
            result = rs.Remove(2);
            result = rs.Insert(2);
            int randonValue = rs.GetRandom();
            result = rs.Remove(1);
            result = rs.Insert(2);
            randonValue = rs.GetRandom();

        }


        [TestMethod()]
        public void RandomizedCollectionTest()
        {
            RandomizedCollection rs = new RandomizedCollection();
            bool result;
            int randonValue;// = rs.GetRandom();

            result = rs.Insert(4);
            result = rs.Insert(3);
            result = rs.Insert(4);
            result = rs.Insert(2);
            result = rs.Insert(4);

            // randonValue = rs.GetRandom();

            result = rs.Remove(4);
            result = rs.Remove(3);
            result = rs.Remove(4);
            result = rs.Remove(4);

            randonValue = rs.GetRandom();

            //            result = rs.Remove(1);

        }

        [TestMethod()]
        public void FriendsCircleTest()
        {

            //int[][] friends = new int[3][];

            //friends[0] = new int[3] { 1, 1, 0 };
            //friends[1] = new int[3] { 1, 1, 0 };
            //friends[2] = new int[3] { 0, 0, 1 };
            //            friends[3] = new int[4] { 1, 0, 1, 1 };


            int[][] friends = new int[4][];

            friends[0] = new int[4] { 1, 0, 0, 1 };
            friends[1] = new int[4] { 0, 1, 1, 0 };
            friends[2] = new int[4] { 0, 1, 1, 1 };
            friends[3] = new int[4] { 1, 0, 1, 1 };

            FriendsSearch fs = new FriendsSearch();
            int groups = fs.FindCircleNum(friends);

        }

        [TestMethod()]
        public void LadderLengthTest()
        {
            string begingWord = "hit", endWord = "cog";
            string[] wordList = { "hot", "dot", "dog", "lot", "log", "cog" };
            Batch5 b5 = new Batch5();
            int length = b5.LadderLength(begingWord, endWord, wordList);

        }



        [TestMethod()]
        public void LadderLengthTest2()
        {
            string begingWord = "hit", endWord = "cog";
            string[] wordList = { "hot", "dot", "dog", "lot", "log" };
            Ladder2 l2 = new Ladder2();
            int length = l2.LadderLength2(begingWord, endWord, wordList);

        }

        [TestMethod()]
        public void VideoStitchingTest()
        {

            int[][] clips = new int[][]
                //{ new int[] {0, 1},
                //new int[] {6, 8},new int[] {0, 2},new int[] {5, 6},new int[] {0, 4},new int[] {0, 3}, new int[]{6, 7},
                //new int[] {1, 3},new int[] {4, 7},new int[] {1, 4},new int[]{2, 5}, new int[]{2, 6},new int[] {3, 4},new int[]{4, 5},
                //new int[] {5, 7},new int[] {6, 9}};
                { new int[] {0, 2},
                 new int[] {4, 8},
                };

            Batch5 b5 = new Batch5();
            int num = b5.VideoStitching(clips, 5);


        }

        [TestMethod()]
        public void NextLargerNodesTest()
        {
            Batch5 b5 = new Batch5();
            // ListNode node;
            int[] arr = { 2, 7, 4, 3, 5 };
            ListNode head = new ListNode(arr[0]);
            ListNode cur = head;
            for (int i = 1; i < arr.Length; i++)
            {
                ListNode next = new ListNode(arr[i]);
                cur.next = next;
                cur = next;

            }

            int[] res = b5.NextLargerNodes(head);


        }

        [TestMethod()]
        public void ShortestAlternatingPathsTest()
        {
            //            3
            //[[0, 1],[1,2]]
            //[]

            Batch5 b5 = new Batch5();
            int n = 3;
            int[][] redEdges = new int[][]
               //{ new int[] {0, 1},
               //new int[] {6, 8},new int[] {0, 2},new int[] {5, 6},new int[] {0, 4},new int[] {0, 3}, new int[]{6, 7},
               //new int[] {1, 3},new int[] {4, 7},new int[] {1, 4},new int[]{2, 5}, new int[]{2, 6},new int[] {3, 4},new int[]{4, 5},
               //new int[] {5, 7},new int[] {6, 9}};
               { new int[] {0, 1},
                 new int[] {0,2},
               };

            int[][] blueEdges = new int[][] { };

            int[] ans = b5.ShortestAlternatingPaths(n, redEdges, blueEdges);


        }

        [TestMethod()]
        public void SmallestSufficientTeamTest()
        {
            //["java","nodejs","reactjs"]
            //[["java"],["nodejs"],["nodejs","reactjs"]]

            Batch5 b5 = new Batch5();
            string[] requiredSkills = { "java", "nodejs", "reactjs" };
            List<string>[] people = new List<string>[3];
            for (int i = 0; i < 3; i++)
                people[i] = new List<string>();
            people[0].Add("java");
            people[1].Add("nodejs");

            people[2].Add("java");
            people[2].Add("nodejs");


            int[] smallteam = b5.SmallestSufficientTeam(requiredSkills, people);




        }

        [TestMethod()]
        public void LongestWPITest()
        {
            int[] hours = {9,9,6,0,6,6,9 };

            Batch5 b5 = new Batch5();
            int WPI = b5.LongestWPI(hours);
            }
    }
}