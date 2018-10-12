#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

void shift(int k, bool array[], int lengthOfArray, int &j)
{
	for (k = 0; k < lengthOfArray; ++k)
	{
		array[k] = array[k + j];
	}
}

bool test(int &lengthOf1Number, int &lengthOf2Number, bool secondNumber[], bool firstNumber[])
{
	return lengthOf1Number > 0
		&& lengthOf2Number > 0
		&& (secondNumber[0] == 1 || secondNumber[0] == 0)
		&& (firstNumber[0] == 1 || firstNumber[0] == 0);
}

int main()
{
	bool firstNumber[100]{};
	int lengthOf1Number = 0;
	printf("Enter the length of the first binary number\n");
	scanf("%d", &lengthOf1Number);
	printf("Enter the first binary number\n");
	for (int i = 0; i < lengthOf1Number; ++i)
	{
		scanf("%d", &firstNumber[i]);
	}
	int j = 0;
	while (firstNumber[j] == 0)
	{
		j++;
	}
	if (j != 0)
	{
		int i = 0;
		shift(i, firstNumber, lengthOf1Number, j);
	}
	lengthOf1Number = lengthOf1Number - j;
	bool secondNumber[100]{};
	int lengthOf2Number = 0;
	printf("Enter the length of the second binary number\n");
	scanf("%d", &lengthOf2Number);
	printf("Enter the second binary number\n");
	for (int i = 0; i < lengthOf2Number; ++i)
	{
		scanf("%d", &secondNumber[i]);
	}
	j = 0;
	while (secondNumber[j] == 0)
	{
		j++;
	}
	if (j != 0)
	{
		int i = 0;
		shift(i, secondNumber, lengthOf2Number, j);
	}
	lengthOf2Number = lengthOf2Number - j;
	if (lengthOf2Number > lengthOf1Number)
	{
		printf("The second number is bigger\n");
	}
	else if (lengthOf2Number < lengthOf1Number)
	{
		printf("The first number is bigger\n");
	}
	else
	{
		int i = 0;
		for (i = 0; i < lengthOf1Number; ++i)
		{
			if (firstNumber[i] != secondNumber[i])
			{
				break;
			}
		}
		if (firstNumber[i] > secondNumber[i])
		{
			printf("The first number is bigger\n");
		}
		else if (firstNumber[i] < secondNumber[i])
		{
			printf("The second number is bigger\n");
		}
		else
		{
			printf("The numbers are equal\n");
		}
	}
	if (test(lengthOf1Number, lengthOf2Number, secondNumber, firstNumber))
	{
		printf("tests passed\n");
	}
	else
	{
		printf("tests failed\n");
	}
	return 0;
}