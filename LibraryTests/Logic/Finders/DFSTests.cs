using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GraphExploring.Logic;
using GraphExploring.Logic.Finders;
using System.Diagnostics.CodeAnalysis;
using Library.BasicTypes;

namespace GraphExploring.Logic.Finders.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass()]
    public class DFSTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            OperatorsCollection.GetOperator('l');
            OperatorsCollection.GetOperator('r');
            OperatorsCollection.GetOperator('d');
            OperatorsCollection.GetOperator('u');
        }

        [TestMethod()]
        public void FindSolutionTest()
        {
            byte[] puzzle = new byte[] { 2, 5, 3, 4, 1, 7, 11, 8, 10, 6, 14, 0, 9, 13, 15, 12 };
            // byte[] puzzle = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 13, 11, 12, 9, 14, 0, 15 };
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer
                (new byte[] { 4, 4 }, 
                puzzle,
                new char[] { 'u', 'd', 'l', 'r' }, new DFS());
            explorer.TargetState = new NodeState(new byte[] { 4, 4 },
                new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 });
            string sol = explorer.TraverseForSolution();
            Assert.IsFalse(string.IsNullOrEmpty(sol));
        }
    }
}