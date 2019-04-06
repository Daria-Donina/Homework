#include "resultCounting.h"
#include "stack.h"
#include <string>
#include <iostream>

using namespace std;

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
			if (expression[i] == '+')
			{
				int tempResult = pop(stack) + pop(stack);
				push(stack, tempResult);
			}
			else if (expression[i] == '-')
			{
				int tempResult = (-pop(stack) + pop(stack));
				push(stack, tempResult);
			}
			else if (expression[i] == '*')
			{
				int tempResult = pop(stack) * pop(stack);
				push(stack, tempResult);
			}
			else if (expression[i] == '/')
			{
				const int divider = pop(stack);
				int tempResult = pop(stack) / divider;
				push(stack, tempResult);
			}
		}
	}
	if (!isNotOneElement(stack))
	{
		return top(stack);
	}
	cout << "The expression is not correct" << endl;
	return -1;
}