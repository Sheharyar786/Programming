<Query Kind="Program">
  <NuGetReference>NUnit</NuGetReference>
  <NuGetReference>NUnit.Runners.lite</NuGetReference>
  <NuGetReference>NUnitLite</NuGetReference>
</Query>

void Main()
{
	//SimpleLinkedListOperation();
	DoubleLinkedListOperations();
}

#region Simple LinkedList 

void SimpleLinkedListOperation()
{
	Console.WriteLine("*************************************************** SIMPLE LINKED LIST ********************************************************");
	Console.WriteLine("Linked List SectionPrint All Nodes in Acsending Order");
	Node pNode = new Node(1);
	SimpleLinkedListOperations operation = new SimpleLinkedListOperations();
	pNode = operation.AddNode(pNode, 2);
	operation.AddNode(pNode, 3);
	operation.AddNode(pNode, 4);
	operation.AddNode(pNode, 5);

	Console.Write("\nPrint All Nodes in Acsending Order: ");
	operation.PrintNodes(pNode);

	Console.Write("\nPrint All Nodes in Descending Order: ");
	operation.PrintNodes(pNode, true);

	Console.WriteLine("\nSearch 4 in LinkedList");
	var searchedNode = operation.SearchNode(pNode, 4);
	Console.WriteLine("Searched Node: {0}", searchedNode == null ? -1 : searchedNode.Data);


	Console.WriteLine("Delete 4 from LinkedList");
	var isDeleted = operation.DeleteNode(pNode, 4);
	Console.WriteLine("Item Deleted: {0}", isDeleted);
	Console.Write("\nPrint All Nodes after Delete Operation: ");
	operation.PrintNodes(pNode);
}
public class Node
{
	public Node(int data)
	{
		this.data = data;
	}

	int data;
	public Node Next { get; set; }
	public Node Last {get; set;}
	public int Data 
	{ 
		get 
		{ 
			return this.data;
		} 
		set 
		{
			this.data = value;
		} 
	}
}

public class SimpleLinkedListOperations
{
	public Node AddNode(Node node, int data, bool atEnd)
	{		
		
		if(atEnd == true)
		{
			var n = new Node(data);
			n.Next = node; 
			return n;
		}
		else
		{
			return AddNode(node, data);
		}		
	}
	
	public void PrintNodes(Node node, bool inDescendingOrder = false)
	{	
		StringBuilder sb = new StringBuilder(); 
		while (node != null)
		{
			if(inDescendingOrder)
			{
				sb.Append(node.Data); 				
			}			
			else 
			{
				Console.Write(node.Data);
			}
			node = node.Next == null?null: node.Next;			
		}
		
		for(int i = sb.Length-1;i>=0; i--)
		{
			Console.Write(sb[i].ToString());
		}
	}

	public Node AddNode(Node node, int data)
	{
		var parent = node;
		var last = node.Last;
		while (node != null)
		{
			parent = node;
			node = node.Next == null ? null : node.Next;
		}
		last = parent.Next = new Node(data);

		return parent;
	}

	public void PrintNodes(Node node)
	{
		while (node != null)
		{
			Console.Write(node.Data);
			node = node.Next == null ? null : node.Next;
		}
	}

	public bool DeleteNode(Node node, int data)
	{
		bool found = false;
		Node previousNode = null;
		while (!found)
		{
			if (node.Data == data)
			{
				found = true;
			}
			else
			{
				previousNode = node;
				node = node.Next == null ? null : node.Next;
			}
		}
		previousNode.Next = node.Next;

		return found;
	}

	public Node SearchNode(Node node, int data)
	{
		Node target = null;
		while (node != null)
		{
			if (node.Data == data)
			{
				target = node;
				break;
			}
			node = node.Next == null ? null : node.Next;
		}
		return target;
	}
}

#endregion

#region Double LinkedList
void DoubleLinkedListOperations()
{
	Console.WriteLine("*************************************************** DOUBLE LINKED LIST ********************************************************");	
	
	DoubleLinkedList dNode = new DoubleLinkedList(1);
	dNode.AddNode(2);
	dNode.AddNode(3);
	dNode.AddNode(4);
	dNode.AddNode(5);
	dNode.AddNode(6);
	
	Console.WriteLine("*************************************************** PRINTING DOUBLE LINKED LIST ********************************************************");	
	dNode.PrintNodes(); 
	
	Console.WriteLine("*************************************************** SEARCH DOUBLE LINKED LIST ********************************************************");	
	dNode.SearchNode(4);

	Console.WriteLine("*************************************************** DELETE DOUBLE LINKED LIST ********************************************************");
	dNode.DeleteNode(4);
}

public interface IAddNode<T>
{
	void AddNode(int data);
}
public interface IPrintNode<T>
{
	void PrintNodes();
}
public interface IDeleteNode<T>
{
	bool DeleteNode(int data);
}
public interface ISearchNode<T>
{
	T SearchNode(int data);
}

public class DoubleLinkedList : IAddNode<DoubleLinkedList>, IPrintNode<DoubleLinkedList>, IDeleteNode<DoubleLinkedList>, ISearchNode<DoubleLinkedList>
{
	public DoubleLinkedList(int data)
	{
		this.Data = data;
	}		
	public DoubleLinkedList Previous { get; set; }
	public DoubleLinkedList Next { get; set; }
	public int Data { get; set; }	

	public void AddNode(int data)
	{
		var node = this; 
		DoubleLinkedList previous = null; 
		while(node != null) 
		{
			previous = node; 
			node = node.Next == null ? null : node.Next;			
		}
		node = new DoubleLinkedList(data); 
		node.Previous = previous; 
	}

	public bool DeleteNode(int data)
	{
		bool found = false;
		DoubleLinkedList previousNode = null;
		DoubleLinkedList node = this; 
		while (!found)
		{
			if (node.Data == data)
			{
				found = true;
			}
			else
			{
				previousNode = node;
				node = node.Next == null ? null : node.Next;
			}
		}
		previousNode.Next = node.Next;

		return found;
	}

	public void PrintNodes()
	{
		var node = this; 
		while (node != null)
		{
			Console.Write(node.Data);
			node = node.Next == null ? null : node.Next;
		}
	}

	public DoubleLinkedList SearchNode(int data)
	{
		DoubleLinkedList node = this;
		DoubleLinkedList target = null;
		while (node != null)
		{
			if (node.Data == data)
			{
				target = node;
				break;
			}
			node = node.Next == null ? null : node.Next;
		}
		return target;
	}
}

#endregion