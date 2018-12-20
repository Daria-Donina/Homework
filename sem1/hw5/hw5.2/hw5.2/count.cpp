#include <stdio.h>
#include "count.h"

void addWarriors(CyclicList *cyclicList, int n)
{
	Node *current = new Node{ 1, cyclicList->head };
	cyclicList->head = current;
	for (int i = 2; i <= n; ++i)
	{
		Node *nextWarrior = new Node{i, cyclicList->head};
		current->next = nextWarrior;
		current = current->next;
	}
}

bool isOnlyOneLeft(CyclicList *cyclicList)
{
	Node *current = cyclicList->head;
	if (current->next == current)
	{
		return true;
	}
	return false;
}

int killing(CyclicList *cyclicList, int m)
{
	Node *current = cyclicList->head;
	while (!isOnlyOneLeft(cyclicList))
	{
		Node *previous = current;
		for (int i = 1; i < m; ++i)
		{
			previous = current;
			current = current->next;
		}
		Node *toKill = current;
		if (toKill != cyclicList->head)
		{
			previous->next = toKill->next;
		}
		else
		{
			previous->next = toKill->next;
			cyclicList->head = toKill->next;
		}
		current = current->next;
		delete toKill;
	}
	return cyclicList->head->number;
}