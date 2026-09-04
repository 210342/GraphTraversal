using Xunit;
using Library.BasicTypes.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library.BasicTypes.Operators.Tests
{
    public class UpOperatorTests
    {
        [Fact]
        public void MoveTest()
        {
            IState state = new NodeState([4, 4],
                [4, 1, 2, 3, 0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]);
            INode node = new Node(null, null, state, 0);
            node = UpOperator.Instance.Move(node);
            Assert.Equal(0, node.State.ZeroIndex);
        }
    }
}