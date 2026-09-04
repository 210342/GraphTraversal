namespace Library.BasicTypes
{
    public readonly struct NodeState
    {
        public readonly byte[] State;
        public readonly byte ZeroIndex;
        public readonly byte[] Dimensions;

        public NodeState(byte[] dim, byte[] state)
        {
            State = state;
            Dimensions = dim;
            for (byte i = 0; i < state.Length; ++i)
            {
                if (state[i] == 0)
                {
                    ZeroIndex = i;
                    break;
                }
            }
        }

        private NodeState(byte[] dim, byte[] state, byte zeroIndex)
        {
            State = state;
            Dimensions = dim;
            ZeroIndex = zeroIndex;
        }

        /// <summary>
        /// Clones given state but swaps values at given indexes
        /// </summary>
        /// <param name="zeroIndex">Index of a zero</param>
        /// <param name="otherIndex">Other index</param>
        /// <returns>Cloned state with swapped values</returns>
        public NodeState CloneSwap(byte zeroIndex, byte otherIndex)
        {
            var copiedState = (byte[])State.Clone();
            byte old = State[zeroIndex];
            copiedState[zeroIndex] = copiedState[otherIndex];
            copiedState[otherIndex] = old;
            return new NodeState(Dimensions, copiedState, otherIndex);
        }

        public override int GetHashCode()
        {
            int code = State.Length;

            for (int i = 0; i < State.Length; ++i)
            {
                code = code * 16661 + State[i];
            }

            return code;
        }
    }
}
