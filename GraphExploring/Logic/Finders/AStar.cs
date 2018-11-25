using GraphExploring.Logic.Finders.HeuristicDistance;
using Library.Interfaces;
using System;
using System.Collections.Generic;

namespace GraphExploring.Logic.Finders
{
    public class AStar : AbstractFinder
    {
        private readonly LinkedList<INode> frontier = new LinkedList<INode>();

        public override IReadOnlyCollection<INode> Frontier { get { return frontier; } }

        public override Func<INode, int> HeuristicFunction { get; }

        public override Func<INode, List<IOperator>, INode> FindSolution => Algorithm;

        public AStar(HeuristicProvider heuristicProvider)
        {
            HeuristicFunction = heuristicProvider.Heuristic;
        }

        public INode Algorithm(INode node, List<IOperator> operatorsSequence)
        {
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
                    INode kid = FindChild(node, op);
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
                                LinkedListNode<INode> InsertAfter = frontier.First;
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
