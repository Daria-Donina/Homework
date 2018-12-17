#pragma once
#include <string>

struct Node;

struct List;

//Create new list
List *createList();

namespace list
{
	//Add data
	void add(List *list, std::string data);
}

//Delete list
void deleteList(List *list);

//Print list
void printList(List *list);
