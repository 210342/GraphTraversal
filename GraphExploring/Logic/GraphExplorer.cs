using Library.BasicTypes;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GraphExploring.Logic
{
    public class GraphExplorer
    {
        public INode RootNode { get; private set; }
        
        public IFinder Finder { get; set; }
        private List<IOperator> operatorsSequence = new List<IOperator>();

        public static GraphExplorer CreateGraphExplorer(byte[] loadedRoot, char[] operations)
        {
            GraphExplorer graphExplorer = new GraphExplorer();
            IState state = new NodeState(loadedRoot);
            INode node = new Node(null, null, state, depth: 0);
            graphExplorer.RootNode = node;
            foreach(char op in operations)
            {
                var currOp = OperatorsCollection.GetOperator(op);
                if (currOp != null)
                {
                    graphExplorer.operatorsSequence.Add(currOp);
                }
                else
                    throw new InvalidOperationException($"Operator {op} is not known to explorer.");
            }
            return graphExplorer;
        }
        public static GraphExplorer CreateGraphExplorer(byte[] loadedRoot, char[] operations, IFinder finder)
        {
            var explorer = CreateGraphExplorer(loadedRoot, operations);
            explorer.Finder = finder;
            return explorer;
        }

        public bool IsRootNode(INode node)
        {
            return node.Parent == null;
        }

        public string TraverseForSolution()
        {
            if (Finder == null)
                throw new InvalidOperationException("Can't traverse with null finder, please assign Finder property.");
            string Reverse(string text)
            {
                if (text == null) return null;
                char[] array = text.ToCharArray();
                Array.Reverse(array);
                return new string(array);
            }

            StringBuilder sb = new StringBuilder();
            try
            {
                INode solution = Finder.FindSolution(RootNode, operatorsSequence);
                if (solution != null)
                {
                    INode currNode = solution;
                    while(currNode.Parent != null)
                    {
                        sb.Append(currNode.LastOperation.Representation);
                        currNode = currNode.Parent;
                    }
                    return Reverse(sb.ToString());
                }
                return null;
            }
            catch(Exception e)
            {
                Trace.TraceError("Exception caught during Find process. " + e.Message);
                Trace.Flush();
            }
            return null;
        }

        private GraphExplorer() { }
    }
}
