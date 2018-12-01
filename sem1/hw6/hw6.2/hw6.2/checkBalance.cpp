#include <string>
#include "checkBalance.h"
#include "stack.h"

bool checkCorrectness(Stack *stack, char opening)
{
	if (pop(stack) != opening)
	{
		deleteStack(stack);
		return false;
	}
	return true;
}

bool isBalanced(std::string str)
{
	Stack *stack = createStack();
	for (int i = 0; i < str.length(); ++i)
	{
		if (str[i] == '(' || str[i] == '[' || str[i] == '{')
		{
			push(stack, str[i]);
		}
		else if (str[i] == ')')
		{
			if (!checkCorrectness(stack, '('))
			{
				return false;
			}
		}
		else if (str[i] == '}')
		{
			if (!checkCorrectness(stack, '{'))
			{
				return false;
			}
		}
		else if (str[i] == ']')
		{
			if (!checkCorrectness(stack, '['))
			{
				return false;
			}
		}
	}
	deleteStack(stack);
	return true;
}