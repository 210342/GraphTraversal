using Library.Interfaces;
using System;

namespace Library.BasicTypes.Operators
{
    public class DownOperator : IOperator
    {
        #region singleton
        private static readonly Lazy<DownOperator> instance =
            new Lazy<DownOperator>(() => new DownOperator());

        public IOperator Instance => instance.Value;
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
