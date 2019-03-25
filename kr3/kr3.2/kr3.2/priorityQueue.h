#pragma once
#include <string>

struct PriorityQueue;

struct Node;

PriorityQueue *createQueue();

bool isEmpty(PriorityQueue *queue);

void enqueue(PriorityQueue *queue, int priority, std::string value);

std::string dequeue(PriorityQueue *queue);

void deleteQueue(PriorityQueue *queue);