#include <fstream>
#include <iostream>
#include "parseTree.h"
#include "test.h"

using namespace std;

bool programTest()
{
	ParseTree *testTreeFirst = createParseTree();
	ParseTree *testTreeSecond = createParseTree();

	ifstream inputTest("test.txt");

	fillParseTree(inputTest, testTreeFirst);
	fillParseTree(inputTest, testTreeSecond);

	inputTest.close();

	if (calculatingValueOfTheTree(testTreeFirst->root) != 4 || calculatingValueOfTheTree(testTreeSecond->root) != 92)
	{
		deleteParseTree(testTreeFirst);
		deleteParseTree(testTreeSecond);
		return false;
	}

	deleteParseTree(testTreeFirst);
	deleteParseTree(testTreeSecond);

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