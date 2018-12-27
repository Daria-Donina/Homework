#pragma once
#include <string>

struct Node;

struct Map;

//Create new map
Map *createMap();

//Insert a value
void insert(Map *&map, std::string key, std::string value);

//Get the root of the map
Node *root(Map *map);

//Get the key of the node
std::string key(Node *node);

//Get left child og the node
Node *leftChild(Node *node);

//Get right child og the node
Node *rightChild(Node *node);

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