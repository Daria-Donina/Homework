#include <vector>
#include "set.h"

struct Node
{
	int data = 0;
	Node *leftChild = nullptr;
	Node *rightChild = nullptr;
};

struct Set
{
	Node *root = nullptr;
};

Node *root(Set *tree)
{
	return tree->root;
}

Set *createSet()
{
	return new Set{ nullptr };
}

bool isEmpty(Set *tree)
{
	return !tree->root;
}

void addNode(Node *node, int value);

void add(Set *tree, int value)
{
	if (isEmpty(tree))
	{
		tree->root = new Node{ value, nullptr, nullptr };
	}
	else
	{
		addNode(tree->root, value);
	}
}

void addNode(Node *node, int value)
{
	if (value == node->data)
	{
		return;
	}
	if (value < node->data)
	{
		if (node->leftChild)
		{
			addNode(node->leftChild, value);
		}
		else
		{
			node->leftChild = new Node{ value, nullptr, nullptr };
		}
	}
	else if (value > node->data)
	{
		if (node->rightChild)
		{
			addNode(node->rightChild, value);
		}
		else
		{
			node->rightChild = new Node{ value, nullptr, nullptr };
		}
	}
}

void deleteNode(Node *&node, int value);

void remove(Set *tree, int value)
{
	if (isEmpty(tree))
	{
		return;
	}
	else
	{
		deleteNode(tree->root, value);
	}
}

void deleteNode(Node *&node, int value)
{
	if (value > node->data)
	{
		if (node->rightChild)
		{
			deleteNode(node->rightChild, value);
		}
		else
		{
			return;
		}
	}
	else if (value < node->data)
	{
		if (node->leftChild)
		{
			deleteNode(node->leftChild, value);
		}
		else
		{
			return;
		}
	}
	else if (value == node->data)
	{
		if (node->leftChild && node->rightChild)
		{
			Node *minRight = node->rightChild;
			while (minRight->leftChild)
			{
				minRight = minRight->leftChild;
			}
			const int rightMinimum = minRight->data;
			deleteNode(node, minRight->data);
			node->data = rightMinimum;
		}
		else if (node->leftChild || node->rightChild)
		{
			Node *temp = nullptr;
			if (node->leftChild)
			{
				temp = node->leftChild;
			}
			else
			{
				temp = node->rightChild;
			}
			node->data = temp->data;
			node->leftChild = temp->leftChild;
			node->rightChild = temp->rightChild;
			delete temp;
		}
		else
		{
			Node *temp = node;
			node = nullptr;
			delete temp;
		}
	}
}

bool isInTheSet(Set *tree, int value)
{
	if (isEmpty(tree))
	{
		return false;
	}

	auto node = tree->root;

	while (value != node->data)
	{
		if (value > node->data && node->rightChild)
		{
			node = node->rightChild;
		}
		else if (value < node->data && node->leftChild)
		{
			node = node->leftChild;
		}
		else
		{
			return false;
		}
	}
	return true;
}

void deleteSet(Set *tree)
{
	while (!isEmpty(tree))
	{
		remove(tree, tree->root->data);
	}
	delete tree;
	return;
}

void traverse(Node *node, std::vector<int> &values, const int type)
{
	if (node)
	{
		type == 1 ? traverse(node->leftChild, values, 1) : traverse(node->rightChild, values, 2);
		values.push_back(node->data);
		type == 1 ? traverse(node->rightChild, values, 1) : traverse(node->leftChild, values, 2);
	}
}

void infixTraverse(Set *tree, std::vector<int> &values)
{
	if (isEmpty(tree))
	{
		return;
	}
	
	traverse(tree->root, values, 1);
}

void backTraverse(Set *tree, std::vector<int> &values)
{
	if (isEmpty(tree))
	{
		return;
	}
	traverse(tree->root, values, 2);
}