#include "map.h"
#include <string>
#include <iostream>

using namespace std;

struct Node
{
	std::string key = "";
	std::string value = "";
	int height = 0;
	Node *leftChild = nullptr;
	Node *rightChild = nullptr;
};

struct Map
{
	Node *root{};
};

Map *createMap()
{
	return new Map;
}

Node *root(Map *map)
{
	return map->root;
}

string key(Node *node)
{
	return node->key;
}

Node *leftChild(Node *node)
{
	return node->leftChild;
}

Node *rightChild(Node *node)
{
	return node->rightChild;
}

bool isEmpty(Map *map)
{
	return !map->root;
}

int height(Node *node)
{
	return node ? node->height : 0;
}

int balanceFactor(Node *node)
{
	return height(node->rightChild) - height(node->leftChild);
}

void fixHeight(Node *node)
{
	int leftHeight = height(node->leftChild);
	int rightHeight = height(node->rightChild);
	node->height = (leftHeight > rightHeight ? leftHeight : rightHeight) + 1;
}

Node *rotateLeft(Node *node)
{
	Node *right = node->rightChild;
	node->rightChild = right->leftChild;
	right->leftChild = node;
	fixHeight(node);
	fixHeight(right);
	return right;
}

Node *rotateRight(Node *node)
{
	Node *left = node->leftChild;
	node->leftChild = left->rightChild;
	left->rightChild = node;
	fixHeight(node);
	fixHeight(left);
	return left;
}

Node *balance(Node *node)
{
	fixHeight(node);
	if (balanceFactor(node) == 2)
	{
		if (balanceFactor(node->rightChild) < 0)
		{
			node->rightChild = rotateRight(node->rightChild);
		}
		return rotateLeft(node);
	}

	if (balanceFactor(node) == -2)
	{
		if (balanceFactor(node->leftChild) > 0)
		{
			node->leftChild = rotateLeft(node->leftChild);
		}
		return rotateRight(node);
	}

	return node;
}

bool isKey(Node *node, const string key);

Node* addValue(Node *&node, string key, string value);

void insert(Map *&map, string key, string value)
{
	if (isEmpty(map))
	{
		map->root = new Node{ key, value, 1 };
		return;
	}

	map->root = addValue(map->root, key, value);
}

string getValue(Node *node, string key);

Node* addValue(Node *&node, string key, string value)
{
	if (!node)
	{
		return new Node{ key, value, 1 };
	}

	if (stoi(key) == stoi(node->key))
	{
		node->value = value;
		return node;
	}

	if (stoi(key) < stoi(node->key))
	{
		node->leftChild = addValue(node->leftChild, key, value);
	}

	if (stoi(key) > stoi(node->key))
	{
		node->rightChild = addValue(node->rightChild, key, value);
	}
	
	return balance(node);
}

string find(Map *map, string key)
{
	return isKey(map->root, key) ? getValue(map->root, key) : "";
}

string getValue(Node *node, string key)
{
	if (stoi(key) == stoi(node->key))
	{
		return node->value;
	}

	if (stoi(key) < stoi(node->key))
	{
		return getValue(node->leftChild, key);
	}

	return getValue(node->rightChild, key);
}

bool isKey(Node *node, const string key)
{
	if (node)
	{
		if (stoi(key) == stoi(node->key))
		{
			return true;
		}

		if (stoi(key) < stoi(node->key))
		{
			return isKey(node->leftChild, key);
		}

		if (stoi(key) > stoi(node->key))
		{
			return isKey(node->rightChild, key);
		}
	}
	return false;
}

void keyAvailability(Map *map, string key)
{
	if (isKey(map->root, key))
	{
		cout << "Key is in the map" << endl;
	}
	else
	{
		cout << "Key is not in the map" << endl;
	}
}

Node* minimum(Node *node)
{
	return node->leftChild ? minimum(node->leftChild) : node;
}

Node* removeValue(Node *&node, string key);

void remove(Map *map, string key)
{
	if (isEmpty(map) || !isKey(map->root, key))
	{
		return;
	}

	map->root = removeValue(map->root, key);
}

Node* removeValue(Node *&node, string key)
{
	if (stoi(key) < stoi(node->key))
	{
		node->leftChild = removeValue(node->leftChild, key);
	}

	if (stoi(key) > stoi(node->key))
	{
		node->rightChild = removeValue(node->rightChild, key);
	}

	if (stoi(key) == stoi(node->key))
	{
		if (!node->leftChild && !node->rightChild)
		{
			delete node;
			return nullptr;
		}

		if (!node->leftChild || !node->rightChild)
		{
			Node *temp = node->leftChild ? node->leftChild : node->rightChild;
			delete node;
			return temp;
		}

		auto minimumNode = minimum(node->rightChild);
		swap(minimumNode->key, node->key);
		swap(minimumNode->value, node->value);
		node->rightChild = removeValue(node->rightChild, minimumNode->key);
	}
	
	return balance(node);
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

void deleteMap(Map *map)
{
	if (isEmpty(map))
	{
		delete map;
		return;
	}
	lrnTraverseDelete(map->root);
	delete map;
}