<Query Kind="Program" />

void Main()
{
	Node root = new Node(27); 
	NodeOperations operation = new NodeOperations(); 
	operation.Insert(root, 14); 
}

// Define other methods and classes here
public class Node 
{
	public int data; 
	public Node LeftChild; 
	public Node RightChild; 
	
	public Node(int data)
	{
		this.data = data;
	}	
}

public class NodeOperations
{
	public void Insert(Node node, int item)
	{
		while (node != null)
		{
			if (node.data > item)
			{
				if (IsLeftEmpty(node))
				{
					node = node.LeftChild;
					break;
				}
				node = node.LeftChild; 
			}
			else if (node.data < item)
			{
				if (IsRightEmplty(node))
				{
					node = node.RightChild;
					break;
				}
				node = node.RightChild; 
			}
		}
		node = new Node(item); 
	}

	public bool IsLeftEmpty(Node node)
	{
		return node.LeftChild == null;
	}

	public bool IsRightEmplty(Node node)
	{
		return node.RightChild == null;
	}
}