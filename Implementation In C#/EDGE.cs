using System;

namespace DAA_PROJECT_APPLICATION
{
    internal class EDGE
    {
        public int From;
        public String F_Name;
        public String T_Name;
        public int To;
        public long Flow;
        public long Capacity;
        public EDGE Residual;

        public EDGE(int From, int To, long Capacity)
        {
            this.From = From;
            this.To = To;
            this.Capacity = Capacity;
            this.Flow = 0;
            this.Residual = null;
        }

        public EDGE(int From, String F_Name ,  int To , String T_Name, long Capacity)
        {
            this.From = From;
            this.F_Name=F_Name;
            this.To = To;
            this.T_Name=T_Name;
            this.Capacity = Capacity;
            this.Flow = 0;
            this.Residual = null;
        }

        public bool IsResidual()
        {
            return this.Capacity == 0;
        }

        public long RemainingCapacity()
        {
            return this.Capacity - this.Flow;
        }

        public void Augment(long BottleNeck)
        {
            this.Flow += BottleNeck;
            this.Residual.Flow -= BottleNeck;
        }

        public String Display(int S, int T)
        {
            String U = (this.From == S) ? "S" : ((this.From == T) ? "T" : Convert.ToString(From));
            String V = (this.To == S) ? "S" : ((this.To == T) ? "T" : Convert.ToString(To));
            return $"Edge : {U} -> {V} | Flow = {this.Flow} | Capacity = {this.Capacity} | is Residual: {this.IsResidual()}";
        }

        public String DisplayDetail()
        {
            return $"Edge : {this.F_Name} -> {this.T_Name} | Flow = {this.Flow} | Capacity = {this.Capacity} | is Residual: {this.IsResidual()}";
        }
    }
}
