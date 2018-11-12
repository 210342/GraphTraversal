using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library.Logic.Finders
{
    public class DFS : AbstractFinder, IFinder
    {
        private int depth = 0;
        private readonly int _depthLimit = 20;

        public IReadOnlyCollection<INode> Frontier { get; } = new Stack<INode>();
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
        public int MaximumDepthReached { get; private set; }
        public Heuristic HeuristicFunction { get; } = (_) => 1;

        public INode FindSolution(INode node, List<IOperator> operatorsSequence)
        {
            // check if its the solution
            // get neighbours
            // add neighbours to explored
            // add neighbours to frontier
            // take last from Frontier
            // repeat
            while (!CheckIfSolution(node))
            {
                FindChildren(node, operatorsSequence);
                for (int i = 0; i < operatorsSequence.Count; ++i)
                {
                    INode kid = node.Children[i];
                    if (kid != null && !Explored.Contains(kid) && kid.Depth <= _depthLimit)
                    {
                        kid.SummedCost = node.SummedCost + HeuristicFunction(kid);
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
