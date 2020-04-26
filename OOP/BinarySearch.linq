<Query Kind="Program" />

void Main()
{
	
	int[] arr = {1,2,3,4,5,6,7,8,9,10};
	int target = 10;	
	BinarySearch(arr, target);
	
	LinearSearch(arr, target);
}

// Define other methods and classes here

public void BinarySearch(int[] arr, int target)
{		
	bool found = false;
	int low = 0;
	int high = arr.Length - 1;
	int mid, index = -1;

	do
	{
		Console.WriteLine("Iterations");
		mid = low + (high - low) / 2;
		if (target < arr[mid])
		{
			high = mid - 1;
		}
		else if (target > arr[mid])
		{
			low = mid + 1;
		}
		else if (target == arr[mid])
		{
			index = mid;
			found = true;
		}
	} while (found == false);
	Console.WriteLine("Found at index:{0}", index);
}

public void LinearSearch(int[] arr, int target)
{
	for (int i = 0; i < arr.Length; i++)
	{
		Console.WriteLine("Iteration");
		if (target == arr[i])
		{
			Console.WriteLine("Found at index:{0}", i);
			break;
		}
	}
}