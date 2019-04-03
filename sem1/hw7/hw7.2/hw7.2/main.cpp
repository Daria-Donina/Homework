#include "parseTree.h"
#include "test.h"
#include <iostream>
#include <fstream>

using namespace std;

int main()
{
	test();

	ParseTree *tree = createParseTree();

	ifstream inputData("input.txt");

	fillParseTree(inputData, tree);

	inputData.close();

	cout << "Parse tree:" << endl;
	nlrPrintTheTree(tree, tree->root);

	cout << endl << "The value of the parse tree: " << calculatingValueOfTheTree(tree->root) << endl;

	deleteParseTree(tree);

	return 0;
}