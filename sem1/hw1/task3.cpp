#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

void Inversion(int k, int b, int c, int a[]) {
	for (int i = 0; i < k; ++i) {
		int temp = a[i + b];
		a[i + b] = a[c - 1 - i];
		a[c - 1 - i] = temp;
	}
}

int main() {
	int m, n;
	printf("Enter m under 10, n = 10 - m\n");
	printf("Enter m = ");
	scanf("%d", &m);     
	printf("Enter n = ");
	scanf("%d", &n);
	printf("Enter array of 10 numbers\n");
	int x[10];
	for (int i = 0; i < 10; ++i)
		scanf("%d", &x[i]);
	
	Inversion(m / 2, 0, m, x);
	Inversion(n / 2, m, n + m, x);
	Inversion((m + n) / 2, 0, n + m, x);

    for (int i = 0; i < m + n; ++i) {
		printf("%d", x[i]);
		printf(" ");
	}
	return 0;
}
