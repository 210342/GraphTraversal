using System.Collections.Generic;
using Library.Interfaces;

namespace GraphExploring.Logic.Finders
{
    public class DFS : AbstractFinder, IFinder
    {
        private readonly int _depthLimit = 20;

        public override IReadOnlyCollection<INode> Frontier { get; } = new Stack<INode>();

        public override Heuristic HeuristicFunction => (_) => 1;

        public override FindAlgorithm FindSolution => Algorithm;

        public INode Algorithm(INode node, List<IOperator> operatorsSequence)
        {
            // check if its the solution
            // get neighbours
            // add neighbours to explored
            // add neighbours to frontier
            // take last from Frontier
            // repeat

            while (!CheckIfSolution(node))
            {
                foreach (IOperator op in operatorsSequence)
                {
                    INode kid = FindChild(node, op);
                    if (kid != null && !Explored.Contains(kid) && kid.Depth <= _depthLimit)
                    {
                        kid.SummedCost = node.SummedCost + HeuristicFunction(kid);
                        (Frontier as Stack<INode>).Push(kid);
                        Explored.Add(kid);
                        if (CheckIfSolution(kid))
                            break;
                    }
                }
                node = (Frontier as Stack<INode>).Pop();
                Depth = node.Depth;
            }
            return node;
        }
    }
}
