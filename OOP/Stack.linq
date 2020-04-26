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
	//MyStackTest();
	//Console.WriteLine("Input InFix = a + b, and Output Prefix = {0}",Prefix("a+b")); 
	Console.WriteLine("Input InFix = a + b, and Output Prefix = {0}",Prefix("(a+b)*c")); 
}
public string Prefix(string expr)
{	
	StringBuilder pre = new StringBuilder(); 
	var stack = new MyStack<char>(expr.Length); 
	foreach(var c in expr)
	{
		//if start bracket or if operand push to stack 
		if(IsStartBracket(c) && !IsOperator(c)) 
		{
			stack.Push(c); 
		}
		
		//if operator push everything in pre to stack and then add operator
		else if(pre.Length > 0) 
		{
			for(int i=pre.Length -1; i>=0; i--)
			{
				stack.Push(pre[i]);
			}
			pre.Clear();
			pre.Append(c);
		}				
		//if closing bracket pop everything and append pre 
		else if(IsCloseBracket(c))
		{
			while(!stack.IsEmpty())
			{
				pre.Append(stack.Pop()); 
			}			
		}
		else 
		{
			pre.Append(c);
		}
	}
	while(!stack.IsEmpty())
	{
		pre.Append(stack.Pop());
	}
	return pre.ToString();
}
public bool IsOperator(char c)
{
	bool yes = false;
	switch (c)
	{
		case '+': case '-': case '*': case '/': 
		yes = true; 
		break;		
	}
	return yes;
}
public bool IsStartBracket(char c)
{
	return c == '(';
}
public bool IsCloseBracket(char c)
{
	return c == ')';
}

public void MyStackTest()
{
	var stack = new MyStack<int>(5);
	Console.WriteLine("Is MyStack Empty: {0}", stack.IsEmpty());

	int item = 1;
	while (stack.Push(item) == item)
	{
		Console.WriteLine("Pushed : {0}", item);
		item++;
	}

	Console.WriteLine("MyStack : {0}", stack.ToString());
	Console.WriteLine("Is MyStack Full: {0}", stack.IsFull());
	Console.WriteLine("Pushing to MyStack : {0}", stack.Push(item) == item);

	while ((item = stack.Pop()) != 0)
	{
		Console.WriteLine("Popped : {0}", item);
	}
	Console.WriteLine("MyStack : {0}", stack.ToString());
	Console.WriteLine("Is MyStack empty: {0}", stack.IsEmpty());
	Console.WriteLine("Poping from MyStack : {0}", stack.Pop() != -1);
}

/*[Test]
public void SomeTest()
{
	NUnit.Framework.Assert.Pass();
}*/

// Define other methods and classes here
public class MyStack<T>
{
	private T[] stack; 
	private int top; 
	private int size; 
	public MyStack(int size)
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