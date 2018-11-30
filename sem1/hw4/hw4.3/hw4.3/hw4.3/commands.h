#pragma once
#include <stdio.h>
#include "auxiliary.h"

//Добавляет запись в справочник
void addARecord(Record *phonebook, char *name, int phoneNumber, const int size);

//Находит номер телефона по имени
int findAPhoneNumber(Record *phonebook, char *name, const int size);

//Находит имя по номеру телефона
int findAName(Record *phonebook, int phoneNumber, const int size);

//Сохраняет введенные данные в файл
void saveCurrentDataToFile(FILE * phonebookFile, Record *phonebook, const int size);