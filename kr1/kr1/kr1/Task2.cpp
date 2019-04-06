#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

bool test(int testArray[], int i, int size)
{
	for (i = 0; i < size - 1; ++i)
	{
		return testArray[i + 1] >= testArray[i];
	}
}

int main()
{
	const int sizeOfArray = 10;
	int array[sizeOfArray];
	printf("Enter array size of 10\n");
	for (int i = 0; i < sizeOfArray; ++i)
	{
		scanf("%d", &array[i]);
	}
	for (int i = 0; i < sizeOfArray - 1; ++i)
	{
		int min = i;
		for (int j = i + 1; j < sizeOfArray; ++j)
		{
			if (array[min] > array[j])
			{
			min = j;
			}
		}
		int temp = array[i];
		array[i] = array[min];
		array[min] = temp;
	}
	for (int i = 0; i < sizeOfArray; ++i)
	{
		printf("%d ", array[i]);
	}
	printf("\n");
	int i = 0;
	if (test(array, i, sizeOfArray))
	{
		printf("tests passed\n");
	}
	else
	{
		printf("tests failed\n");
	}
	return 0;
}