#include <string>
#include <vector>
#include "conversion.h"
#include "stack.h"

std::vector<char> infixToPostfix(Stack *stack, std::string expression)
{
	std::vector <char> postfixForm;
	for (int i = 0; i < expression.length(); ++i)
	{
		if (expression[i] != '+' && expression[i] != '-' && expression[i] != '*' && expression[i] != '/' 
			&& expression[i] != ')')
		{
			if (expression[i] != '(')
			{
				postfixForm.push_back(expression[i]);
			}
			else
			{
				push(stack, expression[i]);
			}
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
				postfixForm[0] = '-';
				return postfixForm;
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