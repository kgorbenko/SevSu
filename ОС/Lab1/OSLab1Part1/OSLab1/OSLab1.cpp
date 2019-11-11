#include <pch.h>
#include <iostream>

using namespace std;

void viewarray(int *array, int size)
{
	cout << endl << "Array" << endl;
	for (int i = 0; i < size; i++) {
		cout << array[i] << " ";
	}
}

void sortarray(int *array, int size)
{
	for (int i = 0; i < size - 1; i++)
	{
		for (int j = size - 1; j > 0; j--)
		{
			if (array[j] > array[j - 1])
			{
				int temp = array[j];
				array[j] = array[j - 1];
				array[j - 1] = temp;
			}
		}
	}
}

int main()
{
	int N;
	cout << "Enter number of array elements" << endl;
	cin >> N;

	int *arr = new int[N];
	cout << "Enter array elements one by one" << endl;
	for (int i = 0; i < N; i++)
		cin >> arr[i];

	viewarray(arr, N);
	sortarray(arr, N);
	viewarray(arr, N);

	delete[] arr;
}