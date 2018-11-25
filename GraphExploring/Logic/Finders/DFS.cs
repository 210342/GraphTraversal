using System.Collections.Generic;
using Library.Interfaces;

namespace GraphExploring.Logic.Finders
{
    public class DFS : AbstractFinder, IFinder
    {
        private readonly int _depthLimit = 20;
        private Stack<INode> frontier = new Stack<INode>();

        public override IReadOnlyCollection<INode> Frontier { get { return frontier; } }

        public override System.Func<INode, List<IOperator>, INode> FindSolution => Algorithm;

        public override System.Func<INode, int> HeuristicFunction => (_) => 1;

        public INode Algorithm(INode node, List<IOperator> operatorsSequence)
        {
            Explored.Add(node);
            if (CheckIfSolution(node))
            {
                return node;
            }

            while (true)
            {
                foreach (IOperator op in operatorsSequence)
                {
                    INode kid = FindChild(node, op);
                    if (kid != null)
                    {
                        Depth = kid.Depth;
                        if (CheckIfSolution(kid))
                        {
                            return kid;
                        }
                        else if (!Explored.Contains(kid) && kid.Depth < _depthLimit)
                        {
                            frontier.Push(kid);
                            Explored.Add(kid);
                        }
                    }
                }
                node = frontier.Pop();
            }
        }
    }
}
