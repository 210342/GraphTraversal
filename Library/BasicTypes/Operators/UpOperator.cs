using Library.Interfaces;
using System;

namespace Library.BasicTypes.Operators
{
    public class UpOperator : SingletonOperator
    {
        #region singleton
        private static readonly Lazy<UpOperator> instance =
            new(() => new UpOperator());

        public new static IOperator Instance => instance.Value;
        #endregion

        public override char Representation { get { return 'u'; } }
        private UpOperator() { }

        public override Node Move(Node node)
        {
            byte zeroIndex = node.State.ZeroIndex;
            if (zeroIndex >= node.State.Dimensions[1])
            {
                NodeState state = node.State.CloneSwap(zeroIndex,
                    (byte)(zeroIndex - node.State.Dimensions[1]));
                Node parent = node;
                IOperator lastOperator = Instance;
                return new Node(parent, lastOperator, state, node.Depth + 1);
            }
            return null;
        }
    }
}
