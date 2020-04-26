<Query Kind="Program" />

void Main()
{
	int[] arr = {5,3,1,2,4};
	int target = 4;

	for (int i = 0; i < arr.Length; i++)
	{
		if (target == arr[i])
		{
			Console.WriteLine("Found at index:{0}",i); 
			break;
		}
	}
}

// Define other methods and classes here
