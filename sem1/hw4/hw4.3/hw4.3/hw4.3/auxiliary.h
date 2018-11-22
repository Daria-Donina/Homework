#pragma once
#include <stdio.h>

struct Record
{
	char name[100]{};
	int phoneNumber = 0;
};

//Копирует данные из файла в структуру в начале работы программы
void copyDataToStruct(FILE * phonebookFile, Record *phonebook, const int size);

//Считает, сколько записей в справочнике
int numberOfRecords(Record *phonebook, const int size);
