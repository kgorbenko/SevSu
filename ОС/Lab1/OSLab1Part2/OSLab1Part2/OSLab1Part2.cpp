#include <pch.h>
#include <iostream>
#include <limits.h>

using namespace std;

void viewmatrix(int **array, int size0, int size1)
{
	cout << "Matrix" << endl;

	for (int i = 0; i < size0; i++) {
		for (int j = 0; j < size1; j++)
			cout << array[i][j] << " ";
		cout << endl;
	}
}

int * get_column_max_elements(int **array, int size0, int size1)
{
	int *columnsMaxElements = new int[size0];

	for (int j = 0; j < size1; j++)
	{
		int columnMax = INT_MIN;

		for (int i = 0; i < size0; i++)
		{
			if (array[i][j] > columnMax)
				columnMax = array[i][j];
		}

		columnsMaxElements[j] = columnMax;
	}

	return columnsMaxElements;
}

void viewarray(int * array, int size0)
{
	cout << "Array" << endl;

	for (int i = 0; i < size0; i++) {
		cout << array[i] << " ";
	}
}

int main()
{
	int M, N;

	cout << "Enter number of array rows" << endl;
	cin >> M;

	cout << "Enter number of array columns" << endl;
	cin >> N;

	int **arr = new int*[M];
	for (int i = 0; i < M; i++)
		arr[i] = new int[N];

	cout << "Enter array elements one by one" << endl;
	for (int i = 0; i < M; i++)
		for (int j = 0; j < N; j++)
			cin >> arr[i][j];

	viewmatrix(arr, M, N);
	int * columnsMaxElements = get_column_max_elements(arr, M, N);
	viewarray(columnsMaxElements, N);

	for (int i = 0; i < M; i++)
		delete[] arr[i];

	delete[] arr;
}