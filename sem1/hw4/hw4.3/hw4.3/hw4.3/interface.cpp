#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include "commands.h"
#include "interface.h"

struct Record
{
	char name[100]{};
	int phoneNumber = 0;
};

//Проверяет, есть ли вводимое имя в справочнике
bool isName(Record *phonebook, char *name, const int size)
{
	for (int i = 1; i <= numberOfRecords(phonebook, size); ++i)
	{
		if (strcmp(name, phonebook[i].name) == 0)
		{
			return true;
		}
	}
	return false;
}

//Проверяет, есть ли вводимый номер в справочнике
bool isPhoneNumber(Record *phonebook, int phoneNumber, const int size)
{
	for (int i = 1; i <= numberOfRecords(phonebook, size); ++i)
	{
		if (phoneNumber == phonebook[i].phoneNumber)
		{
			return true;
		}
	}
	return false;
}

void userInterface(int number, Record *phonebook)
{
	const int size = 100;
	Record record = { "/0" , 0 };
	while (number != 0)
	{
		printf("Input number:\n");
		printf("0 - exit\n");
		printf("1 - add a record\n");
		printf("2 - print all records\n");
		printf("3 - find a phone number by name\n");
		printf("4 - find a name by phone number\n");
		printf("5 - save current data to file\n");
		scanf("%d", &number);
		switch (number)
		{
		case 1:
			printf("Enter name\n");
			scanf("%s", record.name);
			printf("Enter phone number\n");
			scanf("%d", &record.phoneNumber);
			if (!isName(phonebook, record.name, size) && !isPhoneNumber(phonebook, record.phoneNumber, size))
			{
				addARecord(phonebook, record.name, record.phoneNumber, size);
				printf("Record has been added!\n\n");
			}
			else if (isName(phonebook, record.name, size))
			{
				printf("The name is already in a phonebook\n\n");
			}
			else if (isPhoneNumber(phonebook, record.phoneNumber, size))
			{
				printf("The phone number is already in a phonebook\n\n");
			}
			break;
		case 2:
			if (numberOfRecords(phonebook, size) != 0)
			{
				printf("Records:\n");
				for (int i = 1; i <= numberOfRecords(phonebook, size); ++i)
				{
					printf("%s %d\n", phonebook[i].name, phonebook[i].phoneNumber);
				}
				printf("\n");
			}
			else
			{
				printf("There are no records in a phonebook\n\n");
			}
			break;
		case 3:
			printf("Enter name\n");
			scanf("%s", record.name);
			if (findAPhoneNumber(phonebook, record.name, size) != -1)
			{
				printf("The number of %s is %d\n\n", record.name, phonebook[findAPhoneNumber(phonebook, record.name, size)].phoneNumber);
			}
			else
			{
				printf("Input name is not in a phonebook\n\n");
			}
			break;
		case 4:
			printf("Enter phone number\n");
			scanf("%d", &record.phoneNumber);
			if (findAName(phonebook, record.phoneNumber, size) != -1)
			{
				printf("Phone number %d belongs to %s\n\n", record.phoneNumber, phonebook[findAName(phonebook, record.phoneNumber, size)].name);
			}
			else
			{
				printf("Input phone number is not in a phonebook\n\n");
			}
			break;
		case 5:
			FILE * phonebookNew = fopen("phonebook.txt", "w");
			saveCurrentDataToFile(phonebookNew, phonebook, size);
			fclose(phonebookNew);
			printf("Input data has been saved!\n\n");
			break;
		}
	}
}