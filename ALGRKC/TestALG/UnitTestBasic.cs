using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ALGRKC.Source.Basic;


namespace TestALG
{
    [TestClass]
    public class Basic
    {
        [TestMethod]
        public void TestBag()
        {
            Bag<int> bag = new Bag<int>();
            for (int i = 0; i < 10; i++)
                bag.Add(i);
            int val = 9;
            foreach (int item in bag)
            {

                Console.Write(item + " ");
                Assert.AreEqual(item, val);
                val--;
            }

            Console.WriteLine();

        }
    }
}
