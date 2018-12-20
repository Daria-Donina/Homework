#pragma once

struct Node;

struct CyclicList;

//Create new cyclic list
CyclicList *createCyclicList();

//Add new node
void add(CyclicList *list, int value);

//Remove node
void remove(CyclicList *list, Node *node);

//Get head of the list
Node *head(CyclicList *list);

//Check if there is one node in the list
bool isOneNode(CyclicList *list);

//Get next node
Node *next(Node *node);

//Get current node
int nodeNumber(Node *node);

//Delete cyclic list
void deleteCyclicList(CyclicList *list);
