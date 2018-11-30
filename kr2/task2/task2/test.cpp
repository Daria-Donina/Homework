#define _CRT_SECURE_NO_WARNINGS
#include "list.h"
#include "test.h"
#include <stdio.h>

bool test(List *list, FILE * test)
{
	add(list, test);
	if (isSymmetry(list))
	{
		return true;
	}
	return false;
}