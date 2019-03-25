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

int SearchMostCommonEl(int *array, int size)
{
	qSort(array, 0, size - 1);
	int counter = 1;
	int maxCounter = 0;
	int mostCommonEl = array[0];
	for (int i = 1; i < size; ++i)
	{
		if (array[i] == array[i - 1])
		{
			++counter;
			if (counter > maxCounter)
			{
				maxCounter = counter;
				mostCommonEl = array[i];
			}
		}
		else
		{
			counter = 1;
		}
	}
	return mostCommonEl;
}

bool testSearchMostCommonEl()
{
	const int size = 10;
	int array1[size] = { 2, 5, 6, 7, 2, 9, 2, 4, 9, 2 };
	int array2[size] = { 4, 4, 7, 9, 9, 9, 1, 3, 3, 5 };
	if (SearchMostCommonEl(array1, size) == 2 && SearchMostCommonEl(array2, size) == 9)
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
	if (testSearchMostCommonEl())
	{
		printf("Tests for searching the most common element of array passed\n");
	}
	else
	{
		printf("Tests for searching the most common element of array failed\n");
	}
	return 0;
}