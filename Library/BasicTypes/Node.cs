using Library.Interfaces;

namespace Library.BasicTypes
{
    public class Node(Node parent, IOperator operation, NodeState state, int depth)
    {
        public readonly NodeState State = state;
        public readonly Node Parent = parent;
        public readonly IOperator LastOperation = operation;
        public readonly int Depth = depth;
        public int SummedCost { get; set; }

        public override int GetHashCode()
        {
            return State.GetHashCode() * 16661 + Depth;
        }
    }
}
