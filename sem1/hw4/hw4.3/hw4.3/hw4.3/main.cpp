#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include "auxiliary.h"
#include "test.h"
#include "interface.h"

struct Record
{
	char name[100]{};
	int phoneNumber = 0;
};

int main()
{
	if (test())
	{
		printf("Tests passed\n\n");
	}
	else
	{
		printf("Tests failed\n\n");
	}

	const int size = 100;

	FILE * phonebookFile = fopen("phonebook.txt", "r+");

	Record phonebook[101];

	copyDataToStruct(phonebookFile, phonebook, size);

	if (!phonebookFile)
	{
		FILE * phonebookFile = fopen("phonebook.txt", "w+");
	}

	int number = -1;

	userInterface(number, phonebook);

	fclose(phonebookFile);

	return 0;
}