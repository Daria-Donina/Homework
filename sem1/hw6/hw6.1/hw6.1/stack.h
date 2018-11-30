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

Stack *createStack();

void push(Stack *stack, int element);

int getElement(Stack *stack);

void deleteStack(Stack *stack);