#pragma once

//Converts decimal number to binary
bool* decimalToBinary(int decimalNumber, bool *binaryNumber, const int length);

//Converts positive binary number to decimal
int binaryToDecimal(bool *sum, const int length);

//Adds two binary numbers
bool* sumOfNumbers(bool *firstBinaryNumber, bool *secondBinaryNumber, bool *result, const int length);
