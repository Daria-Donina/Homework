#include "test.h"
#include "checkBalance.h"

bool test()
{
	return (isBalanced("((())[{}{}])") && isBalanced("(11+5)*(7-6)") &&
		!isBalanced("(sf{[vx})ad]d") && !isBalanced("({[]){[{]"));
}