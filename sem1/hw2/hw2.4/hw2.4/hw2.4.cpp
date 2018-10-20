#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>

void swap(int &firstElement, int &secondElement)
{
	const int temp = firstElement;
	firstElement = secondElement;
	secondElement = temp;
}

void arrayInitialization(int *array, int sizeOfArray)
{
	for (int i = 0; i < sizeOfArray; ++i)
	{
		array[i] = rand();
	}
}

void arrayTransformation(int *array, int left, int right)
{
	int pivot = array[0];
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

bool testArrayTransformation()
{
	const int size = 5;
	int array[size];
	int counter = 0;
	arrayInitialization(array, 5);
	int pivot = array[0];
	arrayTransformation(array, 0, 4);
	for (int i = 0; i < size; ++i)
	{
		if (array[i] < pivot)
		{
			counter++;
		}
	}
	for (int i = 0; i < counter; ++i)
	{
		if (array[i] >= pivot)
		{
			return false;
		}
	}
	for (int i = counter; i < size; ++i)
	{
		if (array[i] < pivot)
		{
			return false;
		}
	}
	return true;
}

int main()
{
	if (testArrayTransformation())
	{
		printf("Tests for array transformation passed\n");
	}
	else
	{
		printf("Tests for array transformation failed\n");
	}
	return 0;
}