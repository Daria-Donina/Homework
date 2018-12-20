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
	nlrPrintTheTree(tree, root(tree));

	cout << endl << "The value of the parse tree: " << calculatingValueOfTheTree(root(tree)) << endl;

	deleteParseTree(tree);

	return 0;
}