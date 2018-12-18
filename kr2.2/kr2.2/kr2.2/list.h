#pragma once

struct Node;

struct List;

//Create list
List *createList();

//Add value on a certain position
void add(List *list, int value, int position);

//Remove value from a certain position
void remove(List *list, int position);

//Print list
void printList(List *list);

//Delete list
void deleteList(List *list);

//Testing the program
bool programTest();
