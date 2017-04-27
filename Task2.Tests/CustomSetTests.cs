using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    [TestFixture]
    public class CustomSetTests
    {
        [TestCase(new[] { "1", "5", "2", "3" }, "12", ExpectedResult = true)]
        [TestCase(new[] { "1", "5", "2", "3" }, "2", ExpectedResult = false)]
        public bool Add_PassedElement_ExpectedPositiveTests(string[] array, string element)
        {
            CustomSet<string> set = new CustomSet<string>(array);
            return set.Add(element);
        }

        [TestCase(new[] { "1", "5", "2", "3" }, "12", ExpectedResult = false)]
        [TestCase(new[] { "1", "5", "2", "3" }, "2", ExpectedResult = true)]
        public bool Remove_PassedElement_ExpectedPositiveTests(string[] array, string element)
        {
            CustomSet<string> set = new CustomSet<string>(array);
            return set.Remove(element);
        }

        [TestCase(new[] { "1", "5", "2", "3" }, new[] { "1", "5", "2", "3" }, ExpectedResult = true)]
        [TestCase(new[] { "1", "5", "2", "3" }, new[] { "1", "5", "2" }, ExpectedResult = false)]
        public bool SetEquals_PassedElement_ExpectedPositiveTests(string[] array, string[] other)
        {
            CustomSet<string> set = new CustomSet<string>(array);
            return set.SetEquals(other);
        }

        [TestCase(new[] { "1", "5", "2", "3" }, new[] { "1", "6", "22", "3" })]
        public void UnionWith_PassedCollection_ExpectedPositiveTests(string[] array, string[]other)
        {
            CustomSet<string> set = new CustomSet<string>(array);
            set.UnionWith(other);
            Assert.AreEqual(set, new CustomSet<string>(new[] { "1", "5", "2", "3", "6", "22" }));
        }

        [TestCase(new[] { "1", "5", "2", "3" }, new[] { "1", "6", "22", "3" })]
        public void IntersectWith_PassedCollection_ExpectedPositiveTests(string[] array, string[] other)
        {
            CustomSet<string> set = new CustomSet<string>(array);
            set.IntersectWith(other);
            Assert.AreEqual(set, new CustomSet<string>(new[] { "1", "3" }));
        }

        [TestCase(new[] { "1", "5", "2", "3" }, new[] { "1", "6", "22", "3" })]
        public void ExceptWith_PassedCollection_ExpectedPositiveTests(string[] array, string[] other)
        {
            CustomSet<string> set = new CustomSet<string>(array);
            set.ExceptWith(other);
            Assert.AreEqual(set, new CustomSet<string>(new[] { "5", "2" }));
        }

        [TestCase(new[] { "1", "5", "2", "3" }, new[] { "1", "6", "22", "3" })]
        public void SymmetricExceptWith_PassedCollection_ExpectedPositiveTests(string[] array, string[] other)
        {
            CustomSet<string> set = new CustomSet<string>(array);
            set.SymmetricExceptWith(other);
            Assert.AreEqual(set, new CustomSet<string>(new[] { "5", "2", "6", "22" }));
        }
    }
}
