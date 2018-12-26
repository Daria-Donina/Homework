#include "PrimAlgorithm.h"
#include <iostream>

using namespace std;

int main()
{
	if (programTest())
	{
		cout << "Tests passed :)" << endl << endl;
	}
	else
	{
		cout << "Tests failed :(" << endl << endl;
	}

	ifstream input("input.txt");
	auto graph = createGraph(input);
	input.close();

	auto minimumSpanningTree = createSpanningTree(graph, 0);

	printGraph(minimumSpanningTree);

	deleteGraph(graph);
	deleteGraph(minimumSpanningTree);

	return 0;
}

