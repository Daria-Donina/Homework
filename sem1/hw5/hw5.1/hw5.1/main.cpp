#include <stdio.h>
#include "interface.h"
#include "list.h"
#include "test.h"


int main()
{
	if (test())
	{
		printf("Tests passed\n\n");
	}
	else
	{
		printf("Tests failed\n\n");
	}
	List *list = createList();
	int number = -1;
	userInterface(list, number);
	deleteList(list);
	return 0;
}