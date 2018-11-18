#include <stdio.h>
#include "mathOperations.h"

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

bool* inversionOfTwosComplement(bool *array, bool *result)
{
	for (int i = 1; i < 32; ++i)
	{
		array[i] = !array[i];
	}
	bool binaryNumber[32]{};
	*binaryNumber = *decimalToBinary(1, binaryNumber);
	*result = *sumOfNumbers(array, binaryNumber, result);
	return result;
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
		return -decimalSum;
	}
	else
	{
		return decimalSum;
	}
}

