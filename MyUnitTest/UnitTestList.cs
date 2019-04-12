using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
    
namespace MyUnitTest
{
    public class UnitTestList<T> where T : IList<int>, new()
    {
        [TestMethod]
        public void CreateCountTest()
        {
            T arr = new T();
            Assert.AreEqual(arr.Count, 0);
        }

        [TestMethod]
        public void AddCountTest()
        {
            T arr = new T();
            arr.Add(10);
            Assert.AreEqual(arr.Count, 1);

            for (int i = 0; i < 1000; ++i)
            {
                arr.Add(i);
            }
            Assert.AreEqual(arr.Count, 1001);
        }

        [TestMethod]
        public void ClearCountTest()
        {
            T arr = new T();
            arr.Add(10);
            Assert.AreEqual(arr.Count, 1);
            arr.Clear();
            Assert.AreEqual(arr.Count, 0);
            for (int i = 0; i < 1000; ++i)
            {
                arr.Add(i);
            }
            Assert.AreEqual(arr.Count, 1000);
            arr.Clear();
            Assert.AreEqual(arr.Count, 0);
        }
        [TestMethod]
        public void ContainsTest()
        {
            T arr = new T();
            Assert.IsFalse(arr.Contains(10));
            Assert.IsFalse(arr.Contains(0));
            arr.Add(10);
            Assert.IsTrue(arr.Contains(10));
            Assert.IsFalse(arr.Contains(0));
            arr.Add(0);
            Assert.IsTrue(arr.Contains(10));
            Assert.IsTrue(arr.Contains(0));
        }

        [TestMethod]
        public void CopyToTest()
        {
            T arr = new T();
            for (int i = 0; i < 1000; ++i)
            {
                arr.Add(i);
            }
            int[] mas = new int[1200];
            arr.CopyTo(mas, 100);

            for (int i = 0; i < arr.Count; ++i)
            {
                Assert.AreEqual(arr[i], mas[i + 100]);
            }
        }
        [TestMethod]
        public void IndexTest()
        {
            T arr = new T();
            for (int i = 0; i < 1000; ++i)
            {
                arr.Add(i);
            }

            for (int i = 0; i < arr.Count; ++i)
            {
                Assert.AreEqual(arr[i], i);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ExceptionIndexTest_1()
        {
            T arr = new T();
            arr[1] = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ExceptionIndexTest_2()
        {
            T arr = new T();
            arr[-1] = 10;
        }

        [TestMethod]
        public void IndexOfTest()
        {
            T arr = new T();
            for (int i = 0; i < 1000; ++i)
            {
                arr.Add(i);
            }
            Assert.AreEqual(arr.IndexOf(-100), -1);
            Assert.AreEqual(arr.IndexOf(10000), -1);
            Assert.AreEqual(arr.IndexOf(0), 0);
            Assert.AreEqual(arr.IndexOf(10), 10);
            Assert.AreEqual(arr.IndexOf(999), 999);
            Assert.AreEqual(arr.IndexOf(1000), -1);
        }

        [TestMethod]
        public void InsertTest()
        {
            T arr = new T();
            for (int i = 0; i < 1000; ++i)
            {
                arr.Add(i);
            }
            arr.Insert(10, -100);
            Assert.AreEqual(arr[10], -100);
            Assert.AreEqual(arr[9], 9);
            Assert.AreEqual(arr[11], 10);
            Assert.AreEqual(arr.Count, 1001);
            Assert.AreEqual(arr[999], 998);
        }
        [TestMethod]
        public void RemoveTest()
        {
            T arr = new T();
            for (int i = 0; i < 1000; ++i)
            {
                arr.Add(i);
            }
            Assert.IsFalse(arr.Remove(10000));
            Assert.IsTrue(arr.Remove(10));
            Assert.AreEqual(arr[10], 11);
            Assert.AreEqual(arr[9], 9);
            Assert.AreEqual(arr[11], 12);
            Assert.AreEqual(arr.Count, 999);
            Assert.AreEqual(arr[998], 999);
        }
        [TestMethod]
        public void RemoveAtTest()
        {
            T arr = new T();
            for (int i = 0; i < 1000; ++i)
            {
                arr.Add(i);
            }
            arr.RemoveAt(10);
            Assert.AreEqual(arr[10], 11);
            Assert.AreEqual(arr[9], 9);
            Assert.AreEqual(arr[11], 12);
            Assert.AreEqual(arr.Count, 999);
            Assert.AreEqual(arr[998], 999);
        }
        [TestMethod]
        public void EnumeratorTest()
        {
            T arr = new T();
            for (int j = 0; j < 1000; ++j)
            {
                arr.Add(j);
            }
            int i = 0;
            foreach (int x in arr)
            {
                Assert.AreEqual(arr[i++], x);
            }
            Assert.AreEqual(1000, i);

            i = 0;
            foreach (int x in arr)
            {
                Assert.AreEqual(arr[i++], x);
            }
            Assert.AreEqual(1000, i);
        }
    }
}
