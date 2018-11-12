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

        public void FindChildren(List<IOperator> operatorSequence)
        {
            if(Children == null)
            {
                INode[] result = new INode[4];
                for(int i = 0; i < 4; ++i)
                {
                    if(operatorSequence[i] != LastOperation)
                    {
                        result[i] = operatorSequence[i].Move(this);
                    }
                    else
                    {
                        result[i] = null;
                    }
                }
                Children = result;
            }
        }

        public override int GetHashCode()
        {
            return State.GetHashCode();
        }
    }
}
