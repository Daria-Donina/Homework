#include <iostream>
#include <fstream>
#include "test.h"
#include "graph.h"

void test()
{
	if (programTest())
	{
		std::cout << "Tests passed :)" << std::endl;
	}
	else
	{
		std::cout << "Tests failed :(" << std::endl;
	}
}
