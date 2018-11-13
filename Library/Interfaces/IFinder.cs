using System.Collections.Generic;

namespace Library.Interfaces
{
    public delegate int Heuristic(INode node);
    public delegate INode FindAlgorithm(INode node, List<IOperator> operatorsSequence);
    public interface IFinder
    {
        IReadOnlyCollection<INode> Frontier { get; }
        HashSet<INode> Explored { get; }
        int MaximumDepthReached { get; }
        Heuristic HeuristicFunction { get; }
        //INode FindSolution(INode node, List<IOperator> operatorsSequence);
        FindAlgorithm FindSolution { get;  }
    }
}
