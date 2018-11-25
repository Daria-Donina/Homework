#include <stdio.h>
#include "list.h"

List *createList()
{
	return new List { nullptr };
}

void push(List *list, int value)
{
	ListElement *current = list->head;
	ListElement *prev = current;
	if (list->head == nullptr)
	{
		list->head = new ListElement{ value, list->head };
		return;
	}
	while (current->next && value > current->value)
	{
		prev = current;
		current = current->next;
	}
	if (value > current->value)
	{
		ListElement *newElement = new ListElement{ value, nullptr };
		current->next = newElement;
	}
	else
	{
		ListElement *newElement = new ListElement{ value, current };
		if (prev != current)
		{
			prev->next = newElement;
		}
		else
		{
			list->head = newElement;
		}
	}
}

int pop(List *list, int value)
{
	ListElement *current = list->head;
	ListElement *prev = current;
	if (list->head == nullptr)
	{
		return 1;
	}
	while (current->next && value != current->value)
	{
		prev = current;
		current = current->next;
	}
	if (current->next == nullptr)
	{
		if (current->value == value)
		{
			delete current;
			prev->next = nullptr;
			return 0;
		}
		else
		{
			return 2;
		}
	}
	ListElement *next = current->next;
	if (prev != current)
	{
		prev->next = next;
	}
	else
	{
		list->head = next;
	}
	delete current;
	return 0;
}

void print(List *list)
{
	ListElement *current = list->head;
	while (current)
	{
		printf("%d\n", current->value);
		current = current->next;
	}
}

void deleteList(List *list)
{
	if (list->head)
	{
		ListElement *current = list->head;
		while (current->next != nullptr)
		{
			ListElement *next = current->next;
			delete current;
			current = next;
		}
	}
	delete list;
}