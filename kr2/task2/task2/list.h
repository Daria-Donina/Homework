#pragma once
#include <stdio.h>

struct ListElement
{
	int data = 0;
	ListElement *prev = nullptr;
	ListElement *next = nullptr;
};

struct List
{
	int length = 0;
	ListElement *head;
	ListElement *tail;
};

List *createList();

void add(List *list, FILE * file);

bool isSymmetry(List *list);

void deleteList(List *list);
