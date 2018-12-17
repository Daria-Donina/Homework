#include "list.h"
#include <string>
#include <iostream>

using namespace std;
using namespace list;

struct Node
{
	string data = 0;
	int counter = 0;
	Node *next{};
};

struct List
{
	Node *head{};
};

List *createList()
{
	return new List;
}

bool isEmpty(List *list)
{
	return !list->head;
}

void addNode(Node *node, string data)
{
	while (node->next)
	{
		node = node->next;
	}
	node->next = new Node{ data, 1 };
}

Node* exists(List *list, string data)
{
	Node *node = list->head;
	while (node)
	{
		if (node->data == data)
		{
			return node;
		}
		node = node->next;
	}
	return nullptr;
}

void list::add(List *list, string data)
{
	if (isEmpty(list))
	{
		list->head = new Node{ data };
	}

	Node *sameNode = exists(list, data);

	if (!sameNode)
	{
		addNode(list->head, data);
	}
	else
	{
		++sameNode->counter;
	}
}

void deleteList(List *list)
{
	Node *node = list->head;

	while (node)
	{
		auto temp = node;
		node = node->next;
		delete temp;
	}

	delete list;
}

void printList(List *list)
{
	Node *node = list->head;
	while (node)
	{
		cout << node->data << " - " << node->counter << endl;
		node = node->next;
	}
}