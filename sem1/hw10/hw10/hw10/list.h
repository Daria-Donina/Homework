#pragma once

struct ListNode;

struct List;

//Create new list
List *createList();

//Add new road and its length
void add(List *list, int numberOfCity, int length);

//Find out if city is in the list
bool find(List *list, int numberOfCity);

//Remove list
void deleteList(List *list);

// Get head of the list
ListNode *head(List *list);

// Get length of the road to the city
int length(ListNode *node);

// Create list node to become minimum
ListNode *createMinimum();

// Get number of city of the node
int numberOfCity(ListNode *node);

// Get next node
ListNode *next(ListNode *node);