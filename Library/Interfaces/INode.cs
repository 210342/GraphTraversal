using System;
using System.Collections.Generic;

namespace Library.Interfaces
{
    public interface INode
    {
        IState State { get; }
        INode Parent { get; }
        //IList<INode> Children { get; }
        IOperator LastOperation { get; }
        int Depth { get; }
        int SummedCost { get; set; }
    }
}
