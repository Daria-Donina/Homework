#include "hashtable.h"
#include "test.h"
#include <fstream>
#include <iostream>

using namespace std;

int main()
{
	test();

	HashTable *hashTable = createHashtable();

	ifstream inputData("inputData.txt");
	if (!inputData)
	{
		return 1;
	}
	hashTable::add(inputData, hashTable);
	inputData.close();

	cout << "All the words of the text and how many times they occur: " << endl;
	printHashTable(hashTable);

	cout << "Load factor of a hash table: " << loadFactor(hashTable) << endl;
	cout << "Maximum length of a list in a hash table: " << maxListLength(hashTable) << endl;
	cout << "Average length of a list in a hash table: " << averageListLength(hashTable) << endl;

	deleteHashTable(hashTable);
	return 0;
}