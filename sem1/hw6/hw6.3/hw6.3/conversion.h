#pragma once
#include <string>
#include "stack.h"

//Converts expression from infix to postfix form
std::string infixToPostfix(Stack *stack, const std::string &expression);
