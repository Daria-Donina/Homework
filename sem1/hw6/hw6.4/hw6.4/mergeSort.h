#pragma once
#include <string>
#include "list.h"

//Chooses how to sort a list - by name or by phone number
std::string typeOfSort(ListElement *node, int number);

//Selects the minimal value
int min(int a, int b);

//Merge Sorting
void mergeSort(List *list, const int number);
