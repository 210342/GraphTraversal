using Library.BasicTypes;
using Library.BasicTypes.Operators;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Logic
{
    public class GraphExplorer
    {
        public INode RootNode { get; private set; }

        private static Dictionary<char, SingletonOperator> knownOperators =
            new Dictionary<char, SingletonOperator>()
            {
                {'l', (SingletonOperator)LeftOperator.Instance },
                {'r', (SingletonOperator)RightOperator.Instance },
                {'u', (SingletonOperator)UpOperator.Instance },
                {'d', (SingletonOperator)DownOperator.Instance }
            };

        private List<IOperator> operatorsSequence = new List<IOperator>();

        public static GraphExplorer CreateGraphExplorer(byte[] loadedRoot, char[] operations)
        {
            GraphExplorer graphExplorer = new GraphExplorer();
            IState state = new NodeState(loadedRoot);
            INode node = new Node(null, null, state);
            graphExplorer.RootNode = node;
            foreach(char op in operations)
            {
                if (knownOperators.TryGetValue(op, out SingletonOperator toAdd))
                {
                    graphExplorer.operatorsSequence.Add(toAdd);
                }
                else
                    throw new InvalidOperationException($"Operator {op} is not known to explorer.");
            }
            return graphExplorer;
        }
        private GraphExplorer() { }
    }
}
