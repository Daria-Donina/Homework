#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main() {
	int a, b, counter = 0;
	scanf("%d", &a);
	scanf("%d", &b);
	if (a >= 0 && b > 0) {
		while (a >= b) {
			a -= b;
			counter++;
		}
		printf("%d", counter);
	}
	else if (a < 0 && b > 0) {
		while (a < b) {
			a += b;
			counter++;
		}
		printf("%d", -counter + 1);
	}
	else if (a >= 0 && b < 0) {
		while (a >= b) {
			a += b;
			counter++;
		}
		printf("%d", -counter + 2);
	}
	else if (a < 0 && b < 0) {
		while (a < b) {
			a -= b;
			counter++;
		}
		printf("%d", counter + 1);
	}
	return 0;
}
