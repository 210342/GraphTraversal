using Library.BasicTypes;
using Library.Interfaces;
using System;
using System.Collections.Generic;

namespace GraphExploring.Logic.Finders
{
    public abstract class AbstractFinder : IFinder
    {
        protected byte[] _expectedSolution =
        [
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0
        ];
        private int depth = 0;


        #region Properties
        public abstract IReadOnlyCollection<Node> Frontier { get; }

        public HashSet<Node> Explored { get; } = [];
        public int Depth
        {
            get
            {
                return depth;
            }
            set
            {
                depth = value;
                if (value > MaximumDepthReached)
                {
                    MaximumDepthReached = value;
                }
            }
        }
        public int MaximumDepthReached { get; set; }

        public abstract Func<Node, int> HeuristicFunction { get; }

        public abstract Func<Node, List<IOperator>, byte[], Node> FindSolution { get; }

        #endregion

        #region Helping Methods

        protected static Node FindChild(Node node, IOperator op)
        {
            IOperator reverseOp = OperatorsCollection.GetReverse(node.LastOperation);
            if (op != reverseOp)
                return op.Move(node);
            return null;
        }

        protected bool CheckIfSolution(Node node)
        {
            for(byte i = 0; i < node.State.State.Length - 1; ++i) // omit last element; if all previous are in place then last one is as well
            {
                if (node.State.State[i] != _expectedSolution[i])
                    return false;
            }
            return true;
        }
        #endregion
    }
}
