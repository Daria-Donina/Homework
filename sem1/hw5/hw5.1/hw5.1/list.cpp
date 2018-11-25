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

void pop(List *list, int value)
{
	ListElement *current = list->head;
	ListElement *prev = current;
	if (list->head == nullptr)
	{
		printf("List has no elements\n\n");
		return;
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
		}
		else
		{
			printf("There is no such element in the list\n\n");
		}
		return;
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
	printf("Value has been deleted\n\n");
	return;
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