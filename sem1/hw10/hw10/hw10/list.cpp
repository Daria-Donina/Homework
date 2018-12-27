#include "list.h"

struct ListNode
{
	int numberOfCity = 0;
	int length = 0;
	ListNode *next{};
};

struct List
{
	ListNode *head{};
};

List *createList()
{
	return new List{};
}

bool isEmpty(List *list)
{
	return !list->head;
}

ListNode *head(List *list)
{
	return list->head;
}

int length(ListNode *node)
{
	return node->length;
}

ListNode *createMinimum()
{
	auto minimum = new ListNode{};
	minimum->length = 10000000;
	return minimum;
}

int numberOfCity(ListNode *node)
{
	return node->numberOfCity;
}

ListNode *next(ListNode *node)
{
	return node->next;
}

void deleteNode(ListNode *node)
{
	delete node;
}

void add(List *list, int numberOfCity, int length)
{
	if (isEmpty(list))
	{
		list->head = new ListNode{ numberOfCity, length };
		return;
	}

	auto node = list->head;
	while (node->next)
	{
		node = node->next;
	}
	node->next = new ListNode{ numberOfCity, length };
}

bool find(List *list, int numberOfCity)
{
	auto node = list->head;
	while (node)
	{
		if (node->numberOfCity == numberOfCity)
		{
			return true;
		}
		node = node->next;
	}
	return false;
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