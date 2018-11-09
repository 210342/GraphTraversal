using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BasicTypes.Operators
{
    class DownOperator : IOperator
    {
        #region singleton
        private DownOperator instance = null;

        public IOperator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DownOperator();
                }
                return instance;
            }
        }
        #endregion

        private DownOperator() { }

        public INode Move(INode node)
        {
            sbyte zeroIndex = node.State.ZeroIndex;
            int size = (int)Math.Sqrt(node.State.StateSize);
            if (zeroIndex < node.State.StateSize - size)
            {
                IState state = node.State.CloneSwap((byte)zeroIndex, (byte)(zeroIndex + size));
                INode parent = node;
                IOperator lastOperator = Instance;
                return new Node(parent, lastOperator, state);
            }
            return null;
        }
    }
}
