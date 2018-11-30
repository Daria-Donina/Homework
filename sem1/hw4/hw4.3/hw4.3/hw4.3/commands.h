#pragma once
#include <stdio.h>
#include "auxiliary.h"

//��������� ������ � ����������
void addARecord(Record *phonebook, char *name, int phoneNumber, const int size);

//������� ����� �������� �� �����
int findAPhoneNumber(Record *phonebook, char *name, const int size);

//������� ��� �� ������ ��������
int findAName(Record *phonebook, int phoneNumber, const int size);

//��������� ��������� ������ � ����
void saveCurrentDataToFile(FILE * phonebookFile, Record *phonebook, const int size);