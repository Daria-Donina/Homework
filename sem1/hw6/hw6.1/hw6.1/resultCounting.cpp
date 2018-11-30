#include "resultCounting.h"
#include "stack.h"
#include <string>
#include <iostream>

using namespace std;

bool isNotOneElement(Stack *stack)
{
	return stack->head->next != nullptr;
}

int result(Stack *stack, string expression)
{
	for (int i = 0; i < expression.length(); ++i)
	{
		if (expression[i] != ' ' && expression[i] != '+' && expression[i] != '-'
			&& expression[i] != '*' && expression[i] != '/')
		{
			push(stack, expression[i] - '0');
		}
		else if (isNotOneElement(stack))
		{
			int tempResult = 0;
			if (expression[i] == '+')
			{
				tempResult = getElement(stack) + getElement(stack);
				push(stack, tempResult);
			}
			else if (expression[i] == '-')
			{
				tempResult = (-getElement(stack) + getElement(stack));
				push(stack, tempResult);
			}
			else if (expression[i] == '*')
			{
				tempResult = getElement(stack) * getElement(stack);
				push(stack, tempResult);
			}
			else if (expression[i] == '/')
			{
				const int divider = getElement(stack);
				tempResult = getElement(stack) / divider;
				push(stack, tempResult);
			}
		}
	}
	if (!isNotOneElement(stack))
	{
		return stack->head->data;
	}
}