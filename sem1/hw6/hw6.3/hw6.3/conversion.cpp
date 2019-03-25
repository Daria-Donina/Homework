#include <string>
#include "conversion.h"
#include "stack.h"

std::string infixToPostfix(Stack *stack, const std::string &expression)
{
	std::string postfixForm;
	for (int i = 0; i < expression.length(); ++i)
	{
		if (isdigit(expression[i]))
		{
				postfixForm.push_back(expression[i]);
		}
		else if (expression[i] == '(')
		{
			push(stack, expression[i]);
		}
		else if (expression[i] == '+' || expression[i] == '-')
		{
			if (stack->head != nullptr)
			{
				while (stack->head != nullptr && stack->head->data != '(')
				{
					postfixForm.push_back(pop(stack));
				}
			}
			push(stack, expression[i]);
		}
		else if (expression[i] == '*' || expression[i] == '/')
		{
			if (stack->head != nullptr)
			{
				while (stack->head != nullptr && stack->head->data != '(' && stack->head->data != '+' &&
					stack->head->data != '-')
				{
					postfixForm.push_back(pop(stack));
				}
			}
			push(stack, expression[i]);
		}
		else if (expression[i] == ')')
		{
			while (stack->head->data != '(' && stack->head != nullptr)
			{
				postfixForm.push_back(pop(stack));
			}
			if (stack->head == nullptr)
			{
				//mistake (no opening bracket)
				return "All is baaaad  :(";
			}
			pop(stack);
		}
	}
	while (stack->head != nullptr)
	{
		postfixForm.push_back(pop(stack));
	}
	return postfixForm;
}