using GraphExploring.Logic;
using GraphExploring.Logic.Finders;
using GraphExploring.Logic.Finders.HeuristicDistance;
using Library.Interfaces;
using System;
using System.IO;

namespace ConsoleEndpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] solutionState = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
            
            if(args.Length == 5)
            {
                GraphExplorer explorer = null;
                IFinder finder = null;
                string inputFile = args[2];
                string outputFile = args[3];
                string dataFile = args[4];
                string operations = null;
                try
                {
                    switch (args[0])
                    {
                        case "bfs":
                            finder = new BFS();
                            operations = args[1].ToLower();
                            break;
                        case "dfs":
                            finder = new DFS();
                            operations = Reverse(args[1].ToLower());
                            break;
                        case "astr":
                            HeuristicProvider heuristicProvider = null;
                            switch (args[1])
                            {
                                case "manh":
                                    heuristicProvider = new Manhattan(solutionState);
                                    break;
                                case "hamm":
                                    heuristicProvider = new Hamming(solutionState);
                                    break;
                            }
                            operations = "lrud";
                            finder = new AStar(heuristicProvider);
                            break;
                    }
                    var (dimensions, root) = LoadInputFile(inputFile);
                    explorer = GraphExplorer.CreateGraphExplorer(dimensions,
                        root, operations.ToCharArray(), finder);
                }
                catch(NullReferenceException e)
                {
                    Console.WriteLine($"Wrong parameters format {Environment.NewLine}{e.Message}");
                }
                catch(FormatException e)
                {
                    Console.WriteLine($"Wrong input file format {Environment.NewLine}{e.Message}");
                }
                string solution = explorer.TraverseForSolution();
                WriteOutputFiles(outputFile, dataFile, solution, explorer);
            }
        }

        private static (byte[], byte[]) LoadInputFile(string filepath)
        {
            string content = File.ReadAllText(filepath);
            content = content.Replace("\r\n", " ");
            content = content.Replace("\r", " ");
            content = content.Replace("\n", " ");
            string[] numbers = content.Split(' ');
            byte[] dim = new byte[] { byte.Parse(numbers[0]), byte.Parse(numbers[1]) };
            int size = dim[0] * dim[1];
            byte[] output = new byte[size];
            for(int i = 0; i < size; ++i)
            {
                output[i] = byte.Parse(numbers[2 + i]); // omit first 2 strings
            }
            return (dim, output);
        }

        private static void WriteOutputFiles(string solutionFile, string dataFile, string solution, GraphExplorer explorer)
        {
            using (StreamWriter writer = new StreamWriter(File.OpenWrite(solutionFile)))
            {
                if(string.IsNullOrEmpty(solution))
                {
                    writer.WriteLine("-1");
                }
                else
                {
                    writer.WriteLine($"{solution.Length}");
                    writer.WriteLine(solution);
                }
            }

            using (StreamWriter writer = new StreamWriter(File.OpenWrite(dataFile)))
            {
                if (string.IsNullOrEmpty(solution))
                {
                    writer.WriteLine("-1");
                }
                else
                {
                    writer.WriteLine($"{solution.Length}");
                }
                writer.WriteLine(explorer.Visited);
                writer.WriteLine(explorer.Explored);
                writer.WriteLine(explorer.MaximumRecursionDepth);
                long nanoseconds = explorer.TimeSpanInNanoseconds;
                long microseconds = nanoseconds / 1000;
                long miliseconds = microseconds / 1000;
                writer.WriteLine($"{miliseconds},{microseconds % 1000}");
            }
        }

        private static string Reverse(string text)
        {
            if (text == null)
            {
                return null;
            }
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
