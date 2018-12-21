#include "graph.h"
#include <iostream>
#include <fstream>

using namespace std;

int main()
{
	ifstream input("input.txt");

	auto graph = add(input);

	searchAvailibleFromEverywhere(graph, 1);

	input.close();

	return 0;
}