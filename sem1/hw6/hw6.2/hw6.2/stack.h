#pragma once

struct StackElement
{
	int data = 0;
	StackElement *next = nullptr;
};

struct Stack
{
	StackElement *head;
};

//Creates stack
Stack *createStack();

//Adds element to stack
void push(Stack *stack, int element);

//Removes element from stack
int pop(Stack *stack);

// Check if stack is empty
bool isEmpty(Stack *stack);

//Removes stack
void deleteStack(Stack *stack);