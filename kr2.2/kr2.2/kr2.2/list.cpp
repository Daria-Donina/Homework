#include <iostream>
#include "list.h"

struct Node
{
	int value = 0;
	int position = 0;
	Node *previous{};
	Node *next{};
};

struct List
{
	int length = 0;
	Node *head{};
	Node *tail{};
};

List *createList()
{
	return new List{};
}

bool isEmpty(List *list)
{
	return !list->head;
}

void add(List *list, int value, int position)
{
	if (isEmpty(list))
	{
		if (position == 0)
		{
			list->head = new Node{ value, 0 };
			list->tail = list->head;
			++list->length;
			return;
		}
		else
		{
			list->head = new Node{ 0, 0 };
			++list->length;
		}
	}

	if (position == 0)
	{
		list->head->value = value;
		return;
	}
	
	auto node = list->head;
	for (int i = 1; i < position; ++i)
	{
		if (!node->next)
		{
			node->next = new Node{ 0, i, node };
			++list->length;
		}
		node = node->next;
	}

	if (!node->next)
	{
		node->next = new Node{ value, position, node };
		list->tail = node->next;
		++list->length;
		return;
	}
	node->next->value = value;
}

void remove(List *list, int position)
{
	if (position == list->tail->position)
	{
		auto temp = list->tail;
		temp->previous->next = nullptr;
		list->tail = temp->previous;
		delete temp;
		--list->length;
		return;
	}

	auto node = list->head;
	for (int i = 0; i < position; ++i)
	{
		node = node->next;
	}

	--list->length;

	for (int i = position; i < list->length; ++i)
	{
		node->value = node->next->value;
		node = node->next;
	}

	auto toDelete = list->tail;
	node->previous->next = nullptr;
	list->tail = node->previous;
	delete toDelete;
}

void printList(List *list)
{
	auto node = list->head;
	while (node)
	{
		std::cout << node->value << std::endl;
		node = node->next;
	}
}

void deleteList(List *list)
{
	auto node = list->head;
	while (node)
	{
		auto temp = node;
		node = node->next;
		delete temp;
	}

	delete list;
}

bool programTest()
{
	List *testList = createList();

	add(testList, 1, 2);
	add(testList, 2, 0);
	add(testList, 3, 4);

	auto node = testList->head;
	for (int i = 0; i < testList->length; ++i)
	{
		if (!i && node->value != 2 || i == 2 && node->value != 1 || i == 4 && node->value != 3)
		{
			deleteList(testList);
			return false;
		}
		node = node->next;
	}

	remove(testList, 4);
	remove(testList, 2);
	node = testList->head;
	for (int i = 0; i < testList->length; ++i)
	{
		if (!i && node->value != 2 || i && node->value)
		{
			deleteList(testList);
			return false;
		}
		node = node->next;
	}
	deleteList(testList);
	return true;
}