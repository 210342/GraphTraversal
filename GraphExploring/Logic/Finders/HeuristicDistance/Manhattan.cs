using System.Runtime.CompilerServices;
using Library.BasicTypes;

namespace GraphExploring.Logic.Finders.HeuristicDistance
{
    public sealed class Manhattan(NodeState state) : HeuristicProvider(state.State)
    {
        private readonly byte rowSize = state.Dimensions[0];

        public override int Heuristic(Node node)
        {
            int sum = 0;
            for (byte i = 0; i < SolutionToFind.Length; ++i)
            {
                byte number = node.State.State[i];
                if (number != 0)
                {
                    var (currentX, currentY) = TranslateCoordinate(i);
                    var (originX, originY) = TranslateCoordinate(FindIndex(number));
                    sum += System.Math.Abs(originX - currentX) +
                        System.Math.Abs(originY - currentY);
                }
            }
            return sum;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private (int X, int Y) TranslateCoordinate(byte number)
        {
            return (number % rowSize, number / rowSize);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private byte FindIndex(byte number)
        {
            for (byte i = 0; i < SolutionToFind.Length; ++i)
            {
                if (SolutionToFind[i] == number)
                {
                    return i;
                }
            }
            return (byte)(SolutionToFind.Length + 1);
        }
    }
}
