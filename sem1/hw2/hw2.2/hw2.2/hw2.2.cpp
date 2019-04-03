#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int binPow(int number, int power)
{
	if (power == 0)
	{
		return 1;
	}
	else if (power % 2 == 1)
	{
		return binPow(number, power - 1) * number;
	}
	else
	{
		int tempNumber = binPow(number, power / 2);
		return tempNumber * tempNumber;
	}
}

int linPow(int number, int power)
{
	if (power == 0)
	{
		return 1;
	}
	int result = number;
	for (int i = 2; i <= power; ++i)
	{
		result *= number;
	}
	return result;
}

bool testBinPow()
{
	return binPow(1, 5) == 1 &&
		binPow(0, 6) == 0 &&
		binPow(-2, 7) == -128;
}

bool testLinPow()
{
	return linPow(5, 0) == 1 &&
		linPow(6, 2) == 36 &&
		linPow(-3, 5) == -243;
}

int main()
{
	if (testBinPow())
	{
		printf("Tests for binary exponentation passed\n");
	}
	else
	{
		printf("Tests for binary exponentation failed\n");
	}
	if (testLinPow())
	{
		printf("Tests for linear exponentation passed\n");
	}
	else
	{
		printf("Tests for linear exponentation failed\n");
	}
	return 0;
}