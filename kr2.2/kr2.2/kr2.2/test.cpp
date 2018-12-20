#include <iostream>
#include "test.h"
#include "list.h"

using namespace std;

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