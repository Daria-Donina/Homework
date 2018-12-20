#include <fstream>
#include <iostream>
#include "parseTree.h"

using namespace std;

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

ParseTree *createParseTree()
{
	return new ParseTree{ nullptr };
}

Node *root(ParseTree *tree)
{
	return tree->root;
}

bool isEmpty(ParseTree *tree)
{
	return !tree->root;
}

void add(std::ifstream &inputData, ParseTree *tree, Node *current);

void fillParseTree(std::ifstream &inputData, ParseTree *tree)
{
	add(inputData, tree, tree->root);
}

bool isOperator(int data)
{
	return data == '+' || data == '-' || data == '*' || data == '/';
}

bool isOpeningBracket(int data)
{
	return data == '(';
}

bool isClosingBracket(int data)
{
	return data == ')';
}

void add(std::ifstream &inputData, ParseTree *tree, Node *current)
{
	char symbol = 0;
	inputData >> symbol;

	if (isOpeningBracket(symbol))
	{
		auto newNode = new Node{};
		if (isEmpty(tree))
		{
			tree->root = newNode;
			add(inputData, tree, newNode);
		}
		else
		{
			if (!current->leftChild)
			{
				current->leftChild = newNode;
				add(inputData, tree, newNode);
			}
			else
			{
				current->rightChild = newNode;
				add(inputData, tree, newNode);
			}
		}
	}
	else if (isOperator(symbol))
	{
		current->data = symbol;
		add(inputData, tree, current);
		add(inputData, tree, current);
	}
	else if (isClosingBracket(symbol))
	{
		add(inputData, tree, current);
	}
	else
	{
		auto newNode = new Node{ symbol - '0', nullptr, nullptr };
		if (current)
		{
			if (!current->leftChild)
			{
				current->leftChild = newNode;
			}
			else
			{
				current->rightChild = newNode;
			}
		}
		else
		{
			current->data = symbol - '0';
		}
	}
}

void lrnTraverseDelete(Node *node);

void deleteParseTree(ParseTree *tree)
{
	if (isEmpty(tree))
	{
		delete tree;
		return;
	}

	lrnTraverseDelete(tree->root);
	delete tree;
}

void lrnTraverseDelete(Node *node)
{
	if (node)
	{
		lrnTraverseDelete(node->leftChild);
		lrnTraverseDelete(node->rightChild);
		delete node;
	}
}

int calculatingValueOfTheTree(Node *node)
{
	if (isOperator(node->data))
	{
		if (node->data == '+')
		{
			return calculatingValueOfTheTree(node->leftChild) + calculatingValueOfTheTree(node->rightChild);
		}
		else if (node->data == '-')
		{
			return calculatingValueOfTheTree(node->leftChild) - calculatingValueOfTheTree(node->rightChild);
		}
		else if (node->data == '*')
		{
			return calculatingValueOfTheTree(node->leftChild) * calculatingValueOfTheTree(node->rightChild);
		}
		else
		{
			return calculatingValueOfTheTree(node->leftChild) / calculatingValueOfTheTree(node->rightChild);
		}
	}

	return node->data;
}

void nlrPrintTheTree(ParseTree *tree, Node *current)
{
	if (isOperator(current->data))
	{
		cout << "( " << (char) current->data << " ";

		nlrPrintTheTree(tree, current->leftChild);
		nlrPrintTheTree(tree, current->rightChild);

		cout << " )";
	}
	else
	{
		cout << current->data << " ";
	}
}