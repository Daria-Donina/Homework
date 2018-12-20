#include "interface.h"
#include "list.h"
#include "test.h"

int main()
{
	test();

	List *list = createList();

	userInterface(list);

	deleteList(list);
	return 0;
}