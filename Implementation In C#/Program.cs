using System;
using System.IO;

namespace DAA_PROJECT_APPLICATION
{
    internal class Program
    {
        
         
        public static int[] UserInput(ref int N)
        {
            Console.WriteLine("GETTING THE BASIC INPUTS\n");
            StreamWriter sw = new StreamWriter(@"E:\VISUAL PROGRAMING\DAA PROJECT APPLICATION\BasicInput.txt");

            int[] Input = new int[5];
            Console.Write("Enter the number of classes : ");
            Input[0] = Convert.ToInt32(Console.ReadLine());
            sw.WriteLine($"No of classes are {Input[0]}.");
            N += Input[0];

            Console.Write("Enter the number of rooms : ");
            Input[1] = Convert.ToInt32(Console.ReadLine());
            sw.WriteLine($"No of rooms are {Input[1]}.");
            N += Input[1];

            Console.Write("Enter the number of time slots : ");
            Input[2] = Convert.ToInt32(Console.ReadLine());
            sw.WriteLine($"No of time slots are {Input[2]}.");
            N += Input[2];

            Console.Write("Enter the number of proctors : ");
            Input[3] = Convert.ToInt32(Console.ReadLine());
            sw.WriteLine($"No of proctors are {Input[3]}.");
            N += Input[3];

            Console.Write("Enter the number of exams that a proctor can oversee : ");
            Input[4] = Convert.ToInt32(Console.ReadLine());
            sw.WriteLine($"No of exams that a proctor can oversee {Input[4]}.");

            sw.Close();
            N = N + 2;
            return Input;
        }

        
        static void Main(string[] args)
        {

            Console.WriteLine("[RUNNING THE DINIC'S ALGORITHM TO SCHEDULE EXAMS]");
            Console.WriteLine("\n------------------------------------------------\n");

            int N=0;
            int[] Input = UserInput(ref N);
            int S = N - 1;
            int T = N - 2;

            DINICSALGO solver = new DINICSALGO(N, S, T, Input);
            Console.WriteLine($"\nMaximum flow:  {solver.GetMaxFlow()}\n");
            solver.DisplayFlowGraphWithDetail();


            //int N1 = 11;
            //int S1 = N1 - 1;
            //int T1 = N1 - 2;

            //NETWORKFLOWSOLVER Solver1;
            //Solver1 = new DINICSALGO(N1, S1, T1);

            //// Source edges
            //Solver1.AddEdge(S1, 0, 5);
            //Solver1.AddEdge(S1, 1, 10);
            //Solver1.AddEdge(S1, 2, 15);

            //// Middle edges
            //Solver1.AddEdge(0, 3, 10);
            //Solver1.AddEdge(1, 0, 15);
            //Solver1.AddEdge(1, 4, 20);
            //Solver1.AddEdge(2, 5, 25);
            //Solver1.AddEdge(3, 4, 25);
            //Solver1.AddEdge(3, 6, 10);
            //Solver1.AddEdge(4, 2, 5);
            //Solver1.AddEdge(4, 7, 30);
            //Solver1.AddEdge(5, 7, 20);
            //Solver1.AddEdge(5, 8, 10);
            //Solver1.AddEdge(7, 8, 15);

            //// Sink edges
            //Solver1.AddEdge(6, T1, 5);
            //Solver1.AddEdge(7, T1, 15);
            //Solver1.AddEdge(8, T1, 10);

            //// Prints: "Maximum flow: 30"
            //Console.WriteLine($"Maximum flow:  {Solver1.GetMaxFlow()}\n");
            //Solver1.DisplayFlowGraph();

            Console.ReadKey();
        }
    }
}
