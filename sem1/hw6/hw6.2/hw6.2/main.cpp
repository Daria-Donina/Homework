#include <iostream>
#include "test.h"

using namespace std;

int main()
{
	if (test())
	{
		cout << "Tests passed" << endl;
	}
	else
	{
		cout << "Tests failed" << endl;
	}
	return 0;
}
