using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IState : ICloneable
    {
        byte StateSize { get; }
        byte[] State { get; }
        byte ZeroIndex { get; }

        IState CloneSwap(byte i1, byte i2);
    }
}
