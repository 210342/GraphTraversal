using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library.BasicTypes.Operators
{
    public class LeftOperator : SingletonOperator
    {
        #region singleton
        private static readonly Lazy<LeftOperator> instance =
            new Lazy<LeftOperator>(() => new LeftOperator());

        public new static IOperator Instance => instance.Value;
        #endregion

        public override char Representation { get { return 'l'; } }

        private LeftOperator() { }

        public override INode Move(INode node)
        {
            byte zeroIndex = node.State.ZeroIndex;
            if(zeroIndex % node.State.Dimensions[0] != 0)
            {
                IState state = node.State.CloneSwap(zeroIndex, (byte)(zeroIndex - 1));
                INode parent = node;
                IOperator lastOperator = Instance;
                return new Node(parent, lastOperator, state, node.Depth + 1);
            }
            return null;
        }
    }
}
