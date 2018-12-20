#include "KMP_algorithm.h"
#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

int main()
{
	test();

	ifstream inputData("input_data.txt");
	string str = "";
	getline(inputData, str);
	inputData.close();

	string pattern = "";
	cout << "Enter pattern: " << endl;
	getline(cin, pattern);

	cout << "Number of first occurence of a pattern in the string: " << countFirstOccurenceOfAPattern(str, pattern) << endl;

	return 0;
}