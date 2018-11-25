#include <stdio.h>
#include "mathOperations.h"

bool* decimalToBinary(int decimalNumber, bool *binaryNumber, const int length)
{
	binaryNumber[0] = (decimalNumber < 0);
	unsigned int bit = 0b01000000000000000000000000000000;
	for (int i = 1; i < length; ++i)
	{
		binaryNumber[i] = (decimalNumber & bit);
		bit = bit >> 1;
	}
	return binaryNumber;
}

bool* sumOfNumbers(bool *firstBinaryNumber, bool *secondBinaryNumber, bool *result, const int length)
{
	int temp = 0;
	for (int i = length - 1; i >= 0; --i)
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

int binaryToDecimal(bool *sum, const int length)
{
	int decimalSum = 0;
	int powerTwo = 1;
	for (int i = length - 1; i >= 0; --i)
	{
		decimalSum += sum[i] * powerTwo;
		powerTwo *= 2;
	}
	return decimalSum;
}

