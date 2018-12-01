#pragma once

struct StackElement
{
	char data = 0;
	StackElement *next = nullptr;
};

struct Stack
{
	StackElement *head;
};

Stack *createStack();

void push(Stack *stack, char element);

char pop(Stack *stack);

void deleteStack(Stack *stack);
