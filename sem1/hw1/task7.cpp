#define _CRT_SECURE_NO_WARNINGS
#include<stdio.h>
#include <math.h>

int main() {
	int n, counter = 0;
	scanf("%d", &n);
	for (int i = 2; i <= n; ++i) {
		for (int j = 2; j <= sqrt(i); j++) {
			if (i % j == 0)
				counter++;
		}
		if (counter == 0)
			printf("%d\n", i);
		counter = 0;
	}
	return 0;
}
