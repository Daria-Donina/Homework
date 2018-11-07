#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>

void swap(int &firstElement, int &secondElement)
{
	const int temp = firstElement;
	firstElement = secondElement;
	secondElement = temp;
}

int choosingPivot(int *array, int numOfFirstElement, int numOfLastElement)
{
	if (array[numOfFirstElement] < array[numOfLastElement] &&
		array[numOfFirstElement] > array[(numOfLastElement - numOfFirstElement) / 2] || 
		array[numOfFirstElement] > array[numOfLastElement] &&
		array[numOfFirstElement] < array[(numOfLastElement - numOfFirstElement) / 2])
	{
		return array[numOfFirstElement];
	}
	else if (array[numOfLastElement] < array[numOfFirstElement] &&
		array[numOfLastElement] > array[(numOfLastElement - numOfFirstElement) / 2] ||
		array[numOfLastElement] > array[numOfFirstElement] &&
		array[numOfLastElement] < array[(numOfLastElement - numOfFirstElement) / 2])
	{
		return array[numOfLastElement];
	}
	else
	{
		return array[(numOfLastElement - numOfFirstElement) / 2];
	}
}

void insertionSort(int *array, int numOfFirstElement, int numOfLastElement)
{
	for (int i = numOfFirstElement + 1; i <= numOfLastElement; ++i)
	{
		int key = array[i];
		int j = i - 1;
		while (key < array[j] && j >= numOfFirstElement)
		{
			array[j + 1] = array[j];
			array[j] = key;
			--j;
		}
	}
}

void qSort(int *array, int first, int last)
{
	if (last - first < 10 && last > first)
	{
		insertionSort(array, first, last);
	}
	else
	{
		int left = first;
		int right = last;
		int pivot = choosingPivot(array, left, right);
		while (left <= right)
		{
			while (array[left] < pivot)
			{
				left++;
			}
			while (array[right] > pivot)
			{
				right--;
			}
			if (left <= right)
			{
				swap(array[left], array[right]);
				right--;
				left++;
			}
		}
		if (right > first)
		{
			qSort(array, first, right);
		}
		if (last > left)
		{
			qSort(array, left, last);
		}
	}
}

bool testQSort(int *array, int size)
{
	int counter = 0;
	qSort(array, 0, size - 1);
	for (int i = 0; i < size - 1; ++i)
	{
		if (array[i + 1] < array[i])
		{
			return false;
		}
	}
	return true;
}

int main()
{
	const int size1 = 15;
	int array1[size1] = { 1, 6, 7, 8, 4, 3, 6, 5, 10, 42, 43, 13, 24, 5, 7 };
	const int size2 = 8;
	int array2[size2] = { 93, 7, 6, 5, 3, 2, 7, 93 };
	const int size3 = 12;
	int array3[size3] = { 7, 7, 6, 5, 2, 7, 7, 43, 5, 32, 15, 7 };
	if (testQSort(array1, size1) && testQSort(array2, size2) && testQSort(array3, size3))
	{
		printf("Tests passed\n");
	}
	else
	{
		printf("Tests failed\n");
	}
	return 0;
}

