using System.Collections.Generic;

namespace Library.Interfaces
{
    public interface IFinder
    {
        IReadOnlyCollection<INode> Frontier { get; }
        HashSet<INode> Explored { get; }
        int MaximumDepthReached { get; }
        System.Func<INode, int> HeuristicFunction { get; }
        System.Func<INode, List<IOperator>, INode> FindSolution { get; }
    }
}
