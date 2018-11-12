using Library.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Library.Logic.Finders
{
    public class AbstractFinder
    {
        protected void FindChildren(INode node, List<IOperator> operatorsSequence)
        {
            if (node.Children == null)
            {
                int opCount = operatorsSequence.Count();
                INode[] result = new INode[opCount];
                for (int i = 0; i < opCount; ++i)
                {
                    IOperator reverseOp = OperatorsCollection.GetReverse(node.LastOperation);
                    if (operatorsSequence[i] != reverseOp)
                    {
                        result[i] = operatorsSequence[i].Move(node);
                    }
                    else
                    {
                        result[i] = null;
                    }
                }
                node.Children = result;
            }
        }
        protected bool CheckIfSolution(INode node)
        {
            for (int i = 0; i < node.State.StateSize - 1; ++i) // ignore last element - if 15 elements are in their place, the last one is as well
            {
                if (node.State.State[i] != i + 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
