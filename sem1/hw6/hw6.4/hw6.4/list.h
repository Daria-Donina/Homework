#pragma once
#include <string>

struct Record
{
	std::string name = "";
	std::string phoneNumber = 0;
};

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

//Creates new list
List *createList();

//Adds records from file to the list
void pushFromFile(List *list, std::ifstream &phonebook);

//Adds record to the list
void push(List *list, Record record);

//Removes elements from the list
void deleteElements(List *list);

//Removes list
void deleteList(List *list);