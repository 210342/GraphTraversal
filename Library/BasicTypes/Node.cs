using System.Collections.Generic;
using Library.Interfaces;

namespace Library.BasicTypes
{
    public class Node : INode
    {
        public IState State { get; }
        public INode Parent { get; }
        public IOperator LastOperation { get; }
        public int Depth { get; }
        public int SummedCost { get; set; }

       // public IList<INode> Children => new List<INode>();

        public Node(INode parent, IOperator operation, IState state, int depth)
        {
            Parent = parent;
            State = state;
            LastOperation = operation;
            Depth = depth;
        }
        public override int GetHashCode()
        {
            return State.GetHashCode() * 16661 + Depth;
        }
    }
}
