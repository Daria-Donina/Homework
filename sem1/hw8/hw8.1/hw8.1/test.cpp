#include <iostream>
#include "map.h"
#include "test.h"

using namespace std;

bool programTest()
{
	Map *testMap = createMap();

	insert(testMap, "5", "a");
	insert(testMap, "4", "b");
	insert(testMap, "7", "c");
	insert(testMap, "9", "d");
	insert(testMap, "8", "e");
	insert(testMap, "6", "f");
	insert(testMap, "12", "g");

	if (!isKey(testMap->root, "5") || !isKey(testMap->root, "4") || !isKey(testMap->root, "7") || !isKey(testMap->root, "9") ||
		!isKey(testMap->root, "8") || !isKey(testMap->root, "6") || !isKey(testMap->root, "12") || isKey(testMap->root, "10"))
	{
		deleteMap(testMap);
		return false;
	}

	Node *node = testMap->root;

	if (node->key != "7" || node->leftChild->key != "5" || node->rightChild->key != "9")
	{
		deleteMap(testMap);
		return false;
	}

	auto nodeLeft = node->leftChild;
	auto nodeRight = node->rightChild;

	if (nodeLeft->leftChild->key != "4" || nodeLeft->rightChild->key != "6" ||
		nodeRight->leftChild->key != "8" || nodeRight->rightChild->key != "12")
	{
		deleteMap(testMap);
		return false;
	}

	remove(testMap, "7");
	remove(testMap, "6");
	remove(testMap, "5");

	node = testMap->root;
	nodeLeft = node->leftChild;
	nodeRight = node->rightChild;

	if (isKey(testMap->root, "7") || isKey(testMap->root, "6") || isKey(testMap->root, "5"))
	{
		deleteMap(testMap);
		return false;
	}

	if (node->key != "8" || nodeLeft->key != "4" || nodeLeft->leftChild
		|| nodeRight->key != "9" || nodeRight->rightChild->key != "12")
	{
		deleteMap(testMap);
		return false;
	}

	remove(testMap, "4");

	node = testMap->root;
	nodeLeft = node->leftChild;
	nodeRight = node->rightChild;

	if (node->key != "9" || node->leftChild->key != "8" || node->rightChild->key != "12")
	{
		deleteMap(testMap);
		return false;
	}

	if (find(testMap, "8") != "e" || find(testMap, "7") != "" || find(testMap, "12") != "g")
	{
		deleteMap(testMap);
		return false;
	}

	deleteMap(testMap);
	return true;
}

void test()
{
	if (programTest())
	{
		cout << "Tests passed" << endl;
	}
	else
	{
		cout << "Tests failed" << endl;
	}
}