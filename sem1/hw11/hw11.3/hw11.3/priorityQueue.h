#pragma once

struct PriorityQueue;

struct Node;

// Create new priority queue
PriorityQueue *createQueue();

// Check if the queue is empty
bool isEmpty(PriorityQueue *queue);

// Get number of the vertex
int vertex(Node *node);

// Get weight of the edge
int	edgeWeight(Node *node);

// Get vertex to be added in spanning tree
int newVertex(Node *node);

// Delete node
void simplyDeleteNode(Node *node);

// Add vertex to the queue
void enqueue(PriorityQueue *queue, int vertex, int key, int adjacentVertex);

// Get vertex and new vertex from the queue
Node* dequeue(PriorityQueue *queue);

// Remove edge from the queue
void deleteNode(PriorityQueue *queue, int vertex, int adjacentVertex);

// Remove queue
void deleteQueue(PriorityQueue *queue);
