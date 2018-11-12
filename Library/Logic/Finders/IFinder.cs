using Library.Interfaces;
using System.Collections.Generic;

namespace Library.Logic.Finders
{
    public interface IFinder
    {
        IReadOnlyCollection<INode> Frontier { get; }
        HashSet<INode> Explored { get; }
        int MaximumDepthReached { get; }
        Heuristic HeuristicFunction { get; }
        INode FindSolution(INode node, List<IOperator> operatorsSequence);
    }
}
