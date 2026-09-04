using GraphExploring.Logic.Finders.HeuristicDistance;
using Library.BasicTypes;
using Library.Interfaces;
using System;
using System.Collections.Generic;

namespace GraphExploring.Logic.Finders
{
    public sealed class AStar(HeuristicProvider heuristicProvider) : AbstractFinder
    {
        private readonly LinkedList<Node> frontier = new();

        public override IReadOnlyCollection<Node> Frontier { get { return frontier; } }

        public override Func<Node, int> HeuristicFunction { get; } = heuristicProvider.Heuristic;

        public override Func<Node, List<IOperator>, byte[], Node> FindSolution => Algorithm;

        private Node Algorithm(Node node, List<IOperator> operatorsSequence, byte[] expectedSolution)
        {
            _expectedSolution = expectedSolution;
            frontier.AddFirst(node);
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
                    if(kid != null)
                    {
                        Depth = kid.Depth;
                        if(CheckIfSolution(kid))
                        {
                            frontier.RemoveFirst();
                            return kid;
                        }
                        else if (!Explored.Contains(kid))
                        {
                            kid.SummedCost = node.SummedCost + HeuristicFunction(kid);
                            if (kid.SummedCost < frontier.First.Value.SummedCost)
                            {
                                frontier.AddFirst(kid);
                            }
                            else
                            {
                                LinkedListNode<Node> InsertAfter = frontier.First;
                                while (InsertAfter.Next != null && kid.SummedCost > InsertAfter.Next.Value.SummedCost)
                                {
                                    InsertAfter = InsertAfter.Next;
                                }
                                frontier.AddAfter(InsertAfter, kid);
                            }
                            Explored.Add(kid);
                        }
                    }
                }
                frontier.RemoveFirst();
                node = frontier.First.Value;
            }
        }
    }
}
