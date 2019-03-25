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

	if (!isKey(root(testMap), "5") || !isKey(root(testMap), "4") || !isKey(root(testMap), "7") || !isKey(root(testMap), "9") ||
		!isKey(root(testMap), "8") || !isKey(root(testMap), "6") || !isKey(root(testMap), "12") || isKey(root(testMap), "10"))
	{
		deleteMap(testMap);
		return false;
	}

	Node *node = root(testMap);

	if (key(node) != "7" || key(leftChild(node)) != "5" || key(rightChild(node)) != "9")
	{
		deleteMap(testMap);
		return false;
	}

	auto nodeLeft = leftChild(node);
	auto nodeRight = rightChild(node);

	if (key(leftChild(nodeLeft)) != "4" || key(rightChild(nodeLeft)) != "6" ||
		key(leftChild(nodeRight)) != "8" || key(rightChild(nodeRight)) != "12")
	{
		deleteMap(testMap);
		return false;
	}

	remove(testMap, "7");
	remove(testMap, "6");
	remove(testMap, "5");

	node = root(testMap);
	nodeLeft = leftChild(node);
	nodeRight = rightChild(node);

	if (isKey(root(testMap), "7") || isKey(root(testMap), "6") || isKey(root(testMap), "5"))
	{
		deleteMap(testMap);
		return false;
	}

	if (key(node) != "8" || key(nodeLeft) != "4" || leftChild(nodeLeft)
		|| key(nodeRight) != "9" || key(rightChild(nodeRight)) != "12")
	{
		deleteMap(testMap);
		return false;
	}

	remove(testMap, "4");

	node = root(testMap);
	nodeLeft = leftChild(node);
	nodeRight = rightChild(node);

	if (key(node) != "9" || key(leftChild(node)) != "8" || key(rightChild(node)) != "12")
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