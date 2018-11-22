#pragma once
#include <stdio.h>

struct Record
{
	char name[100]{};
	int phoneNumber = 0;
};

//�������� ������ �� ����� � ��������� � ������ ������ ���������
void copyDataToStruct(FILE * phonebookFile, Record *phonebook, const int size);

//�������, ������� ������� � �����������
int numberOfRecords(Record *phonebook, const int size);
