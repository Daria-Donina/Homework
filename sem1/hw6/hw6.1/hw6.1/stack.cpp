#include "stack.h"

struct StackElement
{
	int data = 0;
	StackElement *next = nullptr;
};

struct Stack
{
	StackElement *head;
};

Stack *createStack()
{
	return new Stack{ nullptr };
}

int top(Stack *stack)
{
	return stack->head->data;
}

bool isNotOneElement(Stack *stack)
{
	return stack->head->next != nullptr;
}

void push(Stack *stack, int element)
{
	auto newElement = new StackElement{ element, stack->head };
	stack->head = newElement;
}

int pop(Stack *stack)
{
	auto temp = stack->head;
	int element = stack->head->data;
	stack->head = stack->head->next;
	delete temp;
	return element;
}

bool isEmpty(Stack *stack)
{
	return stack->head == nullptr;
}

void deleteStack(Stack *stack)
{
	while (!isEmpty(stack))
	{
		auto temp = stack->head;
		stack->head = temp->next;
		delete temp;
	}
	delete stack;
}