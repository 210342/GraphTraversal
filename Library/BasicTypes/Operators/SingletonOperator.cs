using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BasicTypes.Operators
{
    public abstract class SingletonOperator : IOperator
    {
        public static IOperator Instance { get; }
        public abstract INode Move(INode node);
    }
}
