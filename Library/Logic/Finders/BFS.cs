using System.Collections.Generic;
using Library.Interfaces;

namespace Library.Logic.Finders
{
    public class BFS : SolutionChecker, IFinder
    {
        private int depth = 0;

        public IReadOnlyCollection<INode> Frontier { get; } = new Queue<INode>();
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
                if(value > MaximumDepthReached)
                {
                    MaximumDepthReached = value;
                }
            }
        }
        public int MaximumDepthReached { get; private set; }
        public Heuristic HeuristicFunction { get; } = (_) => 1;

        public INode FindSolution(INode node, List<IOperator> operatorsSequence)
        {
            // check if its the solution
            // get neighbours
            // add neighbours to explored
            // add neighbours to frontier
            // take first from Frontier
            // repeat
            while(!CheckIfSolution(node))
            {
                node.FindChildren(operatorsSequence);
                for(int i = 0; i < 4; ++i)
                {
                    INode kid = node.Children[i];
                    if(kid != null && !Explored.Contains(kid))
                    {
                        kid.SummedCost = node.SummedCost + HeuristicFunction(kid);
                        (Frontier as Queue<INode>).Enqueue(kid);
                        Explored.Add(kid);
                    }
                }
                node = (Frontier as Queue<INode>).Dequeue();
                Depth = node.Depth;
            }
            return node;
        }
    }
}
