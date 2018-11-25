#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "list.h"
#include "interface.h"

void userInterface(List *list, int number)
{
	while (number != 0)
	{
		printf("Input number:\n");
		printf("0 - exit\n");
		printf("1 - add value to sorted list\n");
		printf("2 - delete value from the list\n");
		printf("3 - print the list\n");
		scanf("%d", &number);
		int value = 0;
		switch (number)
		{
		case 1:
			printf("Enter value to be added\n");
			scanf("%d", &value);
			push(list, value);
			printf("Value has been added\n\n");
			break;
		case 2:
			printf("Enter value to be deleted\n");
			scanf("%d", &value);
			pop(list, value);
			break;
		case 3:
			print(list);
			printf("\n");
			break;
		}
	}
}