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

        private INode Algorithm(INode node, List<IOperator> operatorsSequence)
        {
            Explored.Add(node);
            if(CheckIfSolution(node))
            {
                return node;
            }

            while (true)
            {
                foreach(IOperator op in operatorsSequence)
                {
                    INode kid = FindChild(node, op);
                    if(kid != null)
                    {
                        Depth = kid.Depth;
                        if (CheckIfSolution(kid))
                        {
                            return kid;
                        }
                        else if (!Explored.Contains(kid))
                        {
                            frontier.Enqueue(kid);
                            Explored.Add(kid);
                        }
                    }
                }
                node = frontier.Dequeue();
            }
        }
    }
}
