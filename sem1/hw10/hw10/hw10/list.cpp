#include "list.h"

List *createList()
{
	return new List{};
}

bool isEmpty(List *list)
{
	return !list->head;
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