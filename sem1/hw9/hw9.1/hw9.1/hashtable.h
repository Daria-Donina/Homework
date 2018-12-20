#pragma once
#include <fstream>

namespace hashTable
{
	struct HashTable;

	//Create hash table
	HashTable *createHashtable();

	//Print content of a hash table
	void printHashTable(HashTable *hashTable);

	//Delete hash table
	void deleteHashTable(HashTable *hashTable);

	//Load factor of a hash table
	float loadFactor(HashTable *hashTable);

	//Maximum length of a list in a hash table
	int maxListLength(HashTable *hashTable);

	//Average length of a list in a hash table
	float averageListLength(HashTable *hashTable);

	//Fill hash table
	void add(std::ifstream &inputData, HashTable *hashTable);
}

//Testing the program
bool programTest();