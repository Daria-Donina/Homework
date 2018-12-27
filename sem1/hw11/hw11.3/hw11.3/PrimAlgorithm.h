#pragma once
#include <fstream>

struct Graph;

// Create new graph
Graph* createGraph(std::ifstream &input);

// Create minimum spanning tree
Graph* createSpanningTree(Graph *graph, int startVertex);

// Print graph
void printGraph(Graph *graph);

// Remove graph
void deleteGraph(Graph *graph);


// Test the program
bool programTest();
