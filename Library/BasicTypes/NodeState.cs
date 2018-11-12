using Library.Interfaces;

namespace Library.BasicTypes
{
    public class NodeState : IState
    {
        public byte[] State { get; }

        public byte StateSize => (byte)State.Length;

        public sbyte ZeroIndex
        {
            get
            {
                for (sbyte i = 0; i < StateSize; ++i)
                {
                    if (State[i] == 0)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        public NodeState(byte[] state)
        {
            State = state;
        }

        public object Clone()
        {
            var copiedState = (byte[])State.Clone();
            return new NodeState(copiedState);
        }

        public IState CloneSwap(byte index1, byte index2)
        {
            var newClone = this.Clone() as IState;
            byte old = newClone.State[index1];
            newClone.State[index1] = newClone.State[index2];
            newClone.State[index2] = old;
            return newClone;
        }
    }
}
