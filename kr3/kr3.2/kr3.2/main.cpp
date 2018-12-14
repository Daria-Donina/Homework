#include <ctime>
#include <iostream>

using namespace std;

int main()
{
	const int n = 3;
	const int m = 3;

	int doubleArray[n][m];

	srand(time(nullptr));
	for (int i = 0; i < n; ++i)
	{
		for (int j = 0; j < m; ++j)
		{
			cin >> doubleArray[i][j];
		}
	}

	int minimum[n]{};

	for (int i = 0; i < n; ++i)
	{
		minimum[i] = 0;
		for (int j = 0; j < m; ++j)
		{
			if (doubleArray[i][j] < doubleArray[i][minimum[j]])
			{
				minimum[i] = j;
			}
		}
	}


	int maximum[m]{};
	for (int i = 0; i < m; ++i)
	{
		maximum[i] = 0;
		for (int j = 0; j < n; ++j)
		{
			if (doubleArray[j][i] > doubleArray[maximum[j]][i])
			{
				maximum[i] = j;
			}
		}
	}

	cout << "Saddle points:" << endl;
	for (int i = 0; i < n; ++i)
	{
		for (int j = 0; j < m; ++j)
		{
			if (i == minimum[i] && j == maximum[j])
			{
				cout << doubleArray[i][j] << endl;
			}
		}
	}

	return 0;
}