using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library.BasicTypes
{
    public class Node : INode
    {
        public IState State { get; }

        public INode Parent { get; }

        public IEnumerable<INode> Children { get; set; }

        public IOperator LastOperation { get; }

        public Node(INode parent, IOperator operation, IState state)
        {
            Parent = parent;
            State = state;
            LastOperation = operation;
        }
    }
}
