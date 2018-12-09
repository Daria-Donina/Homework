#include <fstream>
#include <string>
#include "list.h"

List *createList()
{
	return new List{ 0, nullptr };
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