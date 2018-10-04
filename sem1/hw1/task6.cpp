#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main() {
	int LengthOfS, LengthOfS1;
	printf("Enter the length of s\n");
	scanf("%d", &LengthOfS);
	printf("Enter the length of s1\n");
	scanf("%d", &LengthOfS1);
	char *s = new char[LengthOfS] {};
	char *s1 = new char[LengthOfS1] {};
	printf("Enter s\n");
	scanf("%s", s);
	printf("Enter s1\n");
	scanf("%s", s1);
	int SubCounter = 0, counter = 0;
	for (int i = 0; i <= LengthOfS - LengthOfS1; ++i) {
		int i1 = i;
		if (s1[0] == s[i]) {
			for (int j = 0; j < LengthOfS1; ++j) {
				if (s1[j] != s[i1]) {
					SubCounter = 0;
					break;
				}
				i1++;
				SubCounter++;
			}
			if (SubCounter != 0)
				counter++;
		}
	}
	printf("The answer is %d", counter);
	delete[] s;
	delete[] s1;
	return 0;
}