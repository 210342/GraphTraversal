using Library.Interfaces;

namespace GraphExploring.Logic.Finders.HeuristicDistance
{
    class Hamming : HeuristicProvider
    {
        public Hamming(AbstractFinder finder) : base(finder)
        {
        }

        public override int Heuristic(INode node)
        {
            int misplaced = 0;
            for(byte i = 0; i < SolutionToFind.Length; ++i)
            {
                if (node.State.State[i] != SolutionToFind[i]
                    && node.State.State[i] != 0)
                    ++misplaced;
            }
            return misplaced;
        }
    }
}
