using System;
using Library.Interfaces;

namespace Library.BasicTypes.Operators
{
    public class RightOperator : SingletonOperator
    {
        #region singleton
        private static readonly Lazy<RightOperator> instance =
            new(() => new RightOperator());

        public new static IOperator Instance => instance.Value;
        #endregion

        public override char Representation { get { return 'r'; } }

        private RightOperator() { }

        public override Node Move(Node node)
        {
            byte zeroIndex = node.State.ZeroIndex;
            if (zeroIndex % node.State.Dimensions[0] < node.State.Dimensions[0] - 1)
            {
                NodeState state = node.State.CloneSwap(zeroIndex, (byte)(zeroIndex + 1));
                Node parent = node;
                IOperator lastOperator = Instance;
                return new Node(parent, lastOperator, state, node.Depth + 1);
            }
            return null;
        }
    }
}
