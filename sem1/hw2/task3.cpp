#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main()
{
	printf("Enter the number of array elements\n");
	int number = 0;
	scanf("%d", &number);
	if (number > 0)
	{
		printf("Enter %d", number);
		printf(" elements of the array\n");
		int *array = new int[number] {};
		for (int i = 0; i < number; ++i)
		{
			scanf("%d", &array[i]);
		}
		int maxElement = array[0], minElement = array[0];
		for (int i = 1; i < number; ++i)
		{
			if (array[i] > maxElement)
			{
				maxElement = array[i];
			}
			if (array[i] < minElement)
			{
				minElement = array[i];
			}
		}
		int *auxiliaryArray = new int[maxElement - minElement + 1]{};
		for (int i = 0; i < number; ++i)
		{
			auxiliaryArray[array[i] - minElement]++;
			array[i] = 0;
		}
		int count = 0;
		for (int i = 0; i <= maxElement - minElement; ++i)
		{
			while (auxiliaryArray[i] != 0)
			{
				array[count] = i + minElement;
				count++;
				auxiliaryArray[i]--;
			}
		}
		printf("The sorted array is");
		for (int i = 0; i < number; ++i)
		{
			printf(" %d", array[i]);
		}
	}
	else
	{
		printf("The input data is incorrect");
	}
//	delete[] array;
//	delete[] auxiliaryArray;
	return 0;
}