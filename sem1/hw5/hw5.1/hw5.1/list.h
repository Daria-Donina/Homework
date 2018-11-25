#pragma once

struct ListElement;

struct List
{
	ListElement *head;
};

struct ListElement
{
	int value = 0;
	ListElement *next = { nullptr };
};

List *createList();

//Adds value to the list
void push(List *list, int value);

//Removes value from the list
int pop(List *list, int value);

//Prints list
void print(List *list);

//Removes list
void deleteList(List *list);