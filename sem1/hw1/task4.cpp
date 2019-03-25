#include <stdio.h>

int main() 
{
	int a[28]{}, sum = 0;
	for (int i = 0; i <= 9; ++i)
		for (int j = 0; j <= 9; ++j)
			for (int k = 0; k <= 9; ++k)
				a[i + j + k]++;
	for (int i = 0; i <= 27; ++i)
		sum += a[i] * a[i];
	printf("%d", sum);
	return 0;
}

