using System;
using Library.BasicTypes;
using Library.BasicTypes.Operators;
using Library.Interfaces;
using Library.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GraphExplorerCreates()
        {
            GraphExplorer ge = GraphExplorer.CreateGraphExplorer(new byte[] { 0, 0, 0, 0 }, new char[] { 'l', 'r' });
            Assert.IsNotNull(ge);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GraphExplorerThrows()
        {
            GraphExplorer ge = GraphExplorer.CreateGraphExplorer(new byte[] { 0, 0, 0, 0 }, new char[] { 'z', 'r' });
        }
    }
}
