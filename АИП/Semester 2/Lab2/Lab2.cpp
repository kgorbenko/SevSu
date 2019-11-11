#include <iostream>

int main(int argc, char** argv) {
	float x, y;
	
	printf("Enter x\n");
	scanf("%f", &x);
	printf("Enter y\n");
	scanf("%f", &y);
	
	if ((x*x+y*y <= 1 && x >= 0 && y >= 0) || (x <= 0 && y <= 0 && x >= -1 && y >= -1)){
		printf("Point (%f;%f) is in the marked area", x, y);
	}
	else printf("Point (%f;%f) is not in marked area", x, y);
	
	getchar();
	return 0;
}
