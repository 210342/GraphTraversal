using System.Collections.Generic;
using Library.Interfaces;

namespace GraphExploring.Logic.Finders
{
    public class DFS : AbstractFinder, IFinder
    {
        private readonly int _depthLimit = 20;

        public override IReadOnlyCollection<INode> Frontier { get; } = new Stack<INode>();

        public override System.Func<INode, List<IOperator>, INode> FindSolution => Algorithm;

        public override System.Func<INode, int> HeuristicFunction => (_) => 1;

        public INode Algorithm(INode node, List<IOperator> operatorsSequence)
        {
            while (!CheckIfSolution(node))
            {
                foreach (IOperator op in operatorsSequence)
                {
                    INode kid = FindChild(node, op);
                    if (kid != null && !Explored.Contains(kid) && kid.Depth <= _depthLimit)
                    {
                        (Frontier as Stack<INode>).Push(kid);
                        Explored.Add(kid);
                    }
                }
                node = (Frontier as Stack<INode>).Pop();
                Depth = node.Depth;
            }
            return node;
        }
    }
}
