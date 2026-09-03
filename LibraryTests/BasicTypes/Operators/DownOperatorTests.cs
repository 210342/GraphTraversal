using Library.BasicTypes.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library.BasicTypes.Operators.Tests
{
    public class DownOperatorTests
    {
        [Fact]
        public void MoveTest()
        {
            IState state = new NodeState([4, 4],
                [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]);
            INode node = new Node(null, null, state, 0);
            node = DownOperator.Instance.Move(node);
            Assert.Equal(4, node.State.ZeroIndex);
        }
    }
}