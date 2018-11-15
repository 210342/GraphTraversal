using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.BasicTypes.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library.BasicTypes.Operators.Tests
{
    [TestClass()]
    public class RightOperatorTests
    {
        [TestMethod()]
        public void MoveTest()
        {
            IState state = new NodeState(new byte[] { 4, 4 }, 
                new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            INode node = new Node(null, null, state, 0);
            node = RightOperator.Instance.Move(node);
            Assert.AreEqual(1, node.State.ZeroIndex);
        }
    }
}