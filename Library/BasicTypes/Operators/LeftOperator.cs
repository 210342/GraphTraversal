using System;
using Library.Interfaces;

namespace Library.BasicTypes.Operators
{
    public class LeftOperator : SingletonOperator
    {
        #region singleton
        private static readonly Lazy<LeftOperator> instance =
            new(() => new LeftOperator());

        public new static IOperator Instance => instance.Value;
        #endregion

        public override char Representation { get { return 'l'; } }

        private LeftOperator() { }

        public override Node Move(Node node)
        {
            byte zeroIndex = node.State.ZeroIndex;
            if (zeroIndex % node.State.Dimensions[0] != 0)
            {
                NodeState state = node.State.CloneSwap(zeroIndex, (byte)(zeroIndex - 1));
                Node parent = node;
                IOperator lastOperator = Instance;
                return new Node(parent, lastOperator, state, node.Depth + 1);
            }
            return null;
        }
    }
}
