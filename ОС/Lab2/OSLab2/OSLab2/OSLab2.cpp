#include <pch.h>
#include <iostream>
#include <string.h>

using namespace std;

int main()
{
	char line[81];
	char *token;

	cout << "Enter initial string" << endl;;
	cin.getline(line, 81);

	token = strtok(line, " ");

	int counter = 0;
	cout << "Words:" << endl << endl;

	for (; token; token = strtok(NULL, " "))
	{
		int first = 0;
		int last = strlen(token) - 1;

		cout << token << endl;

		if (strlen(token) == 1) continue;
		if (token[first] != token[last]) counter++;
	}

	cout << endl << "Number of words with different first and last positions - " << counter << endl;
}