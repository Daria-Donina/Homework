#include <stdio.h>
#include "list.h"
#include "test.h"

void testPrint()
{
	if (test())
	{
		printf("Tests passed\n\n");
	}
	else
	{
		printf("Tests failed\n\n");
	}
}