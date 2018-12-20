#include <vector>
#include <iostream>
#include "test.h"
#include "stack.h"
#include "conversion.h"

bool test(std::string infixTest, const char *postfixTest, int lengthOfPostfix)
{
	Stack *stack = createStack();
	//char testArray[50]{};
	//for (int i = 0; i <= lengthOfPostfix; ++i)
	//{
	//	testArray[i] = postfixTest[i];
	//}
	//std::string testVector = postfixTest;
	//testVector.assign(&testArray[0], &testArray[0] + lengthOfPostfix);
	if (infixToPostfix(stack, infixTest) == postfixTest)
	{
		deleteStack(stack);
		return true;
	}
	deleteStack(stack);
	return false;
}

void testPrintResults()
{
	if (!test("(1+1)*2", "11+2*", 5))
	{
		std::cout << "Test 1 failed" << std::endl;
		return;
	}
	if (!test("3-8*3-4", "383*-4-", 7))
	{
		std::cout << "Test 2 failed" << std::endl;
		return;
	}
	if (!test("9/3-(6+7)*6-8+7", "93/67+6*-8-7+", 13))
	{
		std::cout << "Test 3 failed" << std::endl;
		return;
	}
	std::cout << "Tests passed" << std::endl;
	return;
}