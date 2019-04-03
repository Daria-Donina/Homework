#include <fstream>
#include <string>
#include "list.h"

struct ListElement
{
	Record record;
	ListElement *next;
};

struct List
{
	int length = 0;
	ListElement *head;
};

List *createList()
{
	return new List{ 0, nullptr };
}

std::string getName(ListElement *node)
{
	return node->record.name;
}

std::string getNumber(ListElement *node)
{
	return node->record.phoneNumber;
}

Record getRecord(ListElement *node)
{
	return node->record;
}

int getLength(List *list)
{
	return list->length;
}

ListElement *getCurrent(ListElement *node)
{
	return node;
}

ListElement *getHead(List *list)
{
	return list->head;
}

ListElement *getNext(ListElement *node)
{
	return node->next;
}

void pushFromFile(List *list, std::ifstream &phonebook)
{
	ListElement *current = list->head;
	while (!phonebook.eof())
	{
		std::string tempName = "";
		getline(phonebook, tempName);
		std::string tempPhoneNumber = "";
		getline(phonebook, tempPhoneNumber);
		push(list, { tempName, tempPhoneNumber });
	}
}

void push(List *list, Record record)
{
	ListElement *current = list->head;
	auto newElement = new ListElement{ record, nullptr };
	if (!list->length)
	{
		list->head = newElement;
	}
	else
	{
		while (current->next != nullptr)
		{
			current = current->next;
		}
		current->next = newElement;
	}
	++list->length;
}

void deleteElements(List *list)
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
		delete current;
		list->length = 0;
	}
}

void deleteList(List *list)
{
	deleteElements(list);
	delete list;
}