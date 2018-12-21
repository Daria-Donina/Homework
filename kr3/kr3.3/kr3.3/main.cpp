#include "graph.h"
#include <iostream>
#include <fstream>

using namespace std;

int main()
{
	ifstream input("input.txt");

	auto graph = add(input);

	searchOne(graph, 3, 0);

	input.close();

	return 0;
}