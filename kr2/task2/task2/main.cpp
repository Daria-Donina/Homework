#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "list.h"
#include "test.h"

int main()
{
	List *list1 = createList();
	FILE * test1 = fopen("test1.txt", "r");

	List *list2 = createList();
	FILE * test2 = fopen("test2.txt", "r");

	if (!test(list1, test1) && test(list2, test2))
	{
		printf("Tests passed\n\n");
	}
	else
	{
		printf("Tests failed\n\n");
	}

	fclose(test1);
	fclose(test2);

	deleteList(list1);
	deleteList(list2);

	FILE * file = fopen("input_data.txt", "r");

	if (!file)
	{
		return -1;
	}

	List *list = createList();

	add(list, file);
	if (isSymmetry(list))
	{
		printf("List has a symmetry\n");
	}
	else
	{
		printf("List doesn't have a symmetry\n");
	}
	deleteList(list);
	fclose(file);
	return 0;
}