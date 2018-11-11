using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BasicTypes.Operators
{
    public class UpOperator : IOperator
    {
        #region singleton
        private static UpOperator instance = null;

        public IOperator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UpOperator();
                }
                return instance;
            }
        }
        #endregion

        private UpOperator() { }

        public INode Move(INode node)
        {
            sbyte zeroIndex = node.State.ZeroIndex;
            int size = (int)Math.Sqrt(node.State.StateSize);
            if (zeroIndex < size)
            {
                IState state = node.State.CloneSwap((byte)zeroIndex, (byte)(zeroIndex - size));
                INode parent = node;
                IOperator lastOperator = Instance;
                return new Node(parent, lastOperator, state);
            }
            return null;
        }
    }
}
