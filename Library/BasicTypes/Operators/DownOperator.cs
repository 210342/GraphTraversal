using Library.Interfaces;
using System;

namespace Library.BasicTypes.Operators
{
    public class DownOperator : SingletonOperator
    {
        #region singleton
        private static readonly Lazy<DownOperator> instance =
            new Lazy<DownOperator>(() => new DownOperator());

        public new static IOperator Instance => instance.Value;
        #endregion

        private DownOperator() { }

        public override INode Move(INode node)
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
