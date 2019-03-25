#include <fstream>
#include <iostream>
#include "list.h"

using namespace std;

bool test()
{
	List *testList = createList();

	ifstream testInput("test.txt");
	add(testInput, testList);
	testInput.close();

	int dataFromFile[5] = { 1, 3, 6, 7, 9 };

	auto current = testList->head;
	for (int i = 0; i < 5; ++i)
	{
		if (current->value != dataFromFile[i])
		{
			deleteList(testList);
			return false;
		}
		current = current->next;
	}

	reverseList(testList);

	current = testList->head;
	for (int i = 4; i >= 0; --i)
	{
		if (current->value != dataFromFile[i])
		{
			deleteList(testList);
			return false;
		}
		current = current->next;
	}

	deleteList(testList);
	return true;
}

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

	List *list = createList();

	ifstream inputData("input.txt");

	add(inputData, list);

	inputData.close();

	print(list);

	reverseList(list);

	print(list);

	deleteList(list);

	return 0;
}