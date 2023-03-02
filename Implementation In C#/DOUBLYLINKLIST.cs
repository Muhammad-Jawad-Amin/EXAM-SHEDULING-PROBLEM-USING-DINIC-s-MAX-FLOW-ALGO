using System;

namespace DAA_PROJECT_APPLICATION
{
	internal class DOUBLYLINKLIST<T>
	{
		private NODE<T> HeadNode;
		private NODE<T> CurrentNode;
		private NODE<T> TraverseNode;
		private int Length;

		public DOUBLYLINKLIST()
		{
			HeadNode = new NODE<T>();
			HeadNode.setNext(null);
			HeadNode.setPrevious(null);
			CurrentNode = null;
			Length = -1;
		}

		public int Size()
		{
			return Length + 1;
		}

		public bool Empty()
		{
			if (Length == -1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Add(T Data)
		{
			NODE<T> NewNode = new NODE<T>();
			NewNode.setData(Data);
			if (CurrentNode != null)
			{
				NewNode.setNext(null);
				NewNode.setPrevious(CurrentNode);
				CurrentNode.setNext(NewNode);
				CurrentNode = NewNode;
			}
			else
			{
				NewNode.setNext(null);
				NewNode.setPrevious(HeadNode);
				HeadNode.setNext(NewNode);
				CurrentNode = NewNode;
			}
			Length++;
		}

		public T Get(int Index)
		{
			if(Index >= 0 || Index <= Length)
            {
				TraverseNode = HeadNode;
				for (int i = 0; i <= Index && i <= Length; i++)
				{
					TraverseNode = TraverseNode.getNext();
				}

				return TraverseNode.getData();
			}
			else
            {
				throw new IndexOutOfRangeException();	
            }
		}

		public bool Remove()
		{
			if (CurrentNode != null && CurrentNode != HeadNode)
			{
				NODE<T> Temp = this.CurrentNode.getPrevious();
				Temp.setNext(null);
				CurrentNode = Temp;
				Length--;
				return true;
			}
            else
            {
				return false;
            }
		}

		public bool Remove(int Index)
		{
			if (Index >= 0 && Index < Length)
			{
				this.TraverseNode = this.HeadNode;
				for (int i = 0; i <= Index && i <= Length; i++)
				{
					this.TraverseNode = this.TraverseNode.getNext();
				}

				this.TraverseNode.getPrevious().setNext(TraverseNode.getNext());
				this.TraverseNode.getNext().setPrevious(TraverseNode.getPrevious());
				Length--;

				return true;
			}
			else if (Index == Length)
			{
				return this.Remove();
			}
			else
			{
				return false;
			}
		}

		public bool Remove(T Data)
		{
			TraverseNode = HeadNode;
			if(CurrentNode.getData().Equals(Data))
            {
				return this.Remove();
            }
			else
            {
				for (int i = 0; i < Length; i++)
				{
					TraverseNode = TraverseNode.getNext();
					if (TraverseNode.getData().Equals(Data))
					{
						this.TraverseNode.getPrevious().setNext(TraverseNode.getNext());
						this.TraverseNode.getNext().setPrevious(TraverseNode.getPrevious());
						Length--;
						return true;
					}
				}
			}
			return false;
		}

		private DOUBLYLINKLIST<T> Clone()
		{
			DOUBLYLINKLIST<T> List = new DOUBLYLINKLIST<T>();
			TraverseNode = this.HeadNode.getNext();
			for (int i = 0; i <= Length; i++)
			{
				List.Add(TraverseNode.getData());
				TraverseNode = TraverseNode.getNext();
			}
			return List;
		}

		public void AddAll(DOUBLYLINKLIST<T> Real_List)
		{
			DOUBLYLINKLIST<T> List = Real_List.Clone();
			if (HeadNode.getNext() != null)
			{
				this.CurrentNode.setNext(List.HeadNode.getNext());
				List.HeadNode.getNext().setPrevious(this.CurrentNode);
				this.CurrentNode = List.CurrentNode;
				Length += (List.Length) + 1;
			}
			else
			{
				this.CurrentNode = List.CurrentNode;
				this.HeadNode.setNext(List.HeadNode.getNext());
				Length += (List.Length) + 1;
			}
		}

		public bool Update(int Index, T Data)
		{
			if (Index >= 0 && Index <= Length)
			{
				TraverseNode = HeadNode;
				for (int i = 0; i <= Index && i <= Length; i++)
				{
					TraverseNode = TraverseNode.getNext();
				}

				TraverseNode.setData(Data);
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool Find(T Data)
		{
			TraverseNode = HeadNode;
			for (int i = 0; i <= Length; i++)

			{
				TraverseNode = TraverseNode.getNext();
				if (TraverseNode.getData().Equals(Data))
				{
					return true;
				}
			}
			return false;
		}
	}
}
