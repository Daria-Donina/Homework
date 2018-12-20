#pragma once
#include <string>

namespace list
{
	struct Node;

	struct List;

	//Create new list
	List *createList();

	//Add data
	void add(List *list, const std::string &data);

	//Delete list
	void deleteList(List *list);

	//Print list
	void printList(List *list);

	//Get list length
	int length(List *list);

	//Get node counter
	int counter(Node *node);

	//Check if data is already in the list
	Node* exists(List *list, const std::string &data);
}
