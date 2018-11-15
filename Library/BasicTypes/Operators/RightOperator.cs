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

        public override char Representation { get { return 'r'; } }

        private RightOperator() { }

        public override INode Move(INode node)
        {
            byte zeroIndex = node.State.ZeroIndex;
            if (zeroIndex % node.State.Dimensions[0] < node.State.Dimensions[0] - 1)
            {
                IState state = node.State.CloneSwap(zeroIndex, (byte)(zeroIndex + 1));
                INode parent = node;
                IOperator lastOperator = Instance;
                return new Node(parent, lastOperator, state, node.Depth + 1);
            }
            return null;
        }
    }
}
