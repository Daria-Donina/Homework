#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

void swap(int &firstElement, int &secondElement)
{
	const int temp = firstElement;
	firstElement = secondElement;
	secondElement = temp;
}

void bubbleSorting(int *array, int length)
{
	for (int i = length - 1; i >= 0; --i)
	{
		for (int j = i - 1; j >= 0; --j)
		{
			if (array[i] < array[j])
			{
				swap(array[i], array[j]);
			}
		}
	}
}

void countSorting(int *array, int length)
{
	int maxElement = array[0];
	int minElement = array[0];
	for (int i = 1; i < length; ++i)
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
	for (int i = 0; i < length; ++i)
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
	delete[] auxiliaryArray;
}

bool testBubble()
{
	const int length = 10;
	int array1[length] = { 9, 3, 6, 3, -1, -9, 7, 6, -10, 0 };
	bubbleSorting(array1, length);
	int array2[length] = { 7, 8, 43, 6, -80, -90, 4, 0, 2, 1 };
	bubbleSorting(array2, length);
	for (int i = 0; i < 9; ++i)
	{
		if (array1[i] > array1[i + 1] && array2[i] > array2[i + 1])
		{
			return false;
		}
	}
	return true;
}

bool testCount()
{
	const int length = 10;
	int array1[length] = { 9, 3, 6, 3, -1, -9, 7, 6, -10, 0 };
	countSorting(array1, length);
	int array2[length] = { 7, 8, 43, 6, -80, -90, 4, 0, 2, 1 };
	countSorting(array2, length);
	for (int i = 0; i < 9; ++i)
	{
		if (array1[i] > array1[i + 1] && array2[i] > array2[i + 1])
		{
			return false;
		}
	}
	return true;
}

int main()
{
	if (testBubble())
	{
		printf("Tests for bubble sorting passed\n");
	}
	else
	{
		printf("Tests for bubble sorting failed\n");
	}
	if (testCount())
	{
		printf("Tests for count sorting passed\n");
	}
	else
	{
		printf("Tests for count sorting failed\n");
	}
	return 0;
}