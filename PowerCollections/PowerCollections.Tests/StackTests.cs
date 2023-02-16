using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections;


namespace Wintellect.PowerCollections.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Count_Should_Be_Zero_EmptyStack()
        {
            Stack<bool> items = new Stack<bool>(5);
            int expected = 0;

            Assert.AreEqual(expected, items.Count);
        }

        [TestMethod]
        public void Capacity_Should_Be_Equal_ToInput()
        {
            int input = 15;
            Stack<bool> items = new Stack<bool>(input);

            Assert.AreEqual(input, items.Capacity);
        }

        [TestMethod]
        public void GetEnumerator_Should_Return_ReversedArray_That_We_Push()
        {
            Stack<int> items = new Stack<int>(5);
            int[] input = new int[4];

            input[0] = 4;
            input[1] = 2;
            input[2] = 6;
            input[3] = 8; 

            foreach (int num in input)
            {
                items.Push(num);
            }

            var itemsEnumerable = from num in items select num;
            itemsEnumerable = itemsEnumerable.Reverse();

            CollectionAssert.AreEqual(input, itemsEnumerable.ToArray());
        }

        [TestMethod]
        public void Constructor_With_Parameter() 
        {
            Stack<int> items = new Stack<int>(10);
        }

        [TestMethod]
        public void Constructor_With_Negative_Parameter()
        {
            Stack<int> items;

            Assert.ThrowsException<InvalidOperationException>(() => items = new Stack<int>(-1));
        }

        [TestMethod]
        public void Push_NormalWork()
        {
            Stack<int> items = new Stack<int>(10);
            int expected = 12;

            items.Push(expected);

            Assert.AreEqual(expected, items.Top());
            Assert.AreEqual(1, items.Count);
        }

        [TestMethod]
        public void Push_StackSize_Overflow()
        {
            Stack<int> items = new Stack<int>(0);

            Assert.ThrowsException<InvalidOperationException>(() => items.Push(1));
        }

        [TestMethod]
        public void Pop_NormalWork()
        {
            Stack<string> items = new Stack<string>(5);

            items.Push("alpha");
            items.Push("beta");
            items.Push("gamma");

            Assert.AreEqual("gamma", items.Pop());
            Assert.AreEqual("beta", items.Pop());
        }

        [TestMethod]
        public void Pop_EmptyStack()
        {
            Stack<string> items = new Stack<string>(5);
            
            Assert.ThrowsException<InvalidOperationException>(() => items.Pop());
        }

        [TestMethod]
        public void Top_NormalWork()
        {
            Stack<string> items = new Stack<string>(5);

            items.Push("alpha");
            items.Push("beta");
            items.Push("gamma");

            Assert.AreEqual("gamma", items.Top());
        }

        [TestMethod]
        public void Top_EmptyStack()
        {
            Stack<string> items = new Stack<string>(5);

            Assert.ThrowsException<InvalidOperationException>(() => items.Top());
        }
    }
}