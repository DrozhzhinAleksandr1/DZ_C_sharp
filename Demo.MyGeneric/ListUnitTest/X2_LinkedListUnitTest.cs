using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollections;

namespace ListUnitTest
{
    [TestClass]
    public class X2_LinkedListUnitTest
    {
        [TestMethod]
        public void X2_MyLinkedListCtorTest()
        {
            MyLinkedListX2<int> list = new MyLinkedListX2<int>();
            Assert.AreNotEqual(null, list);
            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(false, list.IsReadOnly);
        }

        [TestMethod]
        public void X2_MyLinkedListCtorTest_2()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
            Assert.AreEqual(10, list.Count);
        }

        [TestMethod]
        public void X2_MyLinkedListAddTest()
        {
            MyLinkedListX2<int> list = new MyLinkedListX2<int>();
            Assert.AreNotEqual(null, list);
            Assert.AreEqual(0, list.Count);
            list.Add(10);
            Assert.AreEqual(1, list.Count);

            for (int i = 0; i < 100; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(101, list.Count);
        }

        [TestMethod]
        public void X2_MyLinkedListAddTailTest()
        {
            MyLinkedListX2<int> list = new MyLinkedListX2<int>();
            Assert.AreNotEqual(null, list);
            Assert.AreEqual(0, list.Count);
            list.Add(10);
            Assert.AreEqual(1, list.Count);

            for (int i = 0; i < 100; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(101, list.Count);
        }

        [TestMethod]
        public void X2_MyLinkedListClearTest()
        {
            MyLinkedListX2<int> list = new MyLinkedListX2<int>();
            for (int i = 0; i < 100; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(100, list.Count);
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void X2_MyLinkedListIndexTest()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyLinkedListX2<int> list = new MyLinkedListX2<int>();
            foreach (int val in arr)
            {
                list.Add(val);
            }
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(arr[i], list[i]);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void X2_MyLinkedListOutOfRangeTest_0()
        {
            MyLinkedListX2<int> list = new MyLinkedListX2<int>();
            list[-1] = 100;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void X2_MyLinkedListOutOfRangeTest_1()
        {
            MyLinkedListX2<int> list = new MyLinkedListX2<int>();
            list[1] = 100;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void X2_MyLinkedListOutOfRangeTest_2()
        {
            MyLinkedListX2<int> list = new MyLinkedListX2<int>();
            int x = list[-1];
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void X2_MyLinkedListOutOfRangeTest_3()
        {
            MyLinkedListX2<int> list = new MyLinkedListX2<int>();
            int x = list[1];
        }

        [TestMethod]
        public void X2_MyLinkedListContainsTest()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
            Assert.IsFalse(list.Contains(-1));
            Assert.IsTrue(list.Contains(8));
            Assert.IsFalse(list.Contains(22));
            Assert.IsTrue(list.Contains(5));
            Assert.IsTrue(list.Contains(10));
            Assert.IsTrue(list.Contains(3));
        }

        [TestMethod]
        public void X2_MyLinkedListCopyToTest()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
            int[] arr2 = new int[arr.Length];
            list.CopyTo(arr2, 0);
            for (int i = 0; i < arr.Length; ++i)
            {
                Assert.AreEqual(arr[i], arr2[i]);
            }
        }

        [TestMethod]
        public void X2_MyLinkedListIndexOfTest()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(1, list.IndexOf(5));
            Assert.AreEqual(2, list.IndexOf(10));
            Assert.AreEqual(4, list.IndexOf(25));
            Assert.AreEqual(6, list.IndexOf(8));
            Assert.AreEqual(-1, list.IndexOf(11));
            Assert.AreEqual(-1, list.IndexOf(-1));
        }

        [TestMethod]
        public void X2_MyLinkedListEnumerableTest()
        {
            MyLinkedListX2<int> list = new MyLinkedListX2<int>();
            Assert.IsTrue(list.GetEnumerator() is IEnumerator<int>);
        }

        [TestMethod]
        public void X2_MyLinkedListEnumerator_1_Test()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
            int counter = 0;

            using (IEnumerator<int> e = list.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    Assert.AreEqual(arr[counter++], e.Current);
                }
            }
            counter = 0;
            foreach (int x in list)
            {
                Assert.AreEqual(arr[counter++], x);
            }
        }
        [TestMethod]
        public void X2_MyLinkedListEnumerator_2_Test()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
            int counter = 0;

            foreach (int x in list)
            {
                Assert.AreEqual(arr[counter++], x);
            }
        }
        [TestMethod]
        public void X2_MyLinkedListRemoveTest()
        {
            int[] arr = { 3, 2, 75, 12, 9, 0 };
            MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
            list.Remove(2);
            list.Remove(75);
            list.Remove(0);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(3, list[0]);
            Assert.AreEqual(12, list[1]);
            Assert.AreEqual(9, list[2]);
        }
        [TestMethod]
        public void X2_MyLinkedListRemoveAtTest()
        {
            int[] arr = { 3, 2, 75, 12, 9, 0, 22, 44 };
            MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
            list.RemoveAt(1);
            list.RemoveAt(3);
            list.RemoveAt(5);
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(3, list[0]);
            Assert.AreEqual(75, list[1]);
            Assert.AreEqual(12, list[2]);
            Assert.AreEqual(0, list[3]);
            Assert.AreEqual(22, list[4]);
        }
    }
}
