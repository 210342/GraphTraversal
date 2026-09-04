using Library.BasicTypes;

namespace GraphExploring.Logic.Finders.HeuristicDistance
{
    public abstract class HeuristicProvider(byte[] solution)
    {
        protected byte[] SolutionToFind { get; private set; } = solution;

        public abstract int Heuristic(Node node);
    }
}
