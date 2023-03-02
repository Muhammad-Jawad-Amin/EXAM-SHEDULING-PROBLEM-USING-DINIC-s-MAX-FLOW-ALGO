
namespace DAA_PROJECT_APPLICATION
{
	internal class NODE<T>
	{
		private T Data;
		private NODE<T> Next;
		private  NODE<T> Previous;

		public T getData()
		{
			return Data;
		}

		public void setData(T Data)
		{
			this.Data = Data;
		}

		public NODE<T> getNext()
		{
			return Next;
		}

		public void setNext(NODE<T> Next)
		{
			this.Next = Next;
		}

		public NODE<T> getPrevious()
		{
			return Previous;
		}

		public void setPrevious(NODE<T> Previous)
		{
			this.Previous = Previous;
		}
	}
}
