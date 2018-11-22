#define _CRT_SECURE_NO_WARNINGS
#include "auxiliary.h"

int numberOfRecords(Record *phonebook, const int size)
{
	int numberOfRecords = 0;
	if (phonebook[size].name != '\0' && phonebook[size].phoneNumber != 0)
	{
		return size;
	}
	for (int i = 1; i <= size; ++i)
	{
		if (phonebook[i].name == '\0' || phonebook[i].phoneNumber == 0)
		{
			numberOfRecords = i - 1;
			break;
		}
	}
	return numberOfRecords;
}

void copyDataToStruct(FILE * phonebookFile, Record *phonebook, const int size)
{
	int i = 1;
	while (!feof(phonebookFile) && i <= size)
	{
		fscanf(phonebookFile, "%s%d", phonebook[i].name, &phonebook[i].phoneNumber);
		++i;
	}
}