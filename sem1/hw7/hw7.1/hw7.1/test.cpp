#include "test.h"
#include "set.h"
#include <vector>
#include <iostream>

bool test(std::vector<int> array)
{
	Set *testTree = createSet();

	for (int i = 0; i < array.size(); ++i)
	{
		add(testTree, array[i]);
	}

	for (int i = 0; i < array.size(); ++i)
	{
		if (!isInTheSet(testTree, array[i]))
		{
			deleteSet(testTree);
			return false;
		}
	}

	std::vector<int> testAscendingValues;
	std::vector<int> testDescendingValues;

	infixTraverse(testTree, testAscendingValues);
	backTraverse(testTree, testDescendingValues);

	for (int i = 0; i < array.size() - 1; ++i)
	{
		if (testAscendingValues[i] > testAscendingValues[i + 1] || testDescendingValues[i] < testDescendingValues[i + 1])
		{
			deleteSet(testTree);
			return false;
		}
	}

	for (int i = 0; i < array.size(); ++i)
	{
		remove(testTree, array[i]);
	}

	if (root(testTree))
	{
		deleteSet(testTree);
		return false;
	}

	deleteSet(testTree);

	return true;
}

void printTest()
{
	std::vector<int> testArray = { 29, 13, 3, 7, 98, 45, 23, 11, 47, 32, 67, 25 };
	if (test(testArray))
	{
		std::cout << "Tests passed" << std::endl;
	}
	else
	{
		std::cout << "Tests failed" << std::endl;
	}
}