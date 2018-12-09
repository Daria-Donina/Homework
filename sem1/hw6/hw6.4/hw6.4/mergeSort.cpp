#include <string>
#include "mergeSort.h"
#include "list.h"

std::string typeOfSort (ListElement *node, int number)
{
	if (number == 1)
	{
		return node->record.name;
	}
	else
	{
		return node->record.phoneNumber;
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
	const int middleNumber = list->length / 2;
	ListElement *current = list->head;
	for (int i = 1; i <= list->length; ++i)
	{
		if (i <= middleNumber)
		{
			push(leftList, current->record);
		}
		else
		{
			push(rightList, current->record);
		}
		current = current->next;
	}
}

void merge(List *list, List *leftList, List *rightList, int number)
{
	ListElement *currentLeft = leftList->head;
	ListElement *currentRight = rightList->head;

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
				push(list, currentRight->record);
				currentRight = currentRight->next;
				break;
			}
			else if (typeLeft[i] < typeRight[i])
			{
				push(list, currentLeft->record);
				currentLeft = currentLeft->next;
				break;
			}
		}

		if (i == min(typeLeft.length(), typeRight.length()))
		{
			if (typeLeft.length() < typeRight.length())
			{
				push(list, currentLeft->record);
				currentLeft = currentLeft->next;
			}
			else
			{
				push(list, currentRight->record);
				currentRight = currentRight->next;
			}
		}
	}

	if (currentLeft)
	{
		while (currentLeft != nullptr)
		{
			push(list, currentLeft->record);
			currentLeft = currentLeft->next;
		}
	}

	if (currentRight)
	{
		while (currentRight != nullptr)
		{
			push(list, currentRight->record);
			currentRight = currentRight->next;
		}
	}
}

void mergeSort(List *list, int number)
{
	if (list->length == 1)
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
