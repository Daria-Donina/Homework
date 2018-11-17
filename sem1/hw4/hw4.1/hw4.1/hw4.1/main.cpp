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

int binaryToDecimal(bool *sum)
{
	int decimalSum = 0;
	int powerTwo = 1;
	for (int i = 31; i >= 1; --i)
	{
		decimalSum += sum[i] * powerTwo;
		powerTwo *= 2;
	}
	if (sum[0])
	{
		decimalSum = -decimalSum;
		return decimalSum;
	}
	else
	{
		return decimalSum;
	}
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
			result[i] = temp;
			temp = 1;
		}
		else
		{
			result[i] = (firstBinaryNumber[i] + secondBinaryNumber[i] + temp) % 2;
			if ((firstBinaryNumber[i] + secondBinaryNumber[i] + temp) / 2 == 1)
			{
				temp = 1;
			}
			else
			{
				temp = 0;
			}
		}
	}
	return result;
}

bool* inversionOfAdditionalCode(bool *array)
{
	int number = -1;
	bool binaryNumber[32]{};
	*binaryNumber = *decimalToBinary(-1, binaryNumber);
	*array = *sumOfNumbers(array, binaryNumber, array);
	for (int i = 1; i < 32; ++i)
	{
		array[i] = !array[i];
	}
	return array;
}

int main()
{
	//tests
	setlocale(LC_ALL, "Russian");

	int firstNumber = 0;
	printf("Введите первое число: ");
	scanf("%d", &firstNumber);

	int secondNumber = 0;
	printf("Введите второе число: ");
	scanf("%d", &secondNumber);

	bool firstBinaryNumber[32]{};
	bool secondBinaryNumber[32]{};

	*firstBinaryNumber = *decimalToBinary(firstNumber, firstBinaryNumber);
	*secondBinaryNumber = *decimalToBinary(secondNumber, secondBinaryNumber);

	printf("Первое число в двоичном представлении в дополнительном коде: ");
	printNumber(firstNumber, firstBinaryNumber);
	printf("Второе число в двоичном представлении в дополнительном коде: ");
	printNumber(secondNumber, secondBinaryNumber);

	bool sum[32]{};
	*sum = *sumOfNumbers(firstBinaryNumber, secondBinaryNumber, sum);
	printf("Сумма чисел в двоичном представлении: ");
	for (int i = 0; i < 32; ++i)
	{
		printf("%d", sum[i]);
	}

	if (sum[0])
	{
		*sum = *inversionOfAdditionalCode(sum);
	}
	printf("\nСумма чисел в десятичном представлении: %d", binaryToDecimal(sum));
	return 0;
}