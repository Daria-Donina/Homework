#include "graph.h"
#include "list.h"
#include <vector>
#include <iostream>
#include <fstream>
#include <string>

using namespace std;

struct Node
{
	int numberOfState = 0;
	List* roads{};
};

struct Graph
{
	int numberOfStates = 0;
	vector<Node*> cities{};
};

Graph *createGraph(const int numberOfCities)
{
	Graph *graph = new Graph;
	graph->cities.resize(numberOfCities + 1);
	for (int i = 1; i <= numberOfCities; ++i)
	{
		graph->cities[i] = new Node{};
		graph->cities[i]->roads = createList();
	}
	return graph;
}

bool isFree(Graph *graph, int numberOfCity)
{
	return graph->cities[numberOfCity]->numberOfState == 0;
}

bool areFreeNeighbours(Graph *graph, Node *city)
{
	auto node = head(city->roads);
	while (node)
	{
		if (graph->cities[numberOfCity(node)]->numberOfState == 0)
		{
			return true;
		}
		node = next(node);
	}
	return false;
}

bool areFreeCities(Graph *graph)
{
	for (int i = 1; i < graph->cities.size(); ++i)
	{
		if (graph->cities[i]->numberOfState == 0)
		{
			return true;
		}
	}
	return false;
}

int choosingClosest(Graph *graph, int numberOfState)
{
	ListNode *minimum = createMinimum();
	auto temp = minimum;
	for (int i = 1; i < graph->cities.size(); ++i)
	{
		if (graph->cities[i]->numberOfState == numberOfState && areFreeNeighbours(graph, graph->cities[i]))
		{
			auto node = head(graph->cities[i]->roads);
			while (node)
			{
				if (isFree(graph, numberOfCity(node)))
				{
					if (length(node) < length(minimum))
					{
						minimum = node;
					}
				}
				node = next(node);
			}
		}
	}
	if (length(minimum) == 10000000)
	{
		deleteNode(temp);
		return 0;
	}
	deleteNode(temp);
	return numberOfCity(minimum);
}

Graph *addCitiesAndRoads(ifstream &inputData)
{
	int numberOfCities = 0;
	inputData >> numberOfCities;
	auto graph = createGraph(numberOfCities);

	int numberOfRoads = 0;
	inputData >> numberOfRoads;

	for (int i = 1; i <= numberOfRoads; ++i)
	{
		int numberOfFirstCity = 0;
		inputData >> numberOfFirstCity;

		int numberOfSecondCity = 0;
		inputData >> numberOfSecondCity;

		int length = 0;
		inputData >> length;

		auto firstList = graph->cities[numberOfFirstCity]->roads;
		auto secondList = graph->cities[numberOfSecondCity]->roads;
		add(firstList, numberOfSecondCity, length);
		add(secondList, numberOfFirstCity, length);
	}

	int numberOfCapitals = 0;
	inputData >> numberOfCapitals;
	
	graph->numberOfStates = numberOfCapitals;
	for (int i = 1; i <= numberOfCapitals; ++i)
	{
		int numberOfCapital = 0;
		inputData >> numberOfCapital;
		graph->cities[numberOfCapital]->numberOfState = i;
	}
	return graph;
}

void takeOverACity(Graph *graph, int numberOfState)
{
	const int numberOfCityToTakeOver = choosingClosest(graph, numberOfState);
	if (numberOfCityToTakeOver != 0)
	{
		graph->cities[numberOfCityToTakeOver]->numberOfState = numberOfState;
	}
}

void stateFormation(Graph *graph)
{
	while (areFreeCities(graph))
	{
		for (int i = 1; i <= graph->numberOfStates; ++i)
		{
			takeOverACity(graph, i);
		}
	}
}

void printGraph(Graph *graph)
{
	for (int i = 1; i <= graph->numberOfStates; ++i)
	{
		cout << "State " << i << ": ";
		for (int j = 1; j < graph->cities.size(); ++j)
		{
			if (graph->cities[j]->numberOfState == i)
			{
				cout << j << " ";
			}
		}
		cout << endl;
	}
}

void deleteGraph(Graph *graph)
{
	for (int i = 1; i < graph->cities.size(); ++i)
	{
		auto list = graph->cities[i]->roads;
		deleteList(list);
		delete graph->cities[i];
	}

	delete graph;
}

bool programTest()
{
	ifstream testData("test.txt");
	if (!testData)
	{
		return false;
	}
	auto testGraph = addCitiesAndRoads(testData);
	testData.close();

	if (!find(testGraph->cities[5]->roads, 4) || !find(testGraph->cities[4]->roads, 6) || find(testGraph->cities[3]->roads, 1))
	{
		deleteGraph(testGraph);
		return false;
	}

	stateFormation(testGraph);

	if (testGraph->cities[3]->numberOfState != 2 || testGraph->cities[1]->numberOfState != 2 ||
		testGraph->cities[5]->numberOfState != 2 || testGraph->cities[4]->numberOfState != 2)
	{
		deleteGraph(testGraph);
		return false;
	}

	if (testGraph->cities[2]->numberOfState != 1 || testGraph->cities[6]->numberOfState != 1 ||
		testGraph->cities[8]->numberOfState != 1 || testGraph->cities[7]->numberOfState != 1)
	{
		deleteGraph(testGraph);
		return false;
	}

	deleteGraph(testGraph);
	return true;
}