#include "hashtable.h"
#include "list.h"
#include <vector>
#include <fstream>
#include <string>

using namespace std;

struct HashTable
{
	vector<List*> buckets{};
};

HashTable *createHashtable()
{
	const int size = 50;
	auto hashTable = new HashTable;
	hashTable->buckets.resize(size);
	return hashTable;
}

int hashFunction(HashTable *hashTable, string str)
{
	int hash = 0;
	for (int i = 0; i < str.length(); ++i)
	{
		hash += hash * 5 + str[i];
	}
	return hash % hashTable->buckets.size();
}

void addWord(HashTable *hashTable, string word)
{
	int hash = hashFunction(hashTable, word);
	if (hashTable->buckets[hash] == nullptr)
	{
		hashTable->buckets[hash] = createList();
	}
	list::add(hashTable->buckets[hash], word);
}

void hashTable::add(ifstream &inputData, HashTable *hashTable)
{
	while (!inputData.eof())
	{
		string word;
		inputData >> word;
		addWord(hashTable, word);
	}
}

void printHashTable(HashTable *hashTable)
{
	for (int i = 0; i < hashTable->buckets.size(); ++i)
	{
		if (hashTable->buckets[i])
		{
			printList(hashTable->buckets[i]);
		}
	}
}

void deleteHashTable(HashTable *hashTable)
{
	for (int i = 0; i < hashTable->buckets.size(); ++i)
	{
		if (hashTable->buckets[i])
		{
			deleteList(hashTable->buckets[i]);
		}
	}
	delete hashTable;
}