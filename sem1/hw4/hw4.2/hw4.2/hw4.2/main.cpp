#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "qSort.h"

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
	return SearchMostCommonEl(array1, size) == 2 && SearchMostCommonEl(array2, size) == 9;
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

	FILE * inputData = fopen("inputData.txt", "r");

	if (!inputData)
	{
		printf("file not found");
		return 1;
	}

	int size = 0;

	if (fscanf(inputData, "%d", &size) == EOF)
	{
		printf("File is empty");
		fclose(inputData);
		return 1;
	}

	int *array = new int[size] {};
	for (int i = 0; i < size; ++i)
	{
		if (fscanf(inputData, "%d", &array[i]) == EOF)
		{
			printf("The size of the array is bigger than array");
			fclose(inputData);
			return 1;
		}
	}

	qSort(array, 0, size - 1);
	printf("The most common element is %d", SearchMostCommonEl(array, size));
	fclose(inputData);
	delete[] array;
	return 0;
}