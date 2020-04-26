<Query Kind="Program" />

void Main()
{
	//PremitiveQueue();
	var myQueue = new MyQueue<Student>(5);
	myQueue.EnQueue(new Student() {FirstName="Khurram", LastName="Sheharyar"});
	myQueue.EnQueue(new Student() {FirstName="Shehzad", LastName="Khan"});
	myQueue.EnQueue(new Student() {FirstName="Afandyar", LastName="Khan"});
	myQueue.EnQueue(new Student() {FirstName="Huma", LastName="Bibi"});
	myQueue.EnQueue(new Student() {FirstName="Ayesha", LastName="Shahryar"});
	myQueue.EnQueue(new Student() {FirstName="Ayesha", LastName="Baloch"});
	
	Console.WriteLine("Queue : {0}", myQueue.ToString());
	
}

public void PremitiveQueue()
{
	var myQueue = new MyQueue<int>(5);
	myQueue.EnQueue(1);
	myQueue.EnQueue(2);
	myQueue.EnQueue(3);
	myQueue.EnQueue(4);
	myQueue.EnQueue(5);
	myQueue.EnQueue(6);
	Console.WriteLine("Queue : {0}", myQueue.ToString());
	Console.WriteLine("DeQueue : {0}", myQueue.DeQueue());
	Console.WriteLine("DeQueue : {0}", myQueue.DeQueue());
	Console.WriteLine("DeQueue : {0}", myQueue.DeQueue());
	Console.WriteLine("Queue : {0}", myQueue.ToString());
	myQueue.EnQueue(7);
	Console.WriteLine("Queue : {0}", myQueue.ToString());
	myQueue.DeQueue();
	myQueue.DeQueue();
	myQueue.DeQueue();
	Console.WriteLine("Queue : {0}", myQueue.ToString());
	myQueue.EnQueue(19);
	Console.WriteLine("Queue : {0}", myQueue.ToString());
}

// Define other methods and classes here
public class MyQueue<T>
{
	T[] queue; 
	int front;
	int size;
	
	public MyQueue(int size)
	{			
		queue = new T[size]; 
		front = -1;
		this.size = size; 
	}
	
	public bool IsEmpty()
	{
		return front == -1;
	}
	
	public bool IsFull()
	{
		return front == size-1; 
	}
	
	public void EnQueue(T t)
	{
		if(IsFull())
			return; 
		
		queue[++front] = t;
	}
	public T DeQueue()
	{
		T t = default(T); 
		if(IsEmpty())
			return t; 
		
		return queue[front--];
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder(); 
		for(int i = 0; i <= front; i++)
		{
			sb.AppendLine(queue[i].ToString());
		}
		return sb.ToString();
	}
}

public class Student
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public override string ToString()
	{
		return string.Format("{0}, {1}", FirstName, LastName);
	}	
}