#include<stdio.h>

int main() {
	int a[1000]{}, counter = 0;
	for (int i = 0; i < 1000; ++i)
		if (a[i] == 0)
			counter++;
	printf("%d", counter);
	return 0;
}
