#include "pch.h"
#include <iostream>
#include <fstream>
#include <queue>
#include <unordered_set>

using namespace std;

struct NURNode
{
	int page;

	int appealed;
};

int contains(NURNode array[], int n, int item)
{
	for (int i = 0; i < n; i++)
	{
		if (array[i].page == item)
			return i;
	}

	return -1;
}

int nur_page_faults(int pages[], int n, int capacity)
{
	NURNode memory[10];
	int pageFaults = 0;

	for (int i = 0; i < capacity; i++)
	{
		memory[i].page = pages[i];
		memory[i].appealed = 0;
	}

	for (int i = 10; i < n; i++)
	{
		int position = contains(memory, capacity, pages[i]);

		if (position != -1)
			memory[position].appealed += 1;

		else
		{
			pageFaults += 1;

			for (int j = 0; j < capacity; j++)
			{
				if (memory[j].appealed == 0)
				{
					memory[j].appealed = 1;
					memory[j].page = pages[i];
					break;
				}
			}
		}
	}

	return pageFaults;
}

int fifo_page_faults(int pages[], int n, int capacity)
{ 
	unordered_set<int> s; 
	queue<int> indexes;
 
	int page_faults = 0;
	for (int i = 0; i < n; i++)
	{ 
		if (s.size() < capacity)
		{ 
			if (s.find(pages[i]) == s.end())
			{
				s.insert(pages[i]);

				page_faults++;

				indexes.push(pages[i]);
			}
		}

		else
		{ 
			if (s.find(pages[i]) == s.end())
			{
				int val = indexes.front();

				indexes.pop(); 
				s.erase(val);
				s.insert(pages[i]);
				indexes.push(pages[i]);
				page_faults++;
			}
		}
	}

	return page_faults;
}

int main()
{
	char path[] = "file.txt";
	ifstream file(path);

	int pages[1000];

	for (int i = 0; i < 1000; i++)
		file >> pages[i];
	
	int n = sizeof(pages) / sizeof(pages[0]);
	int capacity = 10;

	//cout << fifo_page_faults(pages, n, capacity);
	cout << nur_page_faults(pages, n, capacity);
	
	return 0;
}