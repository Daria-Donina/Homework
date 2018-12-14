#include "list.h"
#include <iostream>
#include <fstream>

using namespace std;

List *createList()
{
	return new List{};
}

void deleteListWithoutNodes(List *list)
{
	delete list;
}

void deleteList(List *list)
{
	ListElement *current = list->head;
	while (current)
	{
		ListElement *nextElement = current->next;
		delete current;
		current = nextElement;
	}

	deleteListWithoutNodes(list);
}

void print(List *list)
{
	ListElement *current = list->head;
	while (current)
	{
		cout << current->value << " ";
		current = current->next;
	}
	cout << endl;
}

void add(ifstream &inputData, List *list)
{
	int newElement = 0;
	inputData >> newElement;
	list->head = new ListElement{ newElement, nullptr };
	auto current = list->head;
	++list->length;
	while (!inputData.eof())
	{
		inputData >> newElement;
		current->next = new ListElement{ newElement, nullptr };
		current = current->next;
		++list->length;
	}
}

void reverseList(List *list)
{
	List *newList = createList();
	ListElement *newListNode = newList->head;
	ListElement *current = list->head;
	for (int i = 1; i <= list->length; ++i)
	{
		for (int j = list->length; j > i; --j)
		{
			current = current->next;
		}
		if (!newList->head)
		{
			newList->head = current;
			newListNode = newList->head;
		}
		else
		{
			newListNode->next = current;
			newListNode = newListNode->next;
			newListNode->next = nullptr;
		}
		current = list->head;
	}

	list->head = newList->head;
	deleteListWithoutNodes(newList);
}