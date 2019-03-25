#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <iostream>

int fibonacci(int n)
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
		return fibonacci(n - 1) + fibonacci(n - 2);
	}
}

bool test()
{
	return fibonacci(0) == 0 && fibonacci(1) == 1 && fibonacci(6) == 8;
}


int main()
{
	if (test())
	{
		printf("Tests passed\n");
	}
	else
	{
		printf("Tests failed\n");
	}
	int sequenceNumber = 0;
	printf("Enter the sequence number of Fibonacci number\n");
	scanf("%d", &sequenceNumber);
	int numberBeforeLast = 0;
	int lastNumber = 1;
	int currentNumber = 0;
	for (int i = 2; i <= sequenceNumber; ++i)
	{
		currentNumber = numberBeforeLast + lastNumber;
		numberBeforeLast = lastNumber;
		lastNumber = currentNumber;
	}
	if (sequenceNumber >= 0)
	{
		printf("(recursively) The Fibonacci number is ");
		printf("%d\n", fibonacci(sequenceNumber));
		printf("(iteratively) The Fibonacci number is ");
		printf("%d\n", currentNumber);
	}
	else
	{
		printf("The input data is incorrect\n");
	}
	system("pause");
	return 0;
}