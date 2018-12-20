#pragma once

struct ListElement;

struct List;

List *createList();

//Adds value to the list
void add(List *list, int value);

//Removes value from the list
int remove(List *list, int value);

//Prints list
void print(List *list);

//Removes list
void deleteList(List *list);

//Testing the program
bool test();