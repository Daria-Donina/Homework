#pragma once
#include <fstream>

struct Node;

struct Graph;

void add(std::ifstream &file);

bool searchAvailibleFromEverywhere(Graph *graph, Node *node, int nodeNumber);
