#include "graph.h"
#include "list.h"
#include <vector>
#include <iostream>
#include <fstream>
#include <string>

using namespace std;

struct Node
{
	int NumberOfState = 0;
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
	return !graph->cities[numberOfCity]->NumberOfState;
}

bool areFreeNeighbours(Graph *graph, Node *city)
{
	auto node = city->roads->head;
	while (node)
	{
		if (!graph->cities[node->numberOfCity]->NumberOfState)
		{
			return true;
		}
		node = node->next;
	}
	return false;
}

bool areFreeCities(Graph *graph)
{
	for (int i = 1; i < graph->cities.size(); ++i)
	{
		if (!graph->cities[i]->NumberOfState)
		{
			return true;
		}
	}
	return false;
}

int choosingClosest(Graph *graph, int numberOfState)
{
	ListNode *minimum = new ListNode{};
	auto temp = minimum;
	minimum->length = 10000000;
	for (int i = 1; i < graph->cities.size(); ++i)
	{
		if (graph->cities[i]->NumberOfState == numberOfState && areFreeNeighbours(graph, graph->cities[i]))
		{
			auto node = graph->cities[i]->roads->head;;
			while (node)
			{
				if (isFree(graph, node->numberOfCity))
				{
					if (node->length < minimum->length)
					{
						minimum = node;
					}
				}
				node = node->next;
			}
		}
	}
	if (minimum->length == 10000000)
	{
		delete temp;
		return 0;
	}
	delete temp;
	return minimum->numberOfCity;
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
		graph->cities[numberOfCapital]->NumberOfState = i;
	}
	return graph;
}

int numberOfCapital(Graph *graph, int numberOfState)
{
	for (int i = 1; i < graph->cities.size(); ++i)
	{
		auto city = graph->cities[i];
		if (city->NumberOfState == numberOfState)
		{
			return i;
		}
	}
}

void takeOverACity(Graph *graph, int numberOfState)
{
	int numberOfCityToTakeOver = choosingClosest(graph, numberOfState);
	if (numberOfCityToTakeOver)
	{
		graph->cities[numberOfCityToTakeOver]->NumberOfState = numberOfState;
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
			if (graph->cities[j]->NumberOfState == i)
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

	if (testGraph->cities[3]->NumberOfState != 2 || testGraph->cities[1]->NumberOfState != 2 ||
		testGraph->cities[5]->NumberOfState != 2 || testGraph->cities[4]->NumberOfState != 2)
	{
		deleteGraph(testGraph);
		return false;
	}

	if (testGraph->cities[2]->NumberOfState != 1 || testGraph->cities[6]->NumberOfState != 1 ||
		testGraph->cities[8]->NumberOfState != 1 || testGraph->cities[7]->NumberOfState != 1)
	{
		deleteGraph(testGraph);
		return false;
	}

	deleteGraph(testGraph);
	return true;
}