using System;
using System.Collections.Generic;
using Library.Interfaces;

namespace GraphExploring.Logic.Finders
{
    public class BFS : AbstractFinder
    {
        private Queue<INode> frontier = new Queue<INode>();

        public override IReadOnlyCollection<INode> Frontier { get { return frontier; } }

        public override Func<INode, List<IOperator>, INode> FindSolution => Algorithm;

        public override Func<INode, int> HeuristicFunction => (_) => 1;

        public INode Algorithm(INode node, List<IOperator> operatorsSequence)
        {
            while (!CheckIfSolution(node))
            {
                foreach(IOperator op in operatorsSequence)
                {
                    INode kid = FindChild(node, op);
                    if (kid != null && !Explored.Contains(kid))
                    {
                        frontier.Enqueue(kid);
                        Explored.Add(kid);
                    }
                }
                node = frontier.Dequeue();
                Depth = node.Depth;
            }
            return node;
        }
    }
}
