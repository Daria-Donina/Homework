#pragma once
#include <stdio.h>

struct Record;

//�������� ������ �� ����� � ��������� � ������ ������ ���������
void copyDataToStruct(FILE * phonebookFile, Record *phonebook, const int size);

//�������, ������� ������� � �����������
int numberOfRecords(Record *phonebook, const int size);
