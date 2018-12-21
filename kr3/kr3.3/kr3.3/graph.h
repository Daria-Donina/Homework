#pragma once
#include <fstream>

struct Node;

struct Graph;

Graph *add(std::ifstream &file);

bool searchOne(Graph *graph, int nodeNumber, int nodeCheckNumber);

void deleteGraph(Graph *graph);
