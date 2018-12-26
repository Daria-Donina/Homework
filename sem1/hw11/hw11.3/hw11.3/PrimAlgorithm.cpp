#include "PrimAlgorithm.h"
#include "priorityQueue.h"
#include <vector>
#include <iostream>
#include <fstream>

using namespace std;

struct Vertex
{
	vector<int> adjacentVertices{};
};

struct Graph
{
	vector<Vertex*> vertices{};
};

Graph* createGraph(ifstream &input)
{
	auto graph = new Graph;
	
	int numberOfVertices = 0;
	input >> numberOfVertices;

	graph->vertices.resize(numberOfVertices);
	for (int i = 0; i < numberOfVertices; ++i)
	{
		graph->vertices[i] = new Vertex{};
		graph->vertices[i]->adjacentVertices.resize(numberOfVertices);
		for (int j = 0; j < numberOfVertices; ++j)
		{
			int number = 0;
			input >> number;
			graph->vertices[i]->adjacentVertices[j] = number;
		}
	}

	return graph;
}

Graph *createEmptyGraph(Graph *graph)
{
	auto newGraph = new Graph;
	newGraph->vertices.resize(graph->vertices.size());

	for (int i = 0; i < newGraph->vertices.size(); ++i)
	{
		newGraph->vertices[i] = new Vertex{};
		newGraph->vertices[i]->adjacentVertices.resize(graph->vertices.size());
	}

	return newGraph;
}

void deleteEdgesThatNotNeededFromQueue(Graph *graph, PriorityQueue *queue, int vertex, vector<bool> visited)
{
	for (int j = 0; j < graph->vertices[vertex]->adjacentVertices.size(); ++j)
	{
		if (graph->vertices[vertex]->adjacentVertices[j] && visited[j])
		{
			deleteNode(queue, vertex, j);
		}
	}
}

void addAdjacentVertices(Graph *graph, Graph *spanningTree, PriorityQueue *queue, int vertex, vector<bool> visited)
{
	for (int j = 0; j < graph->vertices[vertex]->adjacentVertices.size(); ++j)
	{
		if (graph->vertices[vertex]->adjacentVertices[j] && !visited[j])
		{
			enqueue(queue, vertex, graph->vertices[vertex]->adjacentVertices[j], j);
		}
	}
}

void addEdge(Graph *graph, int numberOfFirstVertex, int numberOfSecondVertex, int edgeWeight)
{
	graph->vertices[numberOfFirstVertex]->adjacentVertices[numberOfSecondVertex] = edgeWeight;
	graph->vertices[numberOfSecondVertex]->adjacentVertices[numberOfFirstVertex] = edgeWeight;
}

Graph* createSpanningTree(Graph *graph, int startVertex)
{
	auto spanningTree = createEmptyGraph(graph);

	auto queue = createQueue();

	vector<bool> visited(graph->vertices.size());

	int vertexToAdd = startVertex;
	addAdjacentVertices(graph, spanningTree, queue, startVertex, visited);

	while (!isEmpty(queue))
	{
		if (vertexToAdd != startVertex)
		{
			addAdjacentVertices(graph, spanningTree, queue, vertexToAdd, visited);
		}

		deleteEdgesThatNotNeededFromQueue(graph, queue, vertexToAdd, visited);

		if (isEmpty(queue))
		{
			deleteQueue(queue);
			return spanningTree;
		}

		auto node = dequeue(queue);

		int newVertexToAdd = newVertex(node);
		addEdge(spanningTree, vertex(node), newVertexToAdd, edgeWeight(node));
		delete node;

		visited[vertexToAdd] = true;
		vertexToAdd = newVertexToAdd;
	}

	deleteQueue(queue);
	return spanningTree;
}

void printGraph(Graph *graph)
{
	cout << "Minimum spanning tree of the graph: " << endl;
	for (int i = 0; i < graph->vertices.size(); ++i)
	{
		for (int j = 0; j < graph->vertices[i]->adjacentVertices.size(); ++j)
		{
			cout << graph->vertices[i]->adjacentVertices[j] << " ";
		}
		cout << endl;
	}
}

void deleteGraph(Graph *graph)
{
	for (int i = 0; i < graph->vertices.size(); ++i)
	{
		delete graph->vertices[i];
	}
	delete graph;
}

bool programTest()
{
	ifstream inputTest("test.txt");
	auto testGraph = createGraph(inputTest);
	inputTest.close();

	auto minimumSpanningTreeTest = createSpanningTree(testGraph, 3);

	if (minimumSpanningTreeTest->vertices[1]->adjacentVertices[0] != 7 ||
		minimumSpanningTreeTest->vertices[3]->adjacentVertices[0] != 5 ||
		minimumSpanningTreeTest->vertices[4]->adjacentVertices[1] != 7 ||
		minimumSpanningTreeTest->vertices[4]->adjacentVertices[2] != 5 ||
		minimumSpanningTreeTest->vertices[5]->adjacentVertices[3] != 6 ||
		minimumSpanningTreeTest->vertices[6]->adjacentVertices[4] != 9 ||
		minimumSpanningTreeTest->vertices[4]->adjacentVertices[5] == 8 ||
		minimumSpanningTreeTest->vertices[3]->adjacentVertices[4] == 15)
	{
		deleteGraph(testGraph);
		deleteGraph(minimumSpanningTreeTest);
		return false;
	}

	deleteGraph(testGraph);
	deleteGraph(minimumSpanningTreeTest);
	return true;
}

void test()
{
	if (programTest())
	{
		cout << "Tests passed :)" << endl;
	}
	else
	{
		cout << "Tests failed :(" << endl;
	}
}