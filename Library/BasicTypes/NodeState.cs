using Library.Interfaces;

namespace Library.BasicTypes
{
    public class NodeState : IState
    {
        public byte[] State { get; }

        public byte StateSize => (byte)State.Length;

        public byte ZeroIndex { get; set; }

        public NodeState(byte[] state)
        {
            State = state;
            for(byte i = 0; i < state.Length; ++i)
            {
                if(state[i] == 0)
                {
                    ZeroIndex = i;
                }
            }
        }

        public object Clone()
        {
            var copiedState = (byte[])State.Clone();
            return new NodeState(copiedState);
        }

        /// <summary>
        /// Clones given state but swaps values at given indexes
        /// </summary>
        /// <param name="zeroIndex">Index of a zero</param>
        /// <param name="otherIndex">Other index</param>
        /// <returns>Cloned state with swapped values</returns>
        public IState CloneSwap(byte zeroIndex, byte otherIndex)
        {
            var newClone = this.Clone() as IState;
            byte old = newClone.State[zeroIndex];
            newClone.State[zeroIndex] = newClone.State[otherIndex];
            newClone.State[otherIndex] = old;
            newClone.ZeroIndex = otherIndex; // it's other index since it's swapped
            return newClone;
        }
    }
}
