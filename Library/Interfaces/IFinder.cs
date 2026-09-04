using System.Collections.Generic;
using Library.BasicTypes;

namespace Library.Interfaces
{
    public interface IFinder
    {
        IReadOnlyCollection<Node> Frontier { get; }
        HashSet<Node> Explored { get; }
        int MaximumDepthReached { get; }
        System.Func<Node, int> HeuristicFunction { get; }
        System.Func<Node, List<IOperator>, byte[], Node> FindSolution { get; }
    }
}
