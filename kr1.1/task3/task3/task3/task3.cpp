#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main() {
	FILE *file = fopen("file.txt", "r");
	if (!file) {
		printf("file not found!");
		return 1;
	}
	int linesRead = 0;
	while (!feof(file)) {
		char *buffer = new char[100]{};
		fgets(buffer, 100, file);
		int i = 0;
		while (buffer[i] != '\0')
		{
			if (buffer[i] == ';')
			{
				break;
			}
			++i;
		}
		int j = i;
		while (buffer[j] != '\0')
		{
			printf("%c", buffer[j]);
			++j;
		}
		++linesRead;
		delete[] buffer;
	}
	fclose(file);
	return 0;
}