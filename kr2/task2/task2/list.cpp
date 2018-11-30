#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "list.h"

List *createList()
{
	return new List{ 0, nullptr };
}

void add(List *list, FILE * file)
{
	auto current = list->head;
	while (!feof(file))
	{
		if (list->head == nullptr)
		{
			auto temp = new ListElement{ 0, nullptr, nullptr };
			fscanf(file, "%d", &temp->data);
			list->head = temp;
			current = list->head;
			list->tail = temp;
			++list->length;
		}
		else
		{
			auto temp = new ListElement{ 0, nullptr, nullptr };
			fscanf(file, "%d", &temp->data);
			current->next = temp;
			temp->prev = current;
			list->tail = temp;
			current = current->next;
			++list->length;
		}
	}
}

bool isSymmetry(List *list)
{
	auto left = list->head;
	auto right = list->tail;
	for (int i = 0; i < list->length; ++i)
	{
		if (left->data != right->data)
		{
			return false;
		}
		left = left->next;
		right = right->prev;
	}
	return true;
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