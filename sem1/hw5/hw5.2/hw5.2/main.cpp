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

	CyclicList *cyclicList = createCyclicList();

	int n = 0;
	cout << "Enter the number of warriors: ";
	cin >> n;
	addWarriors(cyclicList, n);
	int m = 0;
	cout << "Enter the number of warrior to be killed each time: ";
	cin >> m;
	cout << "The number of the last alive warrior: " << killing(cyclicList, m) << endl;

	delete cyclicList->head;
	delete cyclicList;

	return 0;
}

int test(int n, int m)
{
	CyclicList *cyclicList = createCyclicList();
	addWarriors(cyclicList, n);
	int position = killing(cyclicList, m);
	delete cyclicList->head;
	delete cyclicList;
	return position;
}