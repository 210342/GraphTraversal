using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library.BasicTypes;
using Library.BasicTypes.Operators;
using Library.Interfaces;
using GraphExploring.Logic;

namespace Library.Logic.Tests
{
    [TestClass()]
    public class GraphExplorerTests
    {
        [TestMethod]
        public void CreateGraphExplorerCreates()
        {
            GraphExplorer ge = GraphExplorer.CreateGraphExplorer(new byte[] { 0, 0, 0, 0 }, new char[] { 'l', 'r' });
            Assert.IsNotNull(ge);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateGraphExplorerThrows()
        {
            GraphExplorer ge = GraphExplorer.CreateGraphExplorer(new byte[] { 0, 0, 0, 0 }, new char[] { 'z', 'r' });
        }

        [TestMethod()]
        public void IsRootNodeTest_True()
        {
            GraphExplorer ge = GraphExplorer.CreateGraphExplorer(new byte[] { 0, 0, 0, 0 }, new char[] { 'l', 'r' });
            Assert.IsTrue(ge.IsRootNode(new Node(null, null, new NodeState(new byte[] { 0, 1 }), 0)));
        }

        [TestMethod()]
        public void IsRootNodeTest_False()
        {
            GraphExplorer ge = GraphExplorer.CreateGraphExplorer(new byte[] { 0, 0, 0, 0 }, new char[] { 'l', 'r' });
            INode parent = new Node(null, null, new NodeState(new byte[] { 0, 1 }), 0);
            Assert.IsFalse(ge.IsRootNode(new Node(parent, DownOperator.Instance, new NodeState(new byte[] { 0, 1 }), 1)));
        }
    }
}