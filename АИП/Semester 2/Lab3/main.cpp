#include <math.h>
#include <stdio.h>

int main(void){
	float x, y, delta = 0.1, xMax, exactY, error, accuracy;
	
	printf("Enter x:\n");
	scanf("%f", &x);
	
	printf("Enter x max:\n");
	scanf("%f", &xMax);
	
	printf("Enter accuracy:\n");
	scanf("%f", &accuracy);
	
	printf("------------------------------------------\n");
	
	while (x <= xMax){
		
		y = x;
		printf("x = %f\n\n", x);
		
		exactY = (exp(x) - exp(-x)) / 2;
		printf("Exact value: %f\n", exactY);
		
		for (int i = 1; i <= 10; i++){
			y *= y*y/(4*i*i+2*i);
			error = fabs(exactY - y);
			
			printf("%u\n", i);
			printf("y = %f\n", y);
			printf("error = %f\n", error);
		}
	printf("------------------------------------------\n");
	x+=delta;
	}
}
