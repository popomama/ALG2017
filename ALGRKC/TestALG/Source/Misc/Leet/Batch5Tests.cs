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
            forest.Add(new List<int> { 0,0,0 });
            forest.Add(new List<int> { 7,6,5 });
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
}
}