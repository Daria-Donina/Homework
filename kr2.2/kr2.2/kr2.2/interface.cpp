#include <iostream>
#include <vector>
#include "interface.h"
#include "list.h"

using namespace std;

void userInterface(List *list)
{
	int number = -1;
	while (number != 0)
	{
		cout << "Input number:" << endl;
		cout << "0 - exit" << endl;
		cout << "1 - add value on a certain position of the list" << endl;
		cout << "2 - remove value from a certain position of the list" << endl;
		cout << "3 - print list" << endl;
		cin >> number;
		int value = 0;
		int position = 0;
		switch (number)
		{
		case 1:
			cout << "Enter value to be added" << endl;
			cin >> value;
			cout << "Enter position" << endl;
			cin >> position;
			add(list, value, position);
			break;
		case 2:
			cout << "Enter position" << endl;
			cin >> position;
			remove(list, position);
			break;
		case 3:
			cout << "List: " << endl;
			printList(list);
			break;
		}
		cout << endl;
	}
}