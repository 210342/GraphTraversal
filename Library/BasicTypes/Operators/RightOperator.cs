using System;
using Library.Interfaces;

namespace Library.BasicTypes.Operators
{
    public class RightOperator : SingletonOperator
    {
        #region singleton
        private static readonly Lazy<RightOperator> instance =
            new Lazy<RightOperator>(() => new RightOperator());

        public new static IOperator Instance => instance.Value;
        #endregion

        private RightOperator() { }

        public override INode Move(INode node)
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
