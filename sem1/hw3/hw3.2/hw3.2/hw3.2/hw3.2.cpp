#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <ctime>

void swap(int &firstElement, int &secondElement)
{
	const int temp = firstElement;
	firstElement = secondElement;
	secondElement = temp;
}

int choosingPivot(int *array, int first, int last)
{
	if (array[first] <= array[last] &&
		array[first] >= array[(last - first) / 2] ||
		array[first] >= array[last] &&
		array[first] <= array[(last - first) / 2])
	{
		return array[first];
	}
	else if (array[last] <= array[first] &&
		array[last] >= array[(last - first) / 2] ||
		array[last] >= array[first] &&
		array[last] <= array[(last - first) / 2])
	{
		return array[last];
	}
	else
	{
		return array[(last - first) / 2];
	}
}

void qSort(int *array, int first, int last)
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

bool binSearch(int *array, int key, int numOfFirstEl, int numOfLastEl)
{
	int numOfMidEl = (numOfFirstEl + numOfLastEl) / 2;
	if (numOfFirstEl <= numOfLastEl) {
		if (key == array[numOfMidEl])
		{
			return true;
		}
		else if (key < array[numOfMidEl])
		{
			return binSearch(array, key, numOfFirstEl, numOfMidEl - 1);
		}
		else if (key > array[numOfMidEl])
		{
			return binSearch(array, key, numOfMidEl + 1, numOfLastEl);
		}
	}
	return false;
}

bool testBinSearch()
{
	const int size = 8;
	int array1[size] = { 2, 3, 6, 5, 9, 2, 10, 3 };
	int array2[size] = { 2, 3, 6, 5, 9, 2, 8, 3 };
	const int key = 10;
	qSort(array1, 0, size - 1);
	qSort(array2, 0, size - 1);
	if (binSearch(array1, key, 0, size - 1) && binSearch(array2, key, 0, size - 1) == false)
	{
		return true;
	}
	else
	{
		return false;
	}
}

int main()
{
	if (testBinSearch())
	{
		printf("Tests for binary search passed\n");
	}
	else
	{
		printf("Tests for binary search failed\n");
	}
	printf("Enter the number less or equal 5000 and larger or equal 1\n");
	int n = 0;
	scanf("%d", &n);
	int *array = new int[n] {};
	srand(time(0));
	for (int i = 0; i < n; ++i)
	{
		array[i] = rand() % 1000000001;
	}
	qSort(array, 0, n - 1);
	printf("Enter the number less or equal 300000 and larger or equal 1\n");
	int k = 0;
	scanf("%d", &k);
	for (int i = 0; i < k; ++i)
	{
		int key = rand() % 1000000001;
		binSearch(array, key, 0, n - 1);
	}
	delete[] array;
	return 0;
}