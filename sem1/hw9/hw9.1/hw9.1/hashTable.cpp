#include "hashtable.h"
#include "list.h"
#include <vector>
#include <fstream>
#include <string>

using namespace std;

struct hashTable::HashTable
{
	vector<list::List*> buckets{};
};

hashTable::HashTable *hashTable::createHashtable()
{
	const int size = 100;
	auto hashTable = new HashTable;
	hashTable->buckets.resize(size);
	return hashTable;
}

int hashFunction(hashTable::HashTable *hashTable, const std::string &str)
{
	int hash = 0;
	for (int i = 0; i < str.length(); ++i)
	{
		hash += hash * 5 + str[i];
	}
	return hash % hashTable->buckets.size();
}

void addWord(hashTable::HashTable *hashTable, const std::string &word)
{
	int hash = hashFunction(hashTable, word);
	if (hashTable->buckets[hash] == nullptr)
	{
		hashTable->buckets[hash] = list::createList();
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

void hashTable::printHashTable(HashTable *hashTable)
{
	for (int i = 0; i < hashTable->buckets.size(); ++i)
	{
		if (hashTable->buckets[i])
		{
			printList(hashTable->buckets[i]);
		}
	}
}

int numberOfElements(hashTable::HashTable *hashTable)
{
	int numberOfWords = 0;
	for (int i = 0; i < hashTable->buckets.size(); ++i)
	{
		numberOfWords += hashTable->buckets[i] ? list::length(hashTable->buckets[i]) : 0;
	}
	return numberOfWords;
}

float hashTable::loadFactor(HashTable *hashTable)
{
	return (float)numberOfElements(hashTable) / (float)hashTable->buckets.size();
}

int hashTable::maxListLength(HashTable *hashTable)
{
	int max = length(hashTable->buckets[0]);
	for (int i = 1; i < hashTable->buckets.size(); ++i)
	{
		int length = hashTable->buckets[i] ? list::length(hashTable->buckets[i]) : 0;
		if (length > max)
		{
			max = length;
		}
	}
	return max;
}

float hashTable::averageListLength(HashTable *hashTable)
{
	int sumOfListlengths = 0;
	int numberOfLists = 0;
	for (int i = 0; i < hashTable->buckets.size(); ++i)
	{
		if (hashTable->buckets[i])
		{
			sumOfListlengths += list::length(hashTable->buckets[i]);
			++numberOfLists;
		}
	}
	return (float)sumOfListlengths / (float)numberOfLists;
}

void hashTable::deleteHashTable(HashTable *hashTable)
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
	auto testHashTable = hashTable::createHashtable();

	ifstream testFile("test.txt");
	if (!testFile)
	{
		deleteHashTable(testHashTable);
		return false;
	}
	hashTable::add(testFile, testHashTable);
	testFile.close();

	string string1 = "feel";
	int hash1 = hashFunction(testHashTable, string1);

	string string2 = "mind";
	int hash2 = hashFunction(testHashTable, string2);

	string string3 = "the";
	int hash3 = hashFunction(testHashTable, string3);
	
	list::Node *node1 = exists(testHashTable->buckets[hash1], string1);
	list::Node *node2 = exists(testHashTable->buckets[hash2], string2);
	list::Node *node3 = testHashTable->buckets[hash3] ? exists(testHashTable->buckets[hash3], string3) : nullptr;


	if (!node1 || !node2 || node3)
	{
		deleteHashTable(testHashTable);
		return false;
	}

	if (list::counter(node1) != 1 || list::counter(node2) != 2)
	{
		deleteHashTable(testHashTable);
		return false;
	}

	deleteHashTable(testHashTable);
	return true;
}