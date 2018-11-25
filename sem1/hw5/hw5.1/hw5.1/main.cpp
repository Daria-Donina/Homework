#include <stdio.h>
#include "interface.h"
#include "list.h"


int main()
{
	List *list = createList();
	int number = -1;
	userInterface(list, number);
	deleteList(list);
	return 0;
}