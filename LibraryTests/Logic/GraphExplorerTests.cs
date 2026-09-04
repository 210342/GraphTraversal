using Library.BasicTypes;
using Library.BasicTypes.Operators;
using GraphExploring.Logic;
using System.Diagnostics.CodeAnalysis;

namespace Library.Logic.Tests
{
    [ExcludeFromCodeCoverage]
    public class GraphExplorerTests
    {
        [Fact]
        public void CreateGraphExplorerCreates()
        {
            GraphExplorer ge = GraphExplorer.CreateGraphExplorer([2, 2],
                [1, 2, 3, 0], ['l', 'r']);
            Assert.NotNull(ge);
        }
        [Fact]
        public void CreateGraphExplorerThrows()
        {
            Assert.Throws<InvalidOperationException>(() => GraphExplorer.CreateGraphExplorer([2, 2],
                [1, 2, 3, 0], ['z', 'r']));
        }
        [Fact]
        public void CreateGraphExplorerThrowsWhenNotUnique()
        {
             Assert.Throws<InvalidOperationException>(() => GraphExplorer.CreateGraphExplorer([2, 2],
                [1, 2, 3, 1], ['z', 'r']));
        }

        [Fact]
        public void IsRootNodeTest_True()
        {
            GraphExplorer ge = GraphExplorer.CreateGraphExplorer([4, 4],
                [1, 2, 3, 0],
                ['l', 'r']);
            Assert.True(GraphExplorer.IsRootNode(new Node(null, null, new NodeState([1, 1],
                [0, 1]), 0)));
        }

        [Fact]
        public void IsRootNodeTest_False()
        {
            GraphExplorer ge = GraphExplorer.CreateGraphExplorer([2, 2],
                    [1, 2, 3, 4], ['l', 'r']);
            Node parent = new Node(null, null, new NodeState([1, 1], [0, 1]), 0);
            Assert.False(GraphExplorer.IsRootNode(new Node(parent, DownOperator.Instance, new NodeState([1, 1],
                [0, 1]), 1)));
        }
    }
}