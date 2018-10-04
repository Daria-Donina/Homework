#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main() {
	int x;
	scanf("%d", &x);
	const int squareOfX = x * x;
	printf("%d", (squareOfX + 1) * (squareOfX + x) + 1);
	return 0;
}
