#pragma once
#include <vector>

struct Node;

struct Set;

//Adds value to the set
void add(Set *tree, int value);

//Get tree root
Node *root(Set *tree);

//Creates new set
Set *createSet();

//Removes value from the set
void remove(Set *tree, int value);

//Checks if the value is in the set
bool isInTheSet(Set *tree, int value);

//Removes set
void deleteSet(Set *tree);

//Traverses tree in ascending order
void infixTraverse(Set *tree, std::vector<int> &values);

//Traverses tree in descending order
void backTraverse(Set *tree, std::vector<int> &values);
