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

        public override char Representation { get { return 'd'; } }

        private DownOperator() { }

        public override INode Move(INode node)
        {
            byte zeroIndex = node.State.ZeroIndex;
            if (zeroIndex < node.State.StateSize - node.State.Dimensions[1])
            {
                IState state = node.State.CloneSwap(zeroIndex, (byte)(zeroIndex + node.State.Dimensions[1]));
                INode parent = node;
                IOperator lastOperator = Instance;
                return new Node(parent, lastOperator, state, node.Depth + 1);
            }
            return null;
        }
    }
}
