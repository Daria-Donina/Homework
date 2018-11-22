#define _CRT_SECURE_NO_WARNINGS
#include <string.h>
#include <stdio.h>
#include "commands.h"
#include "auxiliary.h"
#include "test.h"

bool test()
{
	const int size = 3;
	FILE * test = fopen("test.txt", "w");
	Record testPhonebook[4] = { "\0", 0, "aaa", 123, "bbb", 321, '\0', 0 };
	char testName3[] = { "ccc" };
	addARecord(testPhonebook, testName3, 432, size);
	if (strcmp(testPhonebook[3].name, "ccc") != 0 || testPhonebook[3].phoneNumber != 432)
	{
		fclose(test);
		return false;
	}
	if (testPhonebook[findAPhoneNumber(testPhonebook, testPhonebook[1].name, size)].phoneNumber != 123)
	{
		fclose(test);
		return false;
	}
	if (strcmp(testPhonebook[findAName(testPhonebook, testPhonebook[2].phoneNumber, size)].name, "bbb") != 0)
	{
		fclose(test);
		return false;
	}
	saveCurrentDataToFile(test, testPhonebook, size);
	fclose(test);
	FILE * test1 = fopen("test.txt", "r");
	Record testPhonebook1[4];
	copyDataToStruct(test1, testPhonebook1, size);
	for (int i = 0; i <= size; ++i)
	{
		if (strcmp(testPhonebook[i].name, testPhonebook1[i].name) != 0
			|| testPhonebook[i].phoneNumber != testPhonebook1[i].phoneNumber)
		{
			return false;
		}
	}
	fclose(test1);
	return true;
}