#include "interface.h"
#include "map.h"
#include <iostream>
#include <string>

using namespace std;

void userInterface(Map *map)
{
	int number = -1;
	while (number != 0)
	{
		cout << "Input number:" << endl;
		cout << "0 - exit" << endl;
		cout << "1 - add value to the map by the key" << endl;
		cout << "2 - delete value from the map" << endl;
		cout << "3 - check if the key is in the map" << endl;
		cout << "4 - get the value by the key" << endl;
		cin >> number;
		string key = "";
		string value = "";
		switch (number)
		{
		case 1:
			cout << "Enter value to be added" << endl;
			cin >> value;
			cout << "Enter key" << endl;
			cin >> key;
			insert(map, key, value);
			break;
		case 2:
			cout << "Enter key" << endl;
			cin >> key;
			remove(map, key);
			break;
		case 3:
			cout << "Enter key to check" << endl;
			cin >> key;
			keyAvailability(map, key);
			break;
		case 4:
			cout << "Enter key" << endl;
			cin >> key;
			cout <<  "Value: " << find(map, key);
			break;
		}
		cout << endl;
	}
}