#include "test.h"
#include "stack.h"
#include "resultCounting.h"

bool test()
{
	Stack *stack1 = createStack();
	Stack *stack2 = createStack();
	if (result(stack1, "7 6 - 4 5 / +") != 1 || result(stack2, "56+23*-98--") != 4)
	{
		deleteStack(stack1);
		deleteStack(stack2);
		return false;
	}
	deleteStack(stack1);
	deleteStack(stack2);
	return true;
}