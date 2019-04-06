#include "cyclicList.h"

struct Node
{
	int number = 0;
	Node *next = { nullptr };
};

struct CyclicList
{
	Node *head = nullptr;
	Node *tail = nullptr;
};

CyclicList *createCyclicList()
{
	return new CyclicList{ nullptr };
}

bool isEmpty(CyclicList *list)
{
	return !list->head;
}

Node *head(CyclicList *list)
{
	return list->head;
}

int nodeNumber(Node *node)
{
	return node->number;
}

Node *next(Node *node)
{
	return node->next;
}

void add(CyclicList *list, int value)
{
	if (isEmpty(list))
	{
		list->head = new Node{ value };
		list->head->next = list->head;
		list->tail = list->head;
		return;
	}

	auto node = list->head;
	while (node != list->tail)
	{
		node = node->next;
	}
	node->next = new Node{ value, list->head };
	list->tail = node->next;
}

bool isOneNode(CyclicList *list)
{
	return list->tail == list->head;
}

void remove(CyclicList *list, Node *node)
{
	if (isEmpty(list))
	{
		return;
	}
	if (list->head == node)
	{
		if (!isOneNode(list))
		{
			list->head = node->next;
			list->tail->next = list->head;
		}
		else
		{
			list->head = nullptr;
		}
		delete node;
		return;
	}
	
	auto previous = list->head;
	while (previous->next != node)
	{
		previous = previous->next;
	}

	if (list->tail == node)
	{
		list->tail = previous;
	}

	previous->next = node->next;
	delete node;
}

void deleteCyclicList(CyclicList *list)
{
	auto node = list->head;
	while (node != list->tail)
	{
		auto temp = node;
		node = node->next;
		delete temp;
	}
	delete list->tail;
	delete list;
}