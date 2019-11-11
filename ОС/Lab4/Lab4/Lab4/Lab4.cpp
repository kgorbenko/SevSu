#include "pch.h"
#include <iostream>
#include <fstream>
#include <stdio.h>

using namespace std;

struct MemoryNode
{
	int startPosition;
	int bytes;
	MemoryNode * next;
	MemoryNode * previous;
};

void show_current_state(int * currentState) 
{
	for (int i = 0; i < 50; i++)
		cout << currentState[i] << " ";

	cout << endl;
}

int get_user_option()
{
	int userOption;
	
	cout << endl;
	cout << "1 - Show memory current state"   << endl;
	cout << "2 - Allocate memory"             << endl;
	cout << "3 - Free memory"                 << endl;
	cout << "4 - Show free memory state"      << endl;
	cout << "5 - Show allocated memory state" << endl;
	cout << "6 - Exit"                        << endl;

	cin >> userOption;

	return userOption;
}

void set_current_node_state(MemoryNode * current, MemoryNode* previous, int i, int counter)
{
	current->startPosition = i - counter;
	current->bytes         = counter;
	current->previous      = previous;
}

MemoryNode * get_memory_list(int * state, int length, int number)
{
	MemoryNode * first    = (MemoryNode*)malloc(sizeof(MemoryNode));
	MemoryNode * current  = first;
	MemoryNode * previous = first;

	int counter = 0;

	for (int i = 0; i < length; i++)
	{
		if (current == NULL && state[i] == number)
		{
			current = (MemoryNode*)malloc(sizeof(MemoryNode));
			previous->next = current;
		}

		if (state[i] == number)
			counter++;

		else if (counter > 0)
		{
			set_current_node_state(current, previous, i, counter);
			previous      = current;
			current->next = NULL;
			current       = current->next;
			counter       = 0;
		}
	}

	if (counter > 0) 
	{
		set_current_node_state(current, previous, 50, counter);
		previous      = current;
		current->next = NULL;
		current       = current->next;
	}

	first->previous = NULL;

	return first;
}

void show_list(MemoryNode * list)
{
	MemoryNode * node = list;

	cout << endl;
	while (node != NULL)
	{
		cout << "Start position: " << node->startPosition << "; bytes: " << node->bytes << ";" << endl;
		node = node->next;
	}
}

void swap(MemoryNode *node, MemoryNode *next)
{
	int tempBytes       = node->bytes;
	int tempStart       = node->startPosition;
	node->bytes         = next->bytes;
	node->startPosition = next->startPosition;
	next->bytes         = tempBytes;
	next->startPosition = tempStart;
}

void bubbleSort(MemoryNode *start)
{
	int swapped;
	MemoryNode *node;
	MemoryNode *next;

	if (start == NULL) return;

	do
	{
		swapped = 0;
		node = start;

		while (node->next != NULL)
		{
			next = node->next;

			if (node->startPosition > next->startPosition)
			{
				swap(node, next);
				swapped = 1;
			}
			node = node->next;
		}
	} while (swapped);
}

int remove_by_bytes(MemoryNode *& list, int bytes) 
{
	int startPosition;
	
	MemoryNode* current = list;
	MemoryNode* suitable = NULL;

	while (current->next != NULL && suitable == NULL)
	{
		if (current->bytes >= bytes)
			suitable = current;

		current = current->next;
	}

	if (suitable == NULL)
		return -1;

	startPosition = suitable->startPosition;

	if (suitable->bytes > bytes)
	{
		suitable->bytes         = suitable->bytes - bytes;
		suitable->startPosition = suitable->startPosition + bytes;
	}
	else 
	{
		if (suitable->previous == NULL && suitable->next == NULL){
			list = NULL;
		}
		else if (suitable->previous == NULL) {
			list = suitable->next;
			suitable->next->previous = NULL;
		}
		else if (suitable->next == NULL) {
			suitable->previous->next = NULL;
		}
		else 
		{
			suitable->previous->next = suitable->next;
			suitable->next->previous = suitable->previous;
		}
		free(suitable);
	}

	return startPosition;
}

