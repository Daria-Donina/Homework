#include "mathOperations.h"
#include "test.h"

struct Pair
{
	int firstNumber = 0;
	int secondNumber = 0;
	bool firstBinary[32]{};
	bool secondBinary[32]{};
};
//-16, 6
bool test()
{
	Pair pair[3]{};
	pair[0].firstNumber = 5;
	pair[0].secondNumber = 7;
	*pair[0].firstBinary = *decimalToBinary(pair[0].firstNumber, pair[0].firstBinary);
	*pair[0].secondBinary = *decimalToBinary(pair[0].secondNumber, pair[0].secondBinary);
	bool firstBinary[32]{};
	firstBinary[29] = true;
	firstBinary[31] = true;
	bool secondBinary[32]{};
	secondBinary[29] = true;
	secondBinary[30] = true;
	secondBinary[31] = true;
	for (int i = 0; i < 32; ++i)
	{
		if (pair[0].firstBinary[i] != firstBinary[i]
			|| pair[0].secondBinary[i] != secondBinary[i])
		{
			return false;
		}
	}

	pair[1].firstNumber = -7;
	pair[1].secondNumber = 2;
	*pair[1].firstBinary = *decimalToBinary(pair[1].firstNumber, pair[1].firstBinary);
	*pair[1].secondBinary = *decimalToBinary(pair[1].secondNumber, pair[1].secondBinary);

	bool sum[32]{};
	*sum = *sumOfNumbers(pair[1].firstBinary, pair[1].secondBinary, sum);
	for (int i = 0; i < 32; ++i)
	{
		if (i != 29 && !sum[i] || i == 29 && sum[i])
		{
			return false;
		}
	}
	
	pair[2].firstNumber = -16;
	pair[2].secondNumber = 6;
	*pair[2].firstBinary = *decimalToBinary(pair[2].firstNumber, pair[2].firstBinary);
	*pair[2].secondBinary = *decimalToBinary(pair[2].secondNumber, pair[2].secondBinary);

	bool invFirstBinary[32]{};
	*invFirstBinary = *inversionOfTwosComplement(pair[2].firstBinary, invFirstBinary);
	for (int i = 1; i < 32; ++i)
	{
		if (i != 27 && invFirstBinary[i] || i == 27 && !invFirstBinary[i])
		{
			return false;
		}
	}

	int secondDecimal = 0;
	secondDecimal = binaryToDecimal(pair[2].secondBinary);
	if (secondDecimal != pair[2].secondNumber)
	{
		return false;
	}
	return true;
}
