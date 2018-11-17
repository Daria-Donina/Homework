#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <locale.h>

bool* decimalToBinary(int decimalNumber, bool *binaryNumber)
{
	binaryNumber[0] = (decimalNumber < 0);
	unsigned int bit = 0b01000000000000000000000000000000;
	for (int i = 1; i < 32; ++i)
	{
		binaryNumber[i] = (decimalNumber & bit);
		bit = bit >> 1;
	}
	return binaryNumber;
}

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

bool* sumOfNumbers(bool *firstBinaryNumber, bool *secondBinaryNumber, bool *result)
{
	int temp = 0;
	for (int i = 31; i >= 0; --i)
	{
		if (firstBinaryNumber[i] && secondBinaryNumber[i])
		{
			!result[i] + temp;
			temp = 1;
		}
		else
		{
			result[i] = firstBinaryNumber[i] + secondBinaryNumber[i] + temp;
			temp = 0;
		}
	}
	return result;
}

int main()
{
	//tests
	setlocale(LC_ALL, "Russian");

	int firstNumber = 0;
	printf("¬ведите первое число: ");
	scanf("%d", &firstNumber);

	int secondNumber = 0;
	printf("¬ведите второе число: ");
	scanf("%d", &secondNumber);

	bool firstBinaryNumber[32]{};
	bool secondBinaryNumber[32]{};

	*firstBinaryNumber = *decimalToBinary(firstNumber, firstBinaryNumber);
	*secondBinaryNumber = *decimalToBinary(secondNumber, secondBinaryNumber);

	printf("ѕервое число в двоичном представлении в дополнительном коде: ");
	printNumber(firstNumber, firstBinaryNumber);
	printf("¬торое число в двоичном представлении в дополнительном коде: ");
	printNumber(secondNumber, secondBinaryNumber);

	bool resultOfSum[32]{};
	*resultOfSum = *sumOfNumbers(firstBinaryNumber, secondBinaryNumber, resultOfSum);
	printf("—умма чисел в двочином представлении: ");
	for (int i = 0; i < 32; ++i)
	{
		printf("%d", resultOfSum[i]);
	}


	return 0;
}