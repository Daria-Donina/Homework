#pragma once
#include <vector>
#include "stack.h"

//Converts expression from infix to postfix form
std::vector<char> infixToPostfix(Stack *stack, std::string expression);
