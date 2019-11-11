#include <iostream>

int main(int argc, char** argv) {
	char surname[20], bookName[20], genre[10];
	unsigned price, year;
	
	printf("Enter surname:\n");
	scanf("%s", surname);
	
	printf("Enter book name:\n");
	scanf("%s", bookName);
	
	printf("Enter genre:\n");
	scanf("%s", genre);
	
	printf("Enter price\n");
	scanf("%u", &price);
	
	printf("Enter year\n");
	scanf("%u", &year);
	
	printf("Author: %s; book name: %s; genre: %s; price: %u; year: %u\n", surname, bookName, genre, price, year);	
	
	return 0;
}
