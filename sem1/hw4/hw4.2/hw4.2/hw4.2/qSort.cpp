#include "qSort.h"

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