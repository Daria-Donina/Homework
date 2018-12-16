#pragma once
#include <string>

struct Node
{
	std::string key = "";
	std::string value = "";
	int height = 0;
	Node *leftChild = nullptr;
	Node *rightChild = nullptr;
};

struct Map
{
	Node *root{};
};

//Create new map
Map *createMap();

//Insert a value
void insert(Map *&map, std::string key, std::string value);

//Find a value by key
std::string find(Map *map, std::string key);

//Check if key is in the map
bool isKey(Node *node, const std::string key);

//Print if key is in the map
void keyAvailability(Map *map, std::string key);

//Remove a value by key
void remove(Map *map, std::string key);

//Remove a map
void deleteMap(Map *map);