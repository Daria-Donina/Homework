#include "test.h"
#include <string>
#include <iostream>
#include <fstream>
#include "list.h"
#include "mergeSort.h"

bool searchOfMistake(List *testList, int number)
{
	ListElement *prev = getHead(testList);
	ListElement *current = getNext(prev);
	for (int i = 1; i < getLength(testList); ++i)
	{
		std::string typePrev = typeOfSort(prev, number);
		std::string typeCurrent = typeOfSort(current, number);
		for (int i = 0; i < min(typePrev.length(), typeCurrent.length()); ++i)
		{
			if (typePrev[i] > typeCurrent[i])
			{
				return false;
			}
			else if (typePrev[i] < typeCurrent[i])
			{
				break;
			}
		}
		prev = current;
		current = getNext(current);
	}
	return true;
}

bool test()
{
	std::ifstream testPhonebook("test.txt");

	List *testList = createList();

	pushFromFile(testList, testPhonebook);
	testPhonebook.close();

	mergeSort(testList, 1);
	if (!searchOfMistake(testList, 1))
	{
		deleteList(testList);
		return false;
	}
	
	mergeSort(testList, 2);
	if (!searchOfMistake(testList, 2))
	{
		deleteList(testList);
		return false;
	}

	deleteList(testList);
	return true;
}

void testPrintResults()
{
	if (test())
	{
		std::cout << "Tests passed" << std::endl << std::endl;
	}
	else
	{
		std::cout << "Tests failed" << std::endl << std::endl;
	}
}