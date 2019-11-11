#include "pch.h"
#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

const int INF = 1000000000;
bool used[9] = { 0 };
int g[9][9] = { 0 };
int n = 9;

int solve() {
	int v, to;
	std::vector<int> min_e(n, INF), sel_e(n, -1);
	min_e[0] = 0;
	for (int i = 0; i < n; i++) {
		v = -1;
		for (int j = 0; j < n; j++)
			if (!used[j] && (v == -1 || min_e[j] < min_e[v]))
				v = j;
		if (min_e[v] == INF) {
			cout << "No MST!";
				exit(0);
		}
		used[v] = true;
		if (sel_e[v] != -1)
			cout << v << " " << sel_e[v] << endl;
		for (to = 0; to < n; to++)
			if (g[v][to] < min_e[to]) {
				min_e[to] = g[v][to];
				sel_e[to] = v;
			}
	}
	return 0;
}

int main()
{
	ifstream myFile("file.txt");

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			myFile >> g[i][j];
			if (g[i][j] == -1) g[i][j] = INF;
		}

	}

	solve();
}