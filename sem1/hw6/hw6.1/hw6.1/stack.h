#pragma once

struct StackElement;

struct Stack;

//Creates stack
Stack *createStack();

//Adds element to stack
void push(Stack *stack, int element);

//Removes element from stack
int pop(Stack *stack);

//Check if stack has only one element
bool isNotOneElement(Stack *stack);

//Top of the stack
int top(Stack *stack);

//Removes stack
void deleteStack(Stack *stack);