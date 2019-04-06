#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include "auxiliary.h"
#include "test.h"
#include "interface.h"

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

	FILE * phonebookFile = fopen("phonebook.txt", "r");

	if (!phonebookFile)
	{
		phonebookFile = fopen("phonebook.txt", "w+");
	}

	Record phonebook[101];

	copyDataToStruct(phonebookFile, phonebook, size);

	fclose(phonebookFile);

	int number = -1;

	userInterface(number, phonebook);

	return 0;
}