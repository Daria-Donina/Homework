#include "graph.h"
#include <iostream>
#include <fstream>

using namespace std;

int main()
{
	ifstream input("input.txt");

	add(input);

	input.close();

	return 0;
}