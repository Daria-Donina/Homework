#include "test.h"
#include "hashtable.h"
#include <iostream>

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