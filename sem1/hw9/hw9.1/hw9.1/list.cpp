#include "list.h"
#include <string>
#include <iostream>

using namespace std;
using namespace list;

struct list::Node
{
	std::string data = 0;
	int counter = 0;
	Node *next{};
};

struct list::List
{
	int length = 0;
	list::Node *head{};
};

list::List *list::createList()
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

Node* list::exists(List *list, const string &data)
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

int list::length(List *list)
{
	return list->length;
}

int list::counter(Node *node)
{
	return node->counter;
}

void list::add(List *list, const string &data)
{
	if (isEmpty(list))
	{
		list->head = new Node{ data, 1 };
		++list->length;
		return;
	}

	Node *sameNode = exists(list, data);

	if (!sameNode)
	{
		addNode(list->head, data);
		++list->length;
	}
	else
	{
		++sameNode->counter;
	}
}

void list::deleteList(List *list)
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

void list::printList(List *list)
{
	Node *node = list->head;
	while (node)
	{
		cout << node->data << " - " << node->counter << endl;
		node = node->next;
	}
}