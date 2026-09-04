namespace Library.BasicTypes.Operators.Tests
{
    public class LeftOperatorTests
    {
        [Fact]
        public void MoveTest()
        {
            NodeState state = new NodeState([4, 4],
                [1, 0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]);
            Node node = new Node(null, null, state, 0);
            node = LeftOperator.Instance.Move(node);
            Assert.Equal(0, node.State.ZeroIndex);
        }
    }
}