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
            byte zeroIndex = node.State.ZeroIndex;
            if (zeroIndex >= node.State.Dimensions[1])
            {
                IState state = node.State.CloneSwap(zeroIndex, 
                    (byte)(zeroIndex - node.State.Dimensions[1]));
                INode parent = node;
                IOperator lastOperator = Instance;
                return new Node(parent, lastOperator, state, node.Depth + 1);
            }
            return null;
        }
    }
}
