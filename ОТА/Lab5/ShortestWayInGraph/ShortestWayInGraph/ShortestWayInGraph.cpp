#include "pch.h"
#include <iostream>
#include <fstream>
#include <algorithm>
#include <time.h>
#include <chrono>

using namespace std;

const int INF = 1000000000;
bool used[9] = { 0 };
int top[9] = { 0 };
int g[9][9] = { 0 };
int n = 9;
int l;
int s = 0;
int f = 8;
int d[9] = { 0, INF, INF, INF, INF, INF, INF, INF, INF };

int dfs(int v) {
	if (used[v])
		return 0;
	used[v] = true;
	for (int to = 0; to < n; to++)
		if (g[v][to])
			dfs(to);
	top[l++] = v;
}

int topSort() {
	l = 0;
	for (int i = 0; i < n; i++)
		dfs(i);
	reverse(top, top + l);
	return 0;
}

int solve() {
	int i, j;
	for (i = 0; i < n; i++)
		d[i] = INF;
	d[s] = 0;
	for (i = 1; i < n; i++)
		for (j = 0; j < i; j++)
			if (g[top[j]][top[i]])
				d[top[i]] = min(d[top[i]], d[top[j]] + g[top[j]][top[i]]);
	return 0;
}

void solve_d() {
	int i, j,
		v, 
		to, 
		len;
	d[s] = 0;
	for (i = 0; i < n; i++) {
		v = -1;
		for (j = 0; j < n; j++)
			if (!used[j] && (v == -1 || d[j] < d[v]))
				v = j;
		used[v] = true;
		for (to = 0; to < n; to++) {
			if (g[v][to]) {
				len = g[v][to];
				if (d[v] + len < d[to]) {
					d[to] = d[v] + len;
				}
			}
		}
	}
}

int main()
{
	ifstream myFile("D:\\Learning\\ОТА\\4 семестр\\Лабораторные работы\\ЛР4\\ShortestWayInGraph\\ShortestWayInGraph\\Debug\\file.txt");

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			myFile >> g[i][j];
			if (g[i][j] == -1) g[i][j] = INF;
		}
		
	}
	auto start = chrono::steady_clock::now();
	//topSort();
	//solve();
	solve_d();
	auto end = chrono::steady_clock::now();

	for (int i = 0; i < n; i++) {
		cout << d[i] << " ";
	}
	cout << endl
		 << "Time taken in microseconds: " 
		 << chrono::duration_cast<chrono::microseconds>(end - start).count() 
		 << endl;

	cout << endl
		<< "Time taken in nanoseconds: "
		<< chrono::duration_cast<chrono::nanoseconds>(end - start).count()
		<< endl;
}