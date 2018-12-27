#include "interface.h"
#include "map.h"
#include "test.h"

int main()
{
	test();

	Map *map = createMap();

	userInterface(map);

	deleteMap(map);

	return 0;
}