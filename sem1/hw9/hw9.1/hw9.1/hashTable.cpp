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
	const int size = 100;
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

int numberOfElements(HashTable *hashTable)
{
	int numberOfWords = 0;
	for (int i = 0; i < hashTable->buckets.size(); ++i)
	{
		numberOfWords += hashTable->buckets[i] ? hashTable->buckets[i]->length : 0;
	}
	return numberOfWords;
}

float loadFactor(HashTable *hashTable)
{
	return (float)numberOfElements(hashTable) / (float)hashTable->buckets.size();
}

int maxListLength(HashTable *hashTable)
{
	int max = hashTable->buckets[0]->length;
	for (int i = 1; i < hashTable->buckets.size(); ++i)
	{
		int length = hashTable->buckets[i] ? hashTable->buckets[i]->length : 0;
		if (length > max)
		{
			max = length;
		}
	}
	return max;
}

float averageListLength(HashTable *hashTable)
{
	int sumOfListlengths = 0;
	int numberOfLists = 0;
	for (int i = 0; i < hashTable->buckets.size(); ++i)
	{
		if (hashTable->buckets[i])
		{
			sumOfListlengths += hashTable->buckets[i]->length;
			++numberOfLists;
		}
	}
	return (float)sumOfListlengths / (float)numberOfLists;
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

bool programTest()
{
	auto testHashTable = createHashtable();

	ifstream testFile("test.txt");
	if (!testFile)
	{
		deleteHashTable(testHashTable);
		return false;
	}
	hashTable::add(testFile, testHashTable);
	testFile.close();

	int hash1 = hashFunction(testHashTable, "feel");
	int hash2 = hashFunction(testHashTable, "mind");
	int hash3 = hashFunction(testHashTable, "the");
	
	Node *node1 = exists(testHashTable->buckets[hash1], "feel");
	Node *node2 = exists(testHashTable->buckets[hash2], "mind");
	Node *node3 = testHashTable->buckets[hash3] ? exists(testHashTable->buckets[hash3], "the") : nullptr;


	if (!node1 || !node2 || node3)
	{
		deleteHashTable(testHashTable);
		return false;
	}

	if (node1->counter != 1 || node2->counter != 2)
	{
		deleteHashTable(testHashTable);
		return false;
	}

	deleteHashTable(testHashTable);
	return true;
}