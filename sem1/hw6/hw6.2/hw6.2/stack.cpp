#include "stack.h"

Stack *createStack()
{
	return new Stack{ nullptr };
}


void push(Stack *stack, char element)
{
	auto newElement = new StackElement{ element, stack->head };
	stack->head = newElement;
}

char pop(Stack *stack)
{
	auto temp = stack->head;
	char element = stack->head->data;
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