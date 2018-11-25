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

void printNumber(int number, bool *array, const int length)
{
	if (number > 0)
	{
		for (int i = length - lengthOfBinNumber(number); i < length; ++i)
		{
			printf("%d", array[i]);
		}
	}
	else
	{
		for (int i = 0; i < length; ++i)
		{
			printf("%d", array[i]);
		}
	}
	printf("\n");
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
	setlocale(LC_ALL, "Russian");

	const int length = 32;

	int firstNumber = 0;
	printf("Введите первое число: ");
	scanf("%d", &firstNumber);

	int secondNumber = 0;
	printf("Введите второе число: ");
	scanf("%d", &secondNumber);

	bool firstBinaryNumber[length]{};
	bool secondBinaryNumber[length]{};

	decimalToBinary(firstNumber, firstBinaryNumber, length);
	decimalToBinary(secondNumber, secondBinaryNumber, length);

	printf("Первое число в двоичном представлении в дополнительном коде: ");
	printNumber(firstNumber, firstBinaryNumber, length);
	printf("Второе число в двоичном представлении в дополнительном коде: ");
	printNumber(secondNumber, secondBinaryNumber, length);

	bool sum[length]{};
	sumOfNumbers(firstBinaryNumber, secondBinaryNumber, sum, length);
	printf("Сумма чисел в двоичном представлении: ");
	for (int i = 0; i < length; ++i)
	{
		printf("%d", sum[i]);
	}
	printf("\nСумма чисел в десятичном представлении: %d", binaryToDecimal(sum, length));
	return 0;
}