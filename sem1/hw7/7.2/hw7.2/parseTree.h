#pragma once
#include <vector>
#include <fstream>

struct Node;

struct ParseTree;

//Fills the parse tree
void fillParseTree(std::ifstream &inputData, ParseTree *tree);

//Creates new parse tree
ParseTree *createParseTree();

//Get root of the tree
Node *root(ParseTree *tree);

//Calculates value of a parse tree
int calculatingValueOfTheTree(Node *node);

//Removes the tree
void deleteParseTree(ParseTree *tree);

//Prints parse tree
void nlrPrintTheTree(ParseTree *tree, Node *current);