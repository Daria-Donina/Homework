#include "interface.h"
#include "set.h"
#include "test.h"


int main()
{
	printTest();

	Set *tree = createSet();

	userInterface(tree);

	deleteSet(tree);

	return 0;
}