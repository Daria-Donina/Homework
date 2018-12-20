#include <stdio.h>
#include "list.h"

struct List
{
	ListElement *head;
};

struct ListElement
{
	int value = 0;
	ListElement *next = { nullptr };
};

List *createList()
{
	return new List { nullptr };
}

void add(List *list, int value)
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

int remove(List *list, int value)
{
	enum results { success, listIsEmpty, NoSuchElement };
	ListElement *current = list->head;
	ListElement *prev = current;
	if (list->head == nullptr)
	{
		return listIsEmpty;
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
			if (prev != current)
			{
				prev->next = nullptr;
			}
			else
			{
				list->head = nullptr;
			}
			delete current;
			return success;
		}
		else
		{
			return NoSuchElement;
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
	return success;
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
		while (current)
		{
			ListElement *temp = current;
			current = current->next;
			delete temp;
		}
	}
	delete list;
}

bool test()
{
	List *list = createList();
	int testArray[5] = { 1, 6, 3, 5, 8 };
	for (int i = 0; i < 5; ++i)
	{
		add(list, testArray[i]);
	}
	ListElement *current = list->head;
	int testArraySorted[5] = { 1, 3, 5, 6, 8 };
	for (int i = 0; i < 5; ++i)
	{
		if (current->value != testArraySorted[i])
		{
			printf("Function push is not working correctly\n");
			deleteList(list);
			return false;
		}
		current = current->next;
	}
	remove(list, 1);
	remove(list, 8);
	remove(list, 5);
	current = list->head;
	for (int i = 1; i < 4; i += 2)
	{
		if (current->value != testArraySorted[i])
		{
			printf("Function pop is not working correctly\n\n");
			deleteList(list);
			return false;
		}
		if (i == 1)
		{
			current = current->next;
		}
	}
	if (current->next)
	{
		printf("Function pop is not working correctlyn\n");
		deleteList(list);
		return false;
	}
	deleteList(list);
	return true;
}