using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphExploring.Logic.Finders
{
    public abstract class AbstractFinder : IFinder
    {
        private readonly byte[] expectedSolution = new byte[]
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0
        };

        #region Properties
        private int depth = 0;
        public abstract IReadOnlyCollection<INode> Frontier { get; }

        public HashSet<INode> Explored { get; } = new HashSet<INode>();
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

        public abstract Func<INode, int> HeuristicFunction { get; }

        public abstract Func<INode, List<IOperator>, INode> FindSolution { get; }
        #endregion


        #region Helping Methods  
        [System.Obsolete("Method is obsolelte, please use FindChild with respect to single operator." +
             " Makes the whole searching process slightly less consuming.")]
        protected IList<INode> FindChildren(INode node, List<IOperator> operatorsSequence)
        {
            int opCount = operatorsSequence.Count();
            List<INode> result = new List<INode>();
            for (int i = 0; i < opCount; ++i)
            {
                IOperator reverseOp = OperatorsCollection.GetReverse(node.LastOperation);
                if (operatorsSequence[i] != reverseOp)
                {
                    result.Add(operatorsSequence[i].Move(node));
                }
            }
            return result;
        }
        
        protected INode FindChild(INode node, IOperator op)
        {
            INode child;
            IOperator reverseOp = OperatorsCollection.GetReverse(node.LastOperation);
            if (op != reverseOp)
            {
                child = op.Move(node);
            }
            else
            {
                child = null;
            }
            return child;
        }

        protected bool CheckIfSolution(INode node)
        {
           return node.State.State.SequenceEqual(expectedSolution);
        }
        #endregion
    }
}
