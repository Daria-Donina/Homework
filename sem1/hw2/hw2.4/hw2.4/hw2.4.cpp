#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>

void swap(int &firstElement, int &secondElement)
{
	const int temp = firstElement;
	firstElement = secondElement;
	secondElement = temp;
}

void arrayTransformation(int *array, int sizeOfArray)
{
	for (int i = 0; i < sizeOfArray; ++i)
	{
		array[i] = rand();
	}
	int key = array[0];
	for (int i = 0; i < sizeOfArray; ++i)
	{
		if (array[i] < key)
		{
			swap(array[i], key);
			key = array[i];
		}
	}
}

bool testArrayTransformation()
{
	const int size = 5;
	int array[size];
	int counter = 0;
	arrayTransformation(array, size);
	int key = array[0];
	for (int i = 0; i < size; ++i)
	{
		if (array[i] < key)
		{
			counter++;
		}
	}
	for (int i = 0; i < counter; ++i)
	{
		if (array[i] >= key)
		{
			return false;
		}
	}
	for (int i = counter; i < size; ++i)
	{
		if (array[i] < key)
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