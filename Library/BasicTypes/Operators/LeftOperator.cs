using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library.BasicTypes.Operators
{
    public class LeftOperator : IOperator
    {
        #region singleton
        private LeftOperator instance = null;

        public IOperator Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new LeftOperator();
                }
                return instance;
            }
        }
        #endregion

        private LeftOperator() { }

        public INode Move(INode node)
        {
            sbyte zeroIndex = node.State.ZeroIndex;
            if(zeroIndex % (int)Math.Sqrt(node.State.StateSize) != 0)
            {
                IState state = node.State.CloneSwap((byte)zeroIndex, (byte)(zeroIndex - 1));
                INode parent = node;
                IOperator lastOperator = Instance;
                return new Node(parent, lastOperator, state);
            }
            return null;
        }
    }
}
