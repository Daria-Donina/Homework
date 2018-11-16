#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int maxSumSearch(int *array, int size)
{
	int maxSum = 0;
	for (int i = 0; i < size; ++i)
	{
		int sum = 0;
		int temp = array[i];
		while (temp != 0)
		{
			sum += temp % 10;
			temp /= 10;
		}
		if (sum > maxSum)
		{
			maxSum = sum;
		}
	}
	return maxSum;
}

int returnOfMaxEl(int *array, const int size, int counter, int maxSum)
{
	int sum = 0;
	int temp = array[counter];
	while (temp != 0)
	{
		sum += temp % 10;
		temp /= 10;
	}
	if (sum == maxSum)
	{
		return array[counter];
	}
	else
	{
		return 0;
	}
}

bool test()
{
	const int size = 10;
	int array[size] = {3, 56, 74, 32, 64, 34, 2, 9, 10, 43};
	int maxSum = maxSumSearch(array, size);
	int i = 0;
	if ((returnOfMaxEl(array, size, 1, maxSum) == 56) && (i = 2 && returnOfMaxEl(array, size, 2, maxSum) == 74))
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
	if (test())
	{
		printf("tests passed\n");
	}
	else
	{
		printf("tests failed\n");
	}
	const int size = 10;
	int array[size] = { 3, 56, 74, 32, 64, 34, 2, 9, 10, 43 };
	int maxSum = maxSumSearch(array, size);
	for (int i = 0; i < size; ++i)
	{
		if (returnOfMaxEl(array, size, i, maxSum) != 0)
		{
			printf(" %d\n", returnOfMaxEl(array, size, i, maxSum));
		}
	}
	return 0;
}