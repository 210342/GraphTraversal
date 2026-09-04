namespace Library.BasicTypes.Operators.Tests
{
    public class UpOperatorTests
    {
        [Fact]
        public void MoveTest()
        {
            NodeState state = new NodeState([4, 4],
                [4, 1, 2, 3, 0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]);
            Node node = new Node(null, null, state, 0);
            node = UpOperator.Instance.Move(node);
            Assert.Equal(0, node.State.ZeroIndex);
        }
    }
}