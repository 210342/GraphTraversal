using System.Collections.Generic;
using Library.BasicTypes;
using Library.Interfaces;

namespace GraphExploring.Logic.Finders
{
    public sealed class DFS : AbstractFinder
    {
        private readonly int _depthLimit = 20;
        private readonly Stack<Node> frontier = new();

        public override IReadOnlyCollection<Node> Frontier { get { return frontier; } }

        public override System.Func<Node, List<IOperator>, byte[], Node> FindSolution => Algorithm;

        public override System.Func<Node, int> HeuristicFunction => (_) => 1;

        private Node Algorithm(Node node, List<IOperator> operatorsSequence, byte[] expectedSolution)
        {
            _expectedSolution = expectedSolution;
            Explored.Add(node);
            if (CheckIfSolution(node))
            {
                return node;
            }

            while (true)
            {
                foreach (IOperator op in operatorsSequence)
                {
                    Node kid = FindChild(node, op);
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
