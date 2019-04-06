#pragma once
#include <fstream>

struct ListElement
{
	int value;
	ListElement *next;
};

struct List
{
	int length = 0;
	ListElement *head;
};

List *createList();
void deleteList(List *list);

void add(std::ifstream &inputData, List *list);

void print(List *list);

void reverseList(List *list);
