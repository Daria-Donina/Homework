#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <locale.h>
#include "mathOperations.h"
#include "test.h"

int lengthOfBinNumber(int number)
{
	int powerTwo = 1;
	int i = 0;
	while (number >= powerTwo)
	{
		++i;
		powerTwo *= 2;
	}
	return i;
}

void printNumber(int number, bool *array)
{
	if (number > 0)
	{
		for (int i = 32 - lengthOfBinNumber(number); i < 32; ++i)
		{
			printf("%d", array[i]);
		}
	}
	else
	{
		for (int i = 0; i < 32; ++i)
		{
			printf("%d", array[i]);
		}
	}
	printf("\n");
}

int main()
{
	//tests
	if (test())
	{
		printf("Tests passed\n");
	}
	else
	{
		printf("Tests failed\n");
	}
	setlocale(LC_ALL, "Russian");

	int firstNumber = 0;
	printf("������� ������ �����: ");
	scanf("%d", &firstNumber);

	int secondNumber = 0;
	printf("������� ������ �����: ");
	scanf("%d", &secondNumber);

	bool firstBinaryNumber[32]{};
	bool secondBinaryNumber[32]{};

	*firstBinaryNumber = *decimalToBinary(firstNumber, firstBinaryNumber);
	*secondBinaryNumber = *decimalToBinary(secondNumber, secondBinaryNumber);

	printf("������ ����� � �������� ������������� � �������������� ����: ");
	printNumber(firstNumber, firstBinaryNumber);
	printf("������ ����� � �������� ������������� � �������������� ����: ");
	printNumber(secondNumber, secondBinaryNumber);

	bool sum[32]{};
	*sum = *sumOfNumbers(firstBinaryNumber, secondBinaryNumber, sum);
	printf("����� ����� � �������� �������������: ");
	for (int i = 0; i < 32; ++i)
	{
		printf("%d", sum[i]);
	}

	bool invSum[32]{};
	if (sum[0])
	{
		*invSum = *inversionOfTwosComplement(sum, invSum);
		printf("\n����� ����� � ���������� �������������: %d", binaryToDecimal(invSum));
	}
	else
	{
		printf("\n����� ����� � ���������� �������������: %d", binaryToDecimal(sum));
	}
	return 0;
}