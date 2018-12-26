#include "priorityQueue.h"

using namespace std;

struct Node
{
	int vertex = 0;
	int key = 0;
	int adjacentVertex = 0;
	Node *next{};
};

struct PriorityQueue
{
	Node *head{};
};

PriorityQueue *createQueue()
{
	return new PriorityQueue{ nullptr };
}

bool isEmpty(PriorityQueue *queue)
{
	return !queue->head;
}

void enqueue(PriorityQueue *queue, int vertex, int key, int adjacentVertex)
{
	if (isEmpty(queue))
	{
		queue->head = new Node{ vertex, key, adjacentVertex };
		return;
	}

	if (queue->head->key > key)
	{
		auto temp = queue->head;
		queue->head = new Node{ vertex, key, adjacentVertex, temp };
		return;
	}

	auto previous = queue->head;
	auto current = previous->next;

	if (!current)
	{
		previous->next = new Node{ vertex, key, adjacentVertex };
		return;
	}

	while (current && key >= current->key)
	{
		previous = current;
		current = current->next;
	}
	
	if (current)
	{
		previous->next = new Node{ vertex, key, adjacentVertex, current };
	}
	else
	{
		previous->next = new Node{ vertex, key, adjacentVertex };
	}
}

Node* dequeue(PriorityQueue *queue)
{
	if (isEmpty(queue))
	{
		return nullptr;
	}

	auto temp = queue->head;
	queue->head = temp->next;
	return temp;
}

void deleteNode(PriorityQueue *queue, int vertex, int adjacentVertex)
{
	if (isEmpty(queue))
	{
		return;
	}

	if (queue->head->vertex == vertex && queue->head->adjacentVertex == adjacentVertex
		|| queue->head->vertex == adjacentVertex && queue->head->adjacentVertex == vertex)
	{
		auto temp = queue->head;
		queue->head = queue->head->next;
		delete temp;
		return;
	}

	auto previous = queue->head;
	auto current = previous->next;
	while ((current && (vertex != current->vertex || adjacentVertex != current->adjacentVertex))
		&& (current && (adjacentVertex != current->vertex || vertex != current->adjacentVertex)))
	{
		previous = current;
		current = current->next;
	}

	if (!current)
	{
		return;
	}
	previous->next = current->next;
	delete current;
}

int vertex(Node *node)
{
	return node->vertex;
}

int	edgeWeight(Node *node)
{
	return node->key;
}

int newVertex(Node *node)
{
	return node->adjacentVertex;
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