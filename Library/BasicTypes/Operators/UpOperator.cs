using Library.Interfaces;
using System;

namespace Library.BasicTypes.Operators
{
    public class UpOperator : SingletonOperator
    {
        #region singleton
        private static readonly Lazy<UpOperator> instance =
            new Lazy<UpOperator>(() => new UpOperator());

        public new static IOperator Instance => instance.Value;
        #endregion

        public override char Representation { get { return 'u'; } }
        private UpOperator() { }

        public override INode Move(INode node)
        {
            sbyte zeroIndex = node.State.ZeroIndex;
            int size = (int)Math.Sqrt(node.State.StateSize);
            if (zeroIndex > size)
            {
                IState state = node.State.CloneSwap((byte)zeroIndex, (byte)(zeroIndex - size));
                INode parent = node;
                IOperator lastOperator = Instance;
                return new Node(parent, lastOperator, state, node.Depth + 1);
            }
            return null;
        }
    }
}
