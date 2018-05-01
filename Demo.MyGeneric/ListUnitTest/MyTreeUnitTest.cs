using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollections;

namespace ListUnitTest
{
    [TestClass]
    public class MyTreeUnitTest
    {
        [TestMethod]
        public void MyTreeCtorTest()
        {
            MyTree<int, int> tree = new MyTree<int, int>();

            Assert.AreNotEqual(null, tree);
            Assert.AreEqual(0, tree.Count);
            Assert.AreEqual(false, tree.IsReadOnly);
        }
        
        [TestMethod]
        public void MyTreeAddTest()
        {
            MyTree<int, int> tree = new MyTree<int, int>(true);

            Assert.AreNotEqual(null, tree);
            Assert.AreEqual(0, tree.Count);

            tree.Add(10, 12);
            Assert.AreEqual(1, tree.Count);

            for (int i = 0; i < 100; ++i)
            {
                tree.Add(i, i + 2);
            }
            Assert.AreEqual(101, tree.Count);
        }



        [TestMethod]
        public void MyTreeClearTest()
        {
            MyTree<int, int> tree = new MyTree<int, int>(true);
            for (int i = 0; i < 100; ++i)
            {
                tree.Add(i,i+2);
            }
            Assert.AreEqual(100, tree.Count);
            tree.Clear();
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void MyTreeIndexGetTest()
        {
            MyTree<int, int> tree = new MyTree<int, int>();
            tree.Add(2, 8);
            tree.Add(7, 3);
            Assert.AreEqual(8, tree[2]);
            Assert.AreEqual(3, tree[7]);
        }

        [TestMethod]
        public void MyTreeIndexSetTest()
        {
            MyTree<int, int> tree = new MyTree<int, int>();
            tree.Add(3, 8);
            tree[3] = 5;
            Assert.AreEqual(5, tree[3]);
        }


        //    [TestMethod]
        //    public void X2_MyLinkedListContainsTest()
        //    {
        //        int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
        //        MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
        //        Assert.IsFalse(list.Contains(-1));
        //        Assert.IsTrue(list.Contains(8));
        //        Assert.IsFalse(list.Contains(22));
        //        Assert.IsTrue(list.Contains(5));
        //        Assert.IsTrue(list.Contains(10));
        //        Assert.IsTrue(list.Contains(3));
        //    }

        //    [TestMethod]
        //    public void X2_MyLinkedListCopyToTest()
        //    {
        //        int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
        //        MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
        //        int[] arr2 = new int[arr.Length];
        //        list.CopyTo(arr2, 0);
        //        for (int i = 0; i < arr.Length; ++i)
        //        {
        //            Assert.AreEqual(arr[i], arr2[i]);
        //        }
        //    }

        //    [TestMethod]
        //    public void X2_MyLinkedListIndexOfTest()
        //    {
        //        int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
        //        MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
        //        Assert.AreEqual(0, list.IndexOf(1));
        //        Assert.AreEqual(1, list.IndexOf(5));
        //        Assert.AreEqual(2, list.IndexOf(10));
        //        Assert.AreEqual(4, list.IndexOf(25));
        //        Assert.AreEqual(6, list.IndexOf(8));
        //        Assert.AreEqual(-1, list.IndexOf(11));
        //        Assert.AreEqual(-1, list.IndexOf(-1));
        //    }

        //    [TestMethod]
        //    public void X2_MyLinkedListEnumerableTest()
        //    {
        //        MyLinkedListX2<int> list = new MyLinkedListX2<int>();
        //        Assert.IsTrue(list.GetEnumerator() is IEnumerator<int>);
        //    }

        //    [TestMethod]
        //    public void X2_MyLinkedListEnumerator_1_Test()
        //    {
        //        int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
        //        MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
        //        int counter = 0;

        //        using (IEnumerator<int> e = list.GetEnumerator())
        //        {
        //            while (e.MoveNext())
        //            {
        //                Assert.AreEqual(arr[counter++], e.Current);
        //            }
        //        }
        //        counter = 0;
        //        foreach (int x in list)
        //        {
        //            Assert.AreEqual(arr[counter++], x);
        //        }
        //    }
        //    [TestMethod]
        //    public void X2_MyLinkedListEnumerator_2_Test()
        //    {
        //        int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
        //        MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
        //        int counter = 0;

        //        foreach (int x in list)
        //        {
        //            Assert.AreEqual(arr[counter++], x);
        //        }
        //    }
        //    [TestMethod]
        //    public void X2_MyLinkedListRemoveTest()
        //    {
        //        int[] arr = { 3, 2, 75, 12, 9, 0 };
        //        MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
        //        list.Remove(3);
        //        Assert.AreEqual(5, list.Count);
        //        Assert.AreEqual(2, list[0]);
        //    }
        //    [TestMethod]
        //    public void X2_MyLinkedListRemoveAtTest()
        //    {
        //        int[] arr = { 3, 2, 75, 12, 9, 0, 22, 44 };
        //        MyLinkedListX2<int> list = new MyLinkedListX2<int>(arr);
        //        list.RemoveAt(0);
        //        Assert.AreEqual(7, list.Count);
        //        Assert.AreEqual(2, list[0]);
        //    }
    }
}





