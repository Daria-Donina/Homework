#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int exponentiation(int inputNumber, int inputPower)
{
	if (inputPower == 0)
	{
		return 1;
	}
	else if (inputPower % 2 == 1)
	{
		return exponentiation(inputNumber, inputPower - 1) * inputNumber;
	}
	else
	{
		int tempNumber = exponentiation(inputNumber, inputPower / 2);
		return tempNumber * tempNumber;
	}
}

bool test1()
{
	return exponentiation(1, 5) == 1 &&
		exponentiation(0, 6) == 0 && 
		exponentiation(-2, 7) == -128;
}

int main()
{
	printf("Enter the number needed to be raised\n");
	int number = 0;
	scanf("%d", &number);
	printf("Enter the power of exponentiation\n");
	int power = 0;
	scanf("%d", &power);
	int result = number;
	for (int i = 2; i <= power; ++i)
	{
		result *= number;
	}
	if (power == 0)
	{
		printf("1");
	}
	else if (power < 0)
	{
		printf("The input data is incorrect");
	}
	else
	{
		printf("(iteratively) The answer is %d\n", result);
		printf("(recursively) The answer is %d\n", exponentiation(number, power));
	}
	if (test1())
	{
		printf("Tests passed");
	}
	else
	{
		printf("Tests failed");
	}
	return 0;
}