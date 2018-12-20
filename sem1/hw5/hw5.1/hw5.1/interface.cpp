#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "list.h"
#include "interface.h"

void userInterface(List *list)
{
	int number = -1;
	while (number != 0)
	{
		printf("Input number:\n");
		printf("0 - exit\n");
		printf("1 - add value to sorted list\n");
		printf("2 - delete value from the list\n");
		printf("3 - print the list\n");
		scanf("%d", &number);
		int value = 0;
		int errorCode = 0;
		switch (number)
		{
		case 1:
			printf("Enter value to be added\n");
			scanf("%d", &value);
			add(list, value);
			printf("Value has been added\n\n");
			break;
		case 2:
			printf("Enter value to be deleted\n");
			scanf("%d", &value);
			errorCode = remove(list, value);
			if (errorCode == 1)
			{
				printf("List has no elements\n\n");
			}
			else if (errorCode == 2)
			{
				printf("There is no such element in the list\n\n");
			}
			else if (errorCode == 0)
			{
				printf("Value has been deleted\n\n");
			}
			break;
		case 3:
			print(list);
			printf("\n");
			break;
		}
	}
}