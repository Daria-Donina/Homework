#include <iostream>
#include <vector>
#include "interface.h"
#include "set.h"

using namespace std;

void resultOfSearch(Set *tree, int value)
{
	if (isInTheSet(tree, value))
	{
		cout << "Value is in the set" << endl;
	}
	else
	{
		cout << "Value is not in the set" << endl;
	}
}

void userInterface(Set *tree)
{
	int number = -1;
	while (number != 0)
	{
		cout << "Input number:" << endl;
		cout << "0 - exit" << endl;
		cout << "1 - add value to the set" << endl;
		cout << "2 - delete value from the set" << endl;
		cout << "3 - check if the value in the set" << endl;
		cout << "4 - print elements of the set in ascending order" << endl;
		cout << "5 - print elements of the set in descending order" << endl;
		cin >> number;
		int value = 0;
		std::vector<int> values;
		switch (number)
		{
		case 1:
			cout << "Enter value to be added" << endl;
			cin >> value;
			add(tree, value);
			break;
		case 2:
			cout << "Enter value to be deleted" << endl;
			cin >> value;
			remove(tree, value);
			break;
		case 3:
			cout << "Enter value to check" << endl;
			cin >> value;
			resultOfSearch(tree, value);
			break;
		case 4:
			infixTraverse(tree, values);
			for (int i = 0; i < values.size(); ++i)
			{
				cout << values[i] << " ";
			}
			break;
		case 5:
			backTraverse(tree, values);
			for (int i = 0; i < values.size(); ++i)
			{
				cout << values[i] << " ";
			}
			break;
		}
		cout << endl;
	}
}