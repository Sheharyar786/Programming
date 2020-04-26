<Query Kind="Program" />

void Main()
{
	int[] arr = {14,33,27,35,10};
	for(int i =0; i<arr.Length; i++)
	{
		for(int j = i; j<arr.Length; j++)
		{
			if(arr[i] > arr[j])
			{
				int temp = arr[i];
				arr[i] = arr[j];
				arr[j] = temp;
			}
		}
	}
	for (int i = 0; i < arr.Length; i++)
	{
		Console.WriteLine("arr[{0}] = {1}", i, arr[i]);
	}
}

// Define other methods and classes here
