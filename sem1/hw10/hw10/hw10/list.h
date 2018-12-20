#pragma once

struct ListNode
{
	int numberOfCity = 0;
	int length = 0;
	ListNode *next{};
};

struct List
{
	ListNode *head{};
};

//Create new list
List *createList();

//Add new road and its length
void add(List *list, int numberOfCity, int length);

//Find out if city is in the list
bool find(List *list, int numberOfCity);

//Remove list
void deleteList(List *list);
