using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface INode
    {
        IState State { get; }
        INode Parent { get; }
        IEnumerable<INode> Children { get; }
        IOperator LastOperation { get; }
    }
}
