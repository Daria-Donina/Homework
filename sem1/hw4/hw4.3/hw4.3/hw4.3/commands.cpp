#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include "auxiliary.h"
#include "interface.h"
#include "commands.h"

void addARecord(Record *phonebook, char *name, int phoneNumber, const int size)
{
	int numberOfRecord = numberOfRecords(phonebook, size) + 1;
	strcpy(phonebook[numberOfRecord].name, name);
	phonebook[numberOfRecord].phoneNumber = phoneNumber;

}

int findAPhoneNumber(Record *phonebook, char *name, const int size)
{
	for (int i = 1; i <= numberOfRecords(phonebook, size); ++i)
	{
		if (strcmp(name, phonebook[i].name) == 0)
		{
			return i;
		}
	}
	return -1;
}

int findAName(Record *phonebook, int phoneNumber, const int size)
{
	for (int i = 1; i <= numberOfRecords(phonebook, size); ++i)
	{
		if (phoneNumber == phonebook[i].phoneNumber)
		{
			return i;
		}
	}
	return -1;
}

void saveCurrentDataToFile(FILE * phonebookFile, Record *phonebook, const int size)
{
	for (int i = 1; i <= numberOfRecords(phonebook, size); ++i)
	{
		fprintf(phonebookFile, "%s %d\n", phonebook[i].name, phonebook[i].phoneNumber);
	}
}