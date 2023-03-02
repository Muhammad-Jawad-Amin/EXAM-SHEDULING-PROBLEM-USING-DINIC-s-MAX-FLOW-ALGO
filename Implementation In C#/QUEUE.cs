using System;

namespace DAA_PROJECT_APPLICATION
{
    public class QUEUE<T>
    {
        //---------------------------NODE----------------------------
        public class NODE<T>
        {
            private T Data;
            private NODE<T> Next;

            public NODE<T> Prop_Next
            {
                set
                {
                    this.Next = value;
                }
                get
                {
                    return this.Next;
                }
            }

            public T Prop_Data
            {
                set
                {
                    this.Data = value;
                }
                get
                {
                    return this.Data;
                }
            }
        }

        //---------------------LINKED QUEUE-----------------------

        private NODE<T> Head;
        private NODE<T> Tail;
        private static int Length;

        public QUEUE()
        {
            this.Head = null;
            this.Tail = null;
            Length = 0;
        }

        public static int Size()
        {
            return Length;
        }

        public bool IsEmpty()
        {
            if (Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EnQueue(T Data)
        {
            NODE<T> Temp;
            if (IsEmpty())
            {
                Temp = new NODE<T>();
                Temp.Prop_Data = Data;
                Temp.Prop_Next = null;

                Head = Temp;
                Tail = Temp;
                Length++;
            }
            else
            {
                Temp = new NODE<T>();
                Temp.Prop_Data = Data;
                Temp.Prop_Next = null;

                Tail.Prop_Next = Temp;
                Tail = Temp;
                Length++;
            }
        }

        public T DeQueue()
        {
            if (!IsEmpty())
            {
                T Temp;
                Temp = Head.Prop_Data;
                Head = Head.Prop_Next;
                Length--;
                return Temp;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
