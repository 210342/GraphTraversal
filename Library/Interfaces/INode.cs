using System;
using System.Collections.Generic;

namespace Library.Interfaces
{
    public interface INode
    {
        IState State { get; }
        INode Parent { get; }
        INode[] Children { get; set; }
        IOperator LastOperation { get; }
        int Depth { get; }
        int SummedCost { get; set; }
    }
}
