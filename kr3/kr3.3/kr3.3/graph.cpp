#include <vector>
#include <fstream>
#include "graph.h"

using namespace std;

struct Node
{
	vector<int> edges{};
};

struct Graph
{
	vector<Node*> nodes{};
};

Graph *createGraph(int numberOfNodes, int numberOfEdges)
{
	auto graph = new Graph{};
	graph->nodes.resize(numberOfNodes);
	for (int i = 0; i < numberOfNodes; ++i)
	{
		graph->nodes[i] = new Node{};
		graph->nodes[i]->edges.resize(numberOfEdges);
	}
	return graph;
}

Graph *add(ifstream &file)
{
	int numberOfNodes = 0;
	file >> numberOfNodes;

	int numberOfEdges = 0;
	file >> numberOfEdges;

	auto graph = createGraph(numberOfNodes, numberOfEdges);

	for (int i = 0; i < graph->nodes.size(); ++i)
	{
		for (int j = 0; j < graph->nodes[i]->edges.size(); ++j)
		{
			int number = 0;
			file >> number;
			graph->nodes[i]->edges[j] = number;
		}
	}
	return graph;
}

bool searchAvailibleFromEverywhere(Graph *graph, int nodeNumber)
{
	for (int i = 0; i < graph->nodes.size(); ++i)
	{
		for (int j = 0; j < graph->nodes[i]->edges.size(); ++j)
		{
			if (graph->nodes[i]->edges[j] == 1)
			{
				i = j;
				break;
			}
			if (i == nodeNumber)
			{
				break;
			}
		}
	}
	return true;
}

void deleteGraph(Graph *graph)
{
	delete graph;
}