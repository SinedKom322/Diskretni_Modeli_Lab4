using PathSearching;
using System;
using System.Collections.Generic;
using System.IO;
using Algorithms.Solvers;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            IOConsole console = new IOConsole();


            Console.WriteLine("Enter the filename: ");
            var filename = Console.ReadLine();
            if (!File.Exists(filename))
            {
                Console.WriteLine("The file \"" + filename + "\" does not exist");
                Console.ReadKey();
            }
            console = new IOConsole(filename);
            console.ReadMatrix();
            console.WriteMatrix(console.CMatrix);
            Console.WriteLine("Ford-Fulkerson solution:");
            Solver solve = new Solver(console.From - 1, console.To - 1, console.N, console.CMatrix);
            console.WriteFlowMatrixToConsole(console.CMatrix, console.GetNullMatrix());
            solve.FordFulkerson();
            Console.WriteLine($"Result: Max F = {solve.F}\n");
            console.WriteFlowMatrixToConsole(console.CMatrix, solve.FlowMatrix.FlowToIntMatrix());
            Console.ReadKey();
        }
    }
}
       
