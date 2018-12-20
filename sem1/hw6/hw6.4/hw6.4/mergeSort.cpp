#include <string>
#include "mergeSort.h"
#include "list.h"

std::string typeOfSort (ListElement *node, int number)
{
	if (number == 1)
	{
		return getName(node);
	}
	else
	{
		return getNumber(node);
	}
}

int min(int a, int b)
{
	if (a > b)
	{
		return b;
	}
	else
	{
		return a;
	}
}

void swap(Record &record1, Record &record2)
{
	Record temp = record1;
	record1 = record2;
	record2 = temp;
}

void split(List *list, List *leftList, List *rightList)
{
	const int middleNumber = getLength(list) / 2;
	ListElement *current = getHead(list);
	for (int i = 1; i <= getLength(list); ++i)
	{
		if (i <= middleNumber)
		{
			push(leftList, getRecord(current));
		}
		else
		{
			push(rightList, getRecord(current));
		}
		current = getNext(current);
	}
}

void merge(List *list, List *leftList, List *rightList, int number)
{
	ListElement *currentLeft = getHead(leftList);
	ListElement *currentRight = getHead(rightList);

	deleteElements(list);
	
	while (currentLeft != nullptr && currentRight != nullptr)
	{
		std::string typeLeft = typeOfSort(currentLeft, number);
		std::string typeRight = typeOfSort(currentRight, number);

		int i = 0;

		for (i = 0; i < min(typeLeft.length(), typeRight.length()); ++i)
		{
			if (typeLeft[i] > typeRight[i])
			{
				push(list, getRecord(currentRight));
				currentRight = getNext(currentRight);
				break;
			}
			else if (typeLeft[i] < typeRight[i])
			{
				push(list, getRecord(currentLeft));
				currentLeft = getNext(currentLeft);
				break;
			}
		}

		if (i == min(typeLeft.length(), typeRight.length()))
		{
			if (typeLeft.length() < typeRight.length())
			{
				push(list, getRecord(currentLeft));
				currentLeft = getNext(currentLeft);
			}
			else
			{
				push(list, getRecord(currentRight));
				currentRight = getNext(currentRight);
			}
		}
	}

	if (currentLeft)
	{
		while (currentLeft != nullptr)
		{
			push(list, getRecord(currentLeft));
			currentLeft = getNext(currentLeft);
		}
	}

	if (currentRight)
	{
		while (currentRight != nullptr)
		{
			push(list, getRecord(currentRight));
			currentRight = getNext(currentRight);
		}
	}
}

void mergeSort(List *list, int number)
{
	if (getLength(list) == 1)
	{
		return;
	}
	List *leftList = createList();
	List *rightList = createList();

	split(list, leftList, rightList);

	mergeSort(leftList, number);
	mergeSort(rightList, number);

	merge(list, leftList, rightList, number);

	deleteList(leftList);
	deleteList(rightList);
}
