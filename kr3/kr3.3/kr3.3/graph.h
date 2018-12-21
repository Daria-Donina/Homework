#pragma once
#include <fstream>

struct Node;

struct Graph;

Graph *add(std::ifstream &file);

bool searchAvailibleFromEverywhere(Graph *graph, int nodeNumber);
