using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IOperator
    {
        IOperator Instance { get; }
        INode Move(INode node);
    }
}
