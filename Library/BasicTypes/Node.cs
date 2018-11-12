using System.Collections.Generic;
using Library.Interfaces;

namespace Library.BasicTypes
{
    public class Node : INode
    {
        public IState State { get; }
        public INode Parent { get; }
        public IOperator LastOperation { get; }
        public INode[] Children { get; set; }
        public int Depth { get; }
        public int SummedCost { get; set; }

        public Node(INode parent, IOperator operation, IState state, int depth)
        {
            Parent = parent;
            State = state;
            LastOperation = operation;
            Depth = depth;
        }
        public override int GetHashCode()
        {
            return State.GetHashCode();
        }
    }
}
