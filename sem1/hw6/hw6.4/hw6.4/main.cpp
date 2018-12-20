#include <iostream>
#include <fstream>
#include "list.h" 
#include "mergeSort.h"
#include "test.h"

using namespace std;

void printPhonebook(List *list)
{
	ListElement *current = getHead(list);
	while (current != nullptr)
	{
		cout << getName(current) << " - " << getNumber(current) << endl;
		current = getNext(current);
	}
}

int main()
{
	testPrintResults();

	ifstream phonebook("phonebook.txt");
	if (!phonebook)
	{
		cout << "There is no file";
		return -1;
	}

	cout << "Enter number:" << endl;
	cout << "1 - sort by name" << endl;
	cout << "2 - sort by phone number" << endl;

	int number = 0;
	cin >> number;

	List *list = createList();
	pushFromFile(list, phonebook);
	phonebook.close();

	if (number == 1 || number == 2)
	{
		mergeSort(list, number);
	}
	else
	{
		deleteList(list);
		return -1;
	}

	cout << endl;
	cout << "Sorted phonebook:" << endl;
	printPhonebook(list);
	
	deleteList(list);
	return 0;
}