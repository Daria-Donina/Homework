#include "priorityQueue.h"
#include <string>

using namespace std;

struct Node
{
	int priority = 0;
	std::string value = 0;
	Node *next{};
};

struct PriorityQueue
{
	Node *head{};
	Node *tail{};
};

PriorityQueue *createQueue()
{
	return new PriorityQueue{ nullptr };
}

bool isEmpty(PriorityQueue *queue)
{
	return !queue->head;
}

void enqueue(PriorityQueue *queue, int priority, string value)
{
	if (isEmpty(queue))
	{
		queue->head = new Node{ priority, value };
		queue->tail = queue->head;
		return;
	}

	queue->tail->next = new Node{ priority, value };
	queue->tail = queue->tail->next;
}

Node *searchMax(PriorityQueue *queue)
{
	auto node = queue->head;
	auto maxPriority = queue->head;
	while (node)
	{
		if (node->priority > maxPriority->priority)
		{
			maxPriority = node;
		}
		node = node->next;
	}
	return maxPriority;
}

string dequeue(PriorityQueue *queue)
{
	if (isEmpty(queue))
	{
		return "-1";
	}

	auto maxPriority = searchMax(queue);

	if (maxPriority == queue->head)
	{
		queue->head = maxPriority->next;
		string temp = maxPriority->value;
		delete maxPriority;
		return temp;
	}

	auto node = queue->head;
	auto prev = node;

	while (node)
	{
		if (node == maxPriority)
		{
			break;
		}
		prev = node;
		node = node->next;
	}

	if (maxPriority != queue->tail)
	{
		prev->next = node->next;
	}
	else
	{
		prev->next = nullptr;
		queue->tail = prev;
	}

	string temp = node->value;
	delete node;
	return temp;
}

void deleteQueue(PriorityQueue *queue)
{
	if (queue->head)
	{
		Node *current = queue->head;
		while (current)
		{
			Node *temp = current;
			current = current->next;
			delete temp;
		}
	}
	delete queue;
}
