#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int recursiveFibonacci(int n)
{
	if (n == 0)
	{
		return 0;
	}
	else if (n == 1)
	{
		return 1;
	}
	else if (n > 1)
	{
		return recursiveFibonacci(n - 1) + recursiveFibonacci(n - 2);
	}
}

int iterativeFibonacci(int n)
{
	int numberBeforeLast = 0;
	int lastNumber = 1;
	int currentNumber = 0;
	if (n == 0)
	{
		return 0;
	}
	else if (n == 1)
	{
		return 1;
	}
	else
	{
		for (int i = 2; i <= n; ++i)
		{
			currentNumber = numberBeforeLast + lastNumber;
			numberBeforeLast = lastNumber;
			lastNumber = currentNumber;
		}
		return currentNumber;
	}
}

bool testRecursiveFibonacci()
{
	return recursiveFibonacci(0) == 0 && recursiveFibonacci(1) == 1 && recursiveFibonacci(6) == 8;
}

bool testIterativeFibonacci()
{
	if (iterativeFibonacci(6) == 8 && iterativeFibonacci(0) == 0 && iterativeFibonacci(1) == 1)
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
	if (testRecursiveFibonacci())
	{
		printf("Tests for recursive Fibonnacci calculation passed\n");
	}
	else
	{
		printf("Tests for recursive Fibonnacci calculation failed\n");
	}
	if (testIterativeFibonacci())
	{
		printf("Tests for iterative Fibonacci calculation passed\n");
	}
	else
	{
		printf("Tests for iterative Fibonacci calculation failed\n");
	}
	return 0;
}