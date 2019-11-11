#include <pch.h>
#include <iostream>
#include <string.h>
#include <locale.h>
#include <clocale>

using namespace std;

struct Date {
	int year;
	int month;
	int day;
};

struct FileDescriptor {
	char fileName[8];
	char fileType[3];
	Date created;
	Date lastModified;
	int references;
	int fileSize;
};

FileDescriptor input_one_struct() {
	FileDescriptor data;

	cout << "Enter file name" << endl;
	cin >> data.fileName;

	cout << "Enter file type (3 characters)" << endl;
	cin >> data.fileType;

	cout << "Enter creation date (year, month, date) one by one" << endl;
	cin >> data.created.year;
	cin >> data.created.month;
	cin >> data.created.month;

	cout << "Enter last modification date (year, month, date) one by one" << endl;
	cin >> data.lastModified.year;
	cin >> data.lastModified.month;
	cin >> data.lastModified.day;

	cout << "Enter number of references" << endl;
	cin >> data.references;

	cout << "Enter file size" << endl;
	cin >> data.fileSize;

	return data;
}

void show_stored_records(FileDescriptor * records, int numberOfRecords) {
	for (int i = 0; i < numberOfRecords; i++) {
		cout << endl << i << "-th record" << endl;
		cout << "fileName: " << records[i].fileName << endl;
		cout << "fileType: " << records[i].fileType << endl << endl;
	}
}

void sort_sequence(FileDescriptor * records, int size, int sortedIndex)
{
	for (int i = sortedIndex; i < size; i++) 
	{
		FileDescriptor current = records[sortedIndex];
		
		int j = i;
		while (strcmp(current.fileType, records[j - 1].fileType) && j >= 1)
		{
			records[j] = records[j - 1];
			j = j - 1;
			records[j] = current;
		}
	}
}

int show_menu() {
	cout << "1 - Insert one record" << endl;
	cout << "2 - Show stored records" << endl;
	cout << "3 - Sort records" << endl;
	cout << "4 - Exit" << endl;

	int opted;
	cin >> opted;

	return opted;
}

int main() {
	const int EXIT_NUMBER = 4;

	FileDescriptor * data = new FileDescriptor[20];

	int numberOfStructsStored = 0;
	int sortedIndex = 1;
	int userOption = show_menu();

	do {
		switch (userOption) {
		case 1:
			data[numberOfStructsStored] = input_one_struct();
			numberOfStructsStored += 1;
			break;

		case 2:
			show_stored_records(data, numberOfStructsStored);
			break;

		case 3:
			sort_sequence(data, numberOfStructsStored, sortedIndex);
			sortedIndex = numberOfStructsStored;
			break;
		}

		userOption = show_menu();
	} while (userOption != EXIT_NUMBER);

	delete[] data;
}