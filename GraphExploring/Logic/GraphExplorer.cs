using Library.BasicTypes;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GraphExploring.Logic
{
    public class GraphExplorer
    {
        public INode RootNode { get; private set; }
        
        public IFinder Finder { get; set; }

        private static OperatorsCollection knownOperators = OperatorsCollection.Instance;
        private List<IOperator> operatorsSequence = new List<IOperator>();

        public static GraphExplorer CreateGraphExplorer(byte[] loadedRoot, char[] operations)
        {
            GraphExplorer graphExplorer = new GraphExplorer();
            IState state = new NodeState(loadedRoot);
            INode node = new Node(null, null, state, depth: 0);
            graphExplorer.RootNode = node;
            foreach(char op in operations)
            {
                var currOp = knownOperators[op];
                if (currOp != null)
                {
                    graphExplorer.operatorsSequence.Add(currOp);
                }
                else
                    throw new InvalidOperationException($"Operator {op} is not known to explorer.");
            }
            return graphExplorer;
        }

        public bool IsRootNode(INode node)
        {
            return node.Parent == null;
        }

        public byte[] TraverseForSolution()
        {
            try
            {
                INode solution = Finder.FindSolution(RootNode, operatorsSequence);
                if (solution != null)
                    return solution.State.State;
                return null;
            }
            catch(Exception)
            {
                Trace.TraceError("Exception caught during Find process.");
                Trace.Flush();
            }
            return null;
        }

        private GraphExplorer() { }
    }
}
