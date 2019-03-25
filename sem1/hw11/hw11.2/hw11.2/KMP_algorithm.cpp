#include "KMP_algorithm.h"
#include <string>
#include <fstream>
#include <vector>
#include <iostream>

using namespace std;

vector<int> prefixFunction(const string &str)
{
	vector<int> prefix(str.length());
	prefix[0] = 0;
	for (int i = 1; i < str.length(); ++i)
	{
		int index = i - 1;
		while (index != -1)
		{
			if (str[i] == str[prefix[index]])
			{
				prefix[i] = prefix[index] + 1;
				break;
			}
			else
			{
				index = prefix[index] - 1;
			}
		}
	}
	return prefix;
}

int countFirstOccurenceOfAPattern(const string &str, const string &pattern)
{
	vector<int> prefixPattern(pattern.length());
	prefixPattern = prefixFunction(pattern);
	int counter = 0;
	for (int i = 0; i < str.length(); ++i)
	{
		if (str[i] == pattern[counter])
		{
			++counter;
			if (counter == pattern.length())
			{
				return i - pattern.length() + 2;
			}
		}
		else if (counter > 0)
		{
			counter = prefixPattern[counter - 1];
			i += counter;
		}
	}
	return -1;
}

bool programTest()
{
	ifstream inputData("test.txt");
	string str1 = "";
	getline(inputData, str1);
	string pattern1 = "all";

	string str2 = "";
	getline(inputData, str2);
	string pattern2 = "goodbye";

	string str3 = "";
	getline(inputData, str3);
	string pattern3 = "alive";

	inputData.close();

	return countFirstOccurenceOfAPattern(str1, pattern1) == 1 && countFirstOccurenceOfAPattern(str2, pattern2) == 9 &&
		countFirstOccurenceOfAPattern(str3, pattern3) == 14;
}

void test()
{
	if (programTest())
	{
		cout << "Tests passed :)" << endl;
	}
	else
	{
		cout << "Tests failed :(" << endl;
	}
}