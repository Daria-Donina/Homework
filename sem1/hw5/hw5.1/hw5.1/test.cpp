#include <stdio.h>
#include "list.h"
#include "test.h"

bool test()
{
	List *list = createList();
	int testArray[5] = { 1, 6, 3, 5, 8 };
	for (int i = 0; i < 5; ++i)
	{
		push(list, testArray[i]);
	}
	ListElement *current = list->head;
	int testArraySorted[5] = { 1, 3, 5, 6, 8 };
	for (int i = 0; i < 5; ++i)
	{
		if (current->value != testArraySorted[i])
		{
			printf("Function push is not working correctly\n");
			return false;
		}
		current = current->next;
	}
	pop(list, 1);
	pop(list, 8);
	pop(list, 5);
	current = list->head;
	for (int i = 1; i < 4; i += 2)
	{
		if (current->value != testArraySorted[i])
		{
			printf("Function pop is not working correctly\n\n");
			return false;
		}
		if (i == 1)
		{
			current = current->next;
		}
	}
	if (current->next)
	{
		printf("Function pop is not working correctlyn\n");
		return false;
	}
	deleteList(list);
	return true;
}