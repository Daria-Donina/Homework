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
		while (key < array[j] && j >= 0)
		{
			swap(key, array[j]);
			array[j + 1] = key;
			key = array[j];
			--j;
		}
	}
}

void arrayTransformation(int *array, int left, int right)
{
	int pivot = choosingPivot(array, left, right);
	while (left < right)
	{
		while (array[left] < pivot && left < right)
		{
			left++;
		}
		while (array[right] >= pivot && left < right)
		{
			right--;
		}
		if (left != right)
		{
			swap(array[left], array[right]);
		}
	}
}

void qSort(int *array, int numOfFirstElement, int numOfLastElement)
{
	int pivot = choosingPivot(array, numOfFirstElement, numOfLastElement);
	arrayTransformation(array, numOfFirstElement, numOfLastElement);
	int i = numOfFirstElement;
	int counter = 0;
	while (array[i] < pivot)
	{
		++counter;
		++i;
	}
	if (counter >= 10)
	{
		qSort(array, numOfFirstElement, numOfFirstElement + counter - 1);
	}
	else
	{
		insertionSort(array, numOfFirstElement, numOfFirstElement + counter - 1);
	}
	if (numOfLastElement - numOfFirstElement - counter + 1 >= 10)
	{
		qSort(array, numOfFirstElement + counter, numOfLastElement);
	}
	else
	{
		insertionSort(array, numOfFirstElement + counter, numOfLastElement);
	}
}

bool testQSort1()
{
	const int size = 15;
	int array[size] = { 1, 6, 7, 8, 4, 3, 6, 5, 10, 42, 43, 13, 24, 5, 7 };
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

bool testQSort2()
{
	const int size = 8;
	int array[size] = { 93, 7, 6, 5, 3, 2, 7, 93 };
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

bool testQSort3()
{
	const int size = 12;
	int array[size] = { 7, 7, 6, 5, 2, 7, 7, 43, 5, 32, 15, 7 };
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

bool testQSort4()
{
	const int size = 20;
	int array[size] = { 2, 9000, 20, 5, 2, 10, 9, 43, 5, 3, 53, 45, 9, 24, 35, 67, 19, 23, 24534, 4 };
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

bool testQSort5()
{
	const int size = 5;
	int array[size] = { 3, 5, 6, 5, 1 };
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
	if (testQSort1())
	{
		printf("Test 1 passed\n");
	}
	else
	{
		printf("Test 1 failed\n");
	}
	if (testQSort2())
	{
		printf("Test 2 passed\n");
	}
	else
	{
		printf("Test 2 failed\n");
	}
	if (testQSort3())
	{
		printf("Test 3 passed\n");
	}
	else
	{
		printf("Test 3 failed\n");
	}
	if (testQSort4())
	{
		printf("Test 4 passed\n");
	}
	else
	{
		printf("Test 4 failed\n");
	}
	if (testQSort5())
	{
		printf("Test 5 passed\n");
	}
	else
	{
		printf("Test 5 failed\n");
	}
	return 0;
}

