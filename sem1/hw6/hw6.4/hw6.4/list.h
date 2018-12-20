#pragma once
#include <string>

struct Record
{
	std::string name = "";
	std::string phoneNumber = 0;
};

struct ListElement;

struct List;

//Creates new list
List *createList();

//Adds records from file to the list
void pushFromFile(List *list, std::ifstream &phonebook);

//Adds record to the list
void push(List *list, Record record);

//Get current element
ListElement *getCurrent(ListElement *node);

//Get head of the list
ListElement *getHead(List *list);

//Get next element 
ListElement *getNext(ListElement *node);

//Get name of the node
std::string getName(ListElement *node);

//Get number of the node
std::string getNumber(ListElement *node);

//Get record
Record getRecord(ListElement *node);

//Get length of the list
int getLength(List *list);

//Removes elements from the list
void deleteElements(List *list);

//Removes list
void deleteList(List *list);