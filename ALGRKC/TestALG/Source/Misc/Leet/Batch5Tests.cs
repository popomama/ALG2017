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
            result    =rs.Insert(1);
            result = rs.Remove(2);
            result = rs.Insert(2);
            int randonValue  = rs.GetRandom();
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
            int groups= fs.FindCircleNum(friends);

        }
    }
}