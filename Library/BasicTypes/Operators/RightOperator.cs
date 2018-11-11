using System;
using Library.Interfaces;

namespace Library.BasicTypes.Operators
{
    public class RightOperator : IOperator
    {
        #region singleton
        private static RightOperator instance = null;

        public IOperator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RightOperator();
                }
                return instance;
            }
        }
        #endregion

        private RightOperator() { }

        public INode Move(INode node)
        {
            sbyte zeroIndex = node.State.ZeroIndex;
            int size = (int)Math.Sqrt(node.State.StateSize);
            if (zeroIndex % size != size - 1)
            {
                IState state = node.State.CloneSwap((byte)zeroIndex, (byte)(zeroIndex + 1));
                INode parent = node;
                IOperator lastOperator = Instance;
                return new Node(parent, lastOperator, state);
            }
            return null;
        }
    }
}