int remove_by_bytes_strictly(MemoryNode *& list, int bytes)
{
	int startPosition;

	MemoryNode* current = list;
	MemoryNode* suitable = NULL;

	while (current->next != NULL && suitable == NULL)
	{
		if (current->bytes == bytes)
			suitable = current;

		current = current->next;
	}

	if (suitable == NULL)
		return -1;

	startPosition = suitable->startPosition;

	if (suitable->previous == NULL && suitable->next == NULL) {
		list = NULL;
	}
	else if (suitable->previous == NULL) {
		list = suitable->next;
		suitable->next->previous = NULL;
	}
	else if (suitable->next == NULL) {
		suitable->previous->next = NULL;
	}
	else
	{
		suitable->previous->next = suitable->next;
		suitable->next->previous = suitable->previous;
	}
	free(suitable);

	return startPosition;
}

void push_to_end(MemoryNode * list, int bytes, int start) {
	
	MemoryNode* current = list;

	while (current->next != NULL) {
		current = current->next;
	}

	current->next = (MemoryNode*)malloc(sizeof(MemoryNode));
	current->next->bytes = bytes;
	current->next->startPosition = start;
	current->next->next = NULL;
	current->next->previous = current;
}

void change_memory_state(int startPosition, int bytes, int* currentState)
{
	int state = currentState[startPosition];
	if (state == 0) state = 1;
	else state = 0;

	for (int i = startPosition; i < startPosition + bytes; i++)
		currentState[i] = state;
}

void check_for_collitions(MemoryNode* list, int startPosition)
{
	MemoryNode* node = NULL;
	MemoryNode* previous = NULL;
	MemoryNode* next = NULL;

	while (list->next != NULL && node == NULL) {
		if (list->startPosition == startPosition)
			node = list;
		
		list = list->next;
	}

	if (node->previous == NULL && node->next == NULL)
		return;
	if (node->previous != NULL)
	{
		previous = node->previous;

		if (previous->startPosition + previous->bytes == node->startPosition)
		{
			previous->bytes += node->bytes;
			previous->next = node->next;
			free(node);
			node = previous;
		}
	}

	previous = node->previous;

	if (node->next != NULL)
	{
		next = node->next;

		if (node->startPosition + node->bytes == next->startPosition)
		{
			node->bytes += next->bytes;
			node->next = next->next;
			if (next->next != NULL)
				next->next->previous = node;
			free(next);
		}
	}
}

void freeMemory(MemoryNode* list)
{
	MemoryNode* current = list;
	MemoryNode* next;
	
	while (current->next != NULL) 
	{
		next = current->next;
		free(current);
		current = next;
	}
	free(current);
}

int main()
{
	ifstream myFile("D:\\Learning\\ОС\\4 семестр\\Лабораторные работы\\ЛР4\\Lab4\\Debug\\file.txt");

	int currentState[50];

	for (int i = 0; i < 50; i++)
		myFile >> currentState[i];
	
	MemoryNode * free = get_memory_list(currentState, 50, 0);
	MemoryNode * allocated = get_memory_list(currentState, 50, 1);
	
	int userOption;
	int bytes;
	int startPosition;

	do
	{
		userOption = get_user_option();

		switch (userOption)
		{
		case 1:
			show_current_state(currentState);
			break;
		case 2:
			cout << "Allocating memory" << endl;
			cout << "Enter number of bytes" << endl;
			cin >> bytes;
			startPosition = remove_by_bytes(free, bytes);
			if (startPosition != -1) {
				push_to_end(allocated, bytes, startPosition);
				change_memory_state(startPosition, bytes, currentState);
				bubbleSort(allocated);
			}
			break;
		case 3:
			cout << "Freeing memory" << endl;
			cout << "Enter number of bytes" << endl;
			cin >> bytes;
			startPosition = remove_by_bytes_strictly(allocated, bytes);
			if (startPosition != -1){
				push_to_end(free, bytes, startPosition);
				change_memory_state(startPosition, bytes, currentState);
				bubbleSort(free);
				check_for_collitions(free, startPosition);
			}
			else cout << "No suitable block to free" << endl;
			break;
		case 4:
			show_list(free);
			break;
		case 5:
			show_list(allocated);
			break;
		case 6:
			freeMemory(free);
			freeMemory(allocated);
			return 0;
		}
	} while (true);
}