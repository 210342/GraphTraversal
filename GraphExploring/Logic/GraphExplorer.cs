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
        private List<IOperator> operatorsSequence = new List<IOperator>();
        private readonly Stopwatch stopwatch = new Stopwatch();

        public INode RootNode { get; private set; }
        public IFinder Finder { get; set; }
        public int Explored { get { return Finder.Explored.Count - Finder.Frontier.Count; } }
        public int Visited { get { return Finder.Explored.Count; } }
        public int MaximumRecursionDepth { get { return Finder.MaximumDepthReached; } }
        public long TimeSpanInNanoseconds { get; private set; }

        public static GraphExplorer CreateGraphExplorer(byte[] dimensions, byte[] loadedRoot, char[] operations)
        {
            HashSet<byte> bytesFiltered = new HashSet<byte>(loadedRoot);
            if (bytesFiltered.Count != loadedRoot.Length)
                throw new InvalidOperationException("Numbers arent unique.");
            GraphExplorer graphExplorer = new GraphExplorer();
            IState state = new NodeState(dimensions, loadedRoot);
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
        public static GraphExplorer CreateGraphExplorer(byte[] dimensions, byte[] loadedRoot, char[] operations, IFinder finder)
        {
            var explorer = CreateGraphExplorer(dimensions, loadedRoot, operations);
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
            {
                throw new InvalidOperationException("Can't traverse with null finder, please assign Finder property.");
            }

            INode solution = null;
            try
            {
                stopwatch.Start();
                solution = Finder.FindSolution(RootNode, operatorsSequence);
                stopwatch.Stop();
                long nanosecPerTick = (1000000000) / Stopwatch.Frequency;
                TimeSpanInNanoseconds = stopwatch.ElapsedTicks * nanosecPerTick;
            }
            catch(Exception e)
            {
                Trace.TraceError("Exception caught during Find process. " + e.Message);
                Trace.Flush();
                stopwatch.Stop();
            }

            StringBuilder sb = new StringBuilder();
            if (solution != null)
            {
                INode currNode = solution;
                while (currNode.Parent != null)
                {
                    sb.Append(currNode.LastOperation.Representation);
                    currNode = currNode.Parent;
                }
                return Reverse(sb.ToString()).ToUpper();
            }
            string Reverse(string text)
            {
                if (text == null) return null;
                char[] array = text.ToCharArray();
                Array.Reverse(array);
                return new string(array);
            }
            return null;
        }

        private GraphExplorer() { }
    }
}
