#include <iostream>
#include <math.h>

int main(int argc, char** argv) {
	float z, m, c, x, tangent;
	const float PI = 3.14;
	
	printf("Enter c");
	scanf("%f", &c);
	printf("Enter x");
	scanf("%u", &x);
	
	m = exp(-c*abs(x) + sqrt(c*x));
	tangent = tan( (PI * m) / (m + 10E-3) );
	z = pow(tangent, 2);
	
	printf("m = %f; z = %f;", m, z);
	getchar();	
	return 0;
}
