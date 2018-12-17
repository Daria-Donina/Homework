#include "hashtable.h"
#include <fstream>

using namespace std;

int main()
{
	//test

	HashTable *hashtable = createHashtable();

	ifstream inputData("inputData.txt");
	hashTable::add(inputData, hashtable);
	inputData.close();

	printHashTable(hashtable);

	deleteHashTable(hashtable);
	return 0;
}