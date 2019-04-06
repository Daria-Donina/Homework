#include "graph.h"
#include "test.h"
#include <iostream>
#include <fstream>

using namespace std;

int main()
{
	test();

	ifstream inputData("inputData.txt");
	auto graph = addCitiesAndRoads(inputData);
	inputData.close();

	stateFormation(graph);

	printGraph(graph);

	deleteGraph(graph);
	return 0;
}