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
                List<INode> result = new List<INode>();
                for (int i = 0; i < opCount; ++i)
                {
                    IOperator reverseOp = OperatorsCollection.GetReverse(node.LastOperation);
                    if (operatorsSequence[i] != reverseOp)
                    {
                        result.Add(operatorsSequence[i].Move(node));
                    }
                    else
                    {

                    }
                }
                result.ForEach( n => node.Children.Add(n) );
            }
        }

        protected INode FindChild(INode node, IOperator op)
        {
            if(node.Children != null)
            {
                INode child;
                IOperator reverseOp = OperatorsCollection.GetReverse(node.LastOperation);
                if (op != reverseOp)
                {
                    child = op.Move(node);
                    node.Children.Add(child);
                }
                else
                {
                    child = null;
                }
                return child;
            }
            return null;
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
