#include "mathOperations.h"
#include "test.h"

struct Pair
{
	int firstNumber = 0;
	int secondNumber = 0;
	bool firstBinary[32]{};
	bool secondBinary[32]{};
};

bool test()
{
	const int length = 32;
	Pair pair[3]{};
	pair[0].firstNumber = 5;
	pair[0].secondNumber = 7;
	decimalToBinary(pair[0].firstNumber, pair[0].firstBinary, length);
	decimalToBinary(pair[0].secondNumber, pair[0].secondBinary, length);
	bool firstBinary[length]{};
	firstBinary[length - 3] = true;
	firstBinary[length - 1] = true;
	bool secondBinary[length]{};
	secondBinary[length - 3] = true;
	secondBinary[length - 2] = true;
	secondBinary[length - 1] = true;
	for (int i = 0; i < length; ++i)
	{
		if (pair[0].firstBinary[i] != firstBinary[i]
			|| pair[0].secondBinary[i] != secondBinary[i])
		{
			return false;
		}
	}

	pair[1].firstNumber = -7;
	pair[1].secondNumber = 2;
	decimalToBinary(pair[1].firstNumber, pair[1].firstBinary, length);
	decimalToBinary(pair[1].secondNumber, pair[1].secondBinary, length);

	bool sum[length]{};
	sumOfNumbers(pair[1].firstBinary, pair[1].secondBinary, sum, length);
	for (int i = 0; i < length; ++i)
	{
		if (i != length - 3 && !sum[i] || i == length - 3 && sum[i])
		{
			return false;
		}
	}
	
	pair[2].firstNumber = -16;
	pair[2].secondNumber = 6;
	decimalToBinary(pair[2].firstNumber, pair[2].firstBinary, length);
	decimalToBinary(pair[2].secondNumber, pair[2].secondBinary, length);

	int secondDecimal = 0;
	secondDecimal = binaryToDecimal(pair[2].secondBinary, length);
	if (secondDecimal != pair[2].secondNumber)
	{
		return false;
	}
	return true;
}
