#pragma once
#include <fstream>

struct Graph;

//Create new graph
Graph *createGraph(const int numberOfCities);

//Add data about world
Graph *addCitiesAndRoads(std::ifstream &inputData);

//Form states
void stateFormation(Graph *graph);

//Print states and their cities
void printGraph(Graph *graph);

//Remove graph
void deleteGraph(Graph *graph);

//Testing the program
bool programTest();