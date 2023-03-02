using System;

namespace DAA_PROJECT_APPLICATION
{
    internal abstract class NETWORKFLOWSOLVER
    {
        // To avoid overflow, set infinity to a value less than Long.MAX_VALUE;
        protected static long INF = long.MaxValue/ 2;

        // Inputs: n = number of nodes, s = source, t = sink
        protected int N, S, T;

        // Indicates whether the network flow algorithm has ran. The solver only
        // needs to run once because it always yields the same result.
        protected bool Solved;

        // The maximum flow. Calculated by calling the {@link #solve} method.
        protected long MaxFlow;

        // The adjacency list representing the flow graph and residual graph.
        protected DOUBLYLINKLIST<EDGE>[] Graph;
        protected DOUBLYLINKLIST<EDGE>[] ResidualGraph;

       
        //Creates an instance of a flow network solver. Use the {@link #addEdge} method to add edges to
        //the graph.
        //n - The number of nodes in the graph including s and t.
        //s - The index of the source node, 0 <= s < n
        //t - The index of the sink node, 0 <= t < n and t != s
        
        public NETWORKFLOWSOLVER(int N, int S, int T)
        {
            this.N = N;
            this.S = S;
            this.T = T;
            this.InitializeEmptyFlowGraph();
        }

        // Constructs an empty graph with n nodes including s and t.
      
        private void InitializeEmptyFlowGraph()
        {
            this.Graph = new DOUBLYLINKLIST<EDGE>[this.N];
            this.ResidualGraph = new DOUBLYLINKLIST<EDGE>[this.N];
            for (int i = 0; i < this.N; i++)
            {
                this.Graph[i] = new DOUBLYLINKLIST<EDGE>();
                this.ResidualGraph[i] = new DOUBLYLINKLIST<EDGE>();
            }
        }

         //Adds a directed edge (and its residual edge) to the flow graph.
         //from - The index of the node the directed edge starts at.
         //to - The index of the node the directed edge ends at.
         //capacity - The capacity of the edge
         
        public void AddEdge(int From, int To, long Capacity)
        {
            if (Capacity <= 0)
            {
                throw new ArgumentException("Forward edge capacity <= 0");
            }
            EDGE E1 = new EDGE(From, To, Capacity);
            EDGE E2 = new EDGE(To, From, 0);
            E1.Residual = E2;
            E2.Residual = E1;
            this.Graph[From].Add(E1);
            this.Graph[To].Add(E2);
            this.ResidualGraph[From].Add(E1);
            this.ResidualGraph[To].Add(E2);
        }

        public void AddEdge(int From, String F_Name , int To, String T_Name, long Capacity)
        {
            if (Capacity <= 0)
            {
                throw new ArgumentException("Forward edge capacity <= 0");
            }
            EDGE E1 = new EDGE(From,F_Name , To , T_Name, Capacity);
            EDGE E2 = new EDGE(To, T_Name ,  From , F_Name , 0);
            E1.Residual = E2;
            E2.Residual = E1;
            this.Graph[From].Add(E1);
            this.Graph[To].Add(E2);
            this.ResidualGraph[From].Add(E1);
            this.ResidualGraph[To].Add(E2);
        }

        //Returns the residual graph after the solver has been executed. This allows you to inspect the
        //flow and capacity values of each edge. This is useful if you are
        //debugging or want to figure out which edges were used during the max flow.
        public DOUBLYLINKLIST<EDGE>[] GetGraph()
        {
            this.Execute();
            return this.ResidualGraph;
        }

        // Returns the maximum flow from the source to the sink.
        public long GetMaxFlow()
        {
            this.Execute();
            return this.MaxFlow;
        }

        // Wrapper method that ensures we only call solve() once
        private void Execute()
        {
            if(this.Solved)
            {
                return;
            }
            this.Solved = true;
            this.Solve();
        }

        protected void CreateGraph(int[] Input ,int N)
        {
            int Counter;
            for(Counter =0 ; Counter < Input[0]; Counter++)
            {
                this.AddEdge(N-1 , "Source" , Counter , $"Class {Counter+1}" , 1);
            }

            for ( ; Counter < (Input[1] + Input[0]) ; Counter++)
            {
                for(int i=0 ; i<Input[0] ; i++ )
                {
                    this.AddEdge(i, $"Class {i+1}" , Counter, $"Room {Counter-(Input[0]) + 1}" ,  1);
                }
            }

            for (; Counter < (Input[1] + Input[0] + Input[2]); Counter++)
            {
                for (int i = Input[0]; i < (Input[1]+Input[0]); i++)
                {
                    this.AddEdge(i, $"Room {(i- Input[0]) + 1}" , Counter, $"TimeSlot {Counter-(Input[1] + Input[0]) + 1}" , 1);
                }
            }

            for (; Counter < (Input[1] + Input[0] +Input[2] + Input[3]); Counter++)
            {
                for (int i = (Input[1]+Input[0]); i < (Input[0]+Input[1]+Input[2]); i++)
                {
                    this.AddEdge(i, $"TimeSlot {(i- (Input[1] + Input[0])) +1}" , Counter , $"Proctor {Counter - (Input[1] + Input[0]+ Input[2]) + 1}" , 1);
                }
            }

            for (Counter = Counter-Input[3] ; Counter < N-2 ; Counter++)
            {
                this.AddEdge(Counter , $"Proctor {Counter - (Input[1] + Input[0] + Input[2]) + 1}" , N-2, "Sink" , Input[4]);
            }
        }

        // Method to implement which solves the network flow problem.
        public abstract void Solve();
    }
}
