<Query Kind="Program">
  <NuGetReference>MSTest.TestFramework</NuGetReference>
  <NuGetReference>NUnit</NuGetReference>
  <NuGetReference>NUnit.Engine</NuGetReference>
  <NuGetReference>NUnit.Runners.lite</NuGetReference>
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>Microsoft.VisualStudio.TestTools.UnitTesting</Namespace>
  <Namespace>NUnit.Framework</Namespace>
</Query>

void Main()
{
	//StackTest();
}

public void StackTest()
{
	var stack = new Stack<int>(5);
	Console.WriteLine("Is Stack Empty: {0}", stack.IsEmpty());

	int item = 1;
	while (stack.Push(item) == item)
	{
		Console.WriteLine("Pushed : {0}", item);
		item++;
	}

	Console.WriteLine("Stack : {0}", stack.ToString());
	Console.WriteLine("Is Stack Full: {0}", stack.IsFull());
	Console.WriteLine("Pushing to Stack : {0}", stack.Push(item) == item);

	while ((item = stack.Pop()) != 0)
	{
		Console.WriteLine("Popped : {0}", item);
	}
	Console.WriteLine("Stack : {0}", stack.ToString());
	Console.WriteLine("Is Stack empty: {0}", stack.IsEmpty());
	Console.WriteLine("Poping from Stack : {0}", stack.Pop() != -1);
}

/*[Test]
public void SomeTest()
{
	NUnit.Framework.Assert.Pass();
}*/

// Define other methods and classes here
public class Stack<T>
{
	private T[] stack; 
	private int top; 
	private int size; 
	public Stack(int size)
	{
		this.size = size;
		this.stack = new T[this.size];
		this.top = 0;
	}
	public bool IsEmpty()
	{
		return top == 0;
	}
	public bool IsFull()
	{
		return top == size;
	}
	public T Peek()
	{
		return stack[top];
	}
	public T Pop()
	{
		if(!IsEmpty())
		{
			return stack[--top];
		}
		
		return default(T); 
	}
	public T Push(T item)
	{
		if(IsFull())
		{
			return default(T); 
		}		
		stack[top++] = item;

		return item;
	}	
	public override string ToString()
	{
		StringBuilder sb = new StringBuilder(); 
		for(int i = 0; i< stack.Length; i++)
		{
			sb.Append(stack[i]);
			if(i+1 < stack.Length)
			{
				sb.Append(',');
			}
		}
		return sb.ToString();
	}
}
