#pragma once
#include <fstream>

struct HashTable;

//Create hash table
HashTable *createHashtable();

namespace hashTable
{
	//Fill hash table
	void add(std::ifstream &inputData, HashTable *hashTable);
}

//Print content of a hash table
void printHashTable(HashTable *hashTable);

//Delete hash table
void deleteHashTable(HashTable *hashTable);



