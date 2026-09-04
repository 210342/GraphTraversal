using Xunit;
using Library.BasicTypes;
using Library.Interfaces;

namespace Library.BasicTypes.Tests
{
    public class NodeTests
    {
        [Fact]
        public void GetSameHashCodeTest()
        {
            INode node1 = new Node(null, null,
                new NodeState([4, 4], [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]),
                0);
            INode node2 = new Node(null, null,
                new NodeState([4, 4], [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]),
                0);
            Assert.Equal(node1.GetHashCode(), node2.GetHashCode());
        }

        [Fact]
        public void GetHashCodeTestDiffDepth()
        {
            INode node1 = new Node(null, null,
                new NodeState([4, 4], [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]),
                0);
            INode node2 = new Node(null, null,
                new NodeState([4, 4], [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]),
                1);
            Assert.NotEqual(node1.GetHashCode(), node2.GetHashCode());
        }
    }
}