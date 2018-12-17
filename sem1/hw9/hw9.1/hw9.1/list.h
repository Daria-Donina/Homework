#pragma once
#include <string>

struct Node
{
	std::string data = 0;
	int counter = 0;
	Node *next{};
};

struct List
{
	int length = 0;
	Node *head{};
};

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

//Check if data is already in the list
Node* exists(List *list, std::string data);