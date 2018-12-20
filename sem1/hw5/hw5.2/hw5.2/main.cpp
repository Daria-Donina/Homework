#include <iostream>
#include "count.h"
using namespace std;

int test(int n, int m);

int main()
{
	if (test(13, 4) == 5 && test(9, 3) == 1 && test(15, 2) == 15)
	{
		cout << "Tests passed" << endl << endl;
	}
	else
	{
		cout << "Tests failed" << endl << endl;
	}

	int n = 0;
	cout << "Enter the number of warriors: ";
	cin >> n;
	auto cyclicList = addWarriors(n);
	int m = 0;
	cout << "Enter the number of warrior to be killed each time: ";
	cin >> m;
	cout << "The number of the last alive warrior: " << killing(cyclicList, m) << endl;

	
	deleteCyclicList(cyclicList);

	return 0;
}

int test(int n, int m)
{
	auto testList = addWarriors(n);
	int position = killing(testList, m);
	deleteCyclicList(testList);
	return position;
}