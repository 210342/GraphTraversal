using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.BasicTypes;
using Library.Interfaces;

namespace Library.BasicTypes.Tests
{
    [TestClass()]
    public class NodeTests
    {

        [TestMethod()]
        public void GetSameHashCodeTest()
        {
            INode node1 = new Node(null, null,
                new NodeState(new byte[] { 4, 4 }, new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
                0);
            INode node2 = new Node(null, null,
                new NodeState(new byte[] { 4, 4 }, new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
                0);
            Assert.AreEqual(node1.GetHashCode(), node2.GetHashCode());
        }


        [TestMethod()]
        public void GetHashCodeTestDiffDepth()
        {
            INode node1 = new Node(null, null,
                new NodeState(new byte[] { 4, 4 }, new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
                0);
            INode node2 = new Node(null, null,
                new NodeState(new byte[] { 4, 4 }, new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }),
                1);
            Assert.AreNotEqual(node1.GetHashCode(), node2.GetHashCode());
        }
    }
}