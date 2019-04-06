#pragma once
#include <vector>
#include <fstream>

struct Node
{
	int data = 0;
	Node *leftChild = nullptr;
	Node *rightChild = nullptr;
};

struct ParseTree
{
	Node *root = nullptr;
};

//Fills the parse tree
void fillParseTree(std::ifstream &inputData, ParseTree *tree);

//Creates new parse tree
ParseTree *createParseTree();

//Calculates value of a parse tree
int calculatingValueOfTheTree(Node *node);

//Removes the tree
void deleteParseTree(ParseTree *tree);

//Prints parse tree
void nlrPrintTheTree(ParseTree *tree, Node *current);