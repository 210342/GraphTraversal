using Library.BasicTypes;

namespace GraphExploring.Logic.Finders.HeuristicDistance
{
    public class Hamming(NodeState state) : HeuristicProvider(state.State)
    {
        public override int Heuristic(Node node)
        {
            int misplaced = 0;
            for (byte i = 0; i < SolutionToFind.Length; ++i)
            {
                if (node.State.State[i] != SolutionToFind[i]
                    && node.State.State[i] != 0 && SolutionToFind[i] != 0)
                {
                    ++misplaced;
                }
            }
            return misplaced;
        }
    }
}
