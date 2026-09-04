namespace Library.BasicTypes.Operators.Tests
{
    public class RightOperatorTests
    {
        [Fact]
        public void MoveTest()
        {
            NodeState state = new NodeState([4, 4], 
                [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]);
            Node node = new Node(null, null, state, 0);
            node = RightOperator.Instance.Move(node);
            Assert.Equal(1, node.State.ZeroIndex);
        }
    }
}