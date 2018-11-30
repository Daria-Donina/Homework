#include <iostream>
#include <string>
#include "stack.h"
#include "resultCounting.h"
#include "test.h"

using namespace std;

int main()
{
	if (test())
	{
		cout << "Tests passed" << endl;
	}
	else
	{
		cout << "Tests failed" << endl;
	}
	Stack *stack = createStack();
	cout << "Enter postfix expression: ";
	string expression = "";
	getline(cin, expression);
	int expressionResult = result(stack, expression);
	if (expressionResult >= 100000)
	{
		cout << "The expression is not correct" << endl;
	}
	else
	{
		cout << "The result of the expression is: " << expressionResult << endl;
	}
	deleteStack(stack);
	return 0;
}

