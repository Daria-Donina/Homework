#include <stdio.h>
#include "interface.h"
#include "list.h"
#include "test.h"


int main()
{
	testPrint();
	List *list = createList();
	userInterface(list);
	deleteList(list);
	return 0;
}