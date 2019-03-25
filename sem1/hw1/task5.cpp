#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main() {
	int counter = 0, n = 10;
	char *s = new char[n]{};
	scanf("%s", s);
	for (int i = 0; i < n; ++i) {
		if (s[i] == '(')
			counter++;
		if (s[i] == ')')
			counter--;
		if (counter < 0)
			break;
	}
	if (counter == 0)
		printf("1");
	else
		printf("0");
	delete[] s; 
	return 0;
}

