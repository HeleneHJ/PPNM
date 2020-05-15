using System;
using static System.Console;
class main{
static void Main(){
	var rnd=new Random(1);
	int n=4;
	var A=new matrix(n,n);
	for(int i=0;i<n;i++)
	for(int j=0;j<n;j++)
		A[i,j]=2*(rnd.NextDouble()-0.5);
	A.print("Matrix inverse.\nRandom square matrix A:");
	var qra=new gramschmidt(A);
	var B=qra.inverse();
	B.print("\nA^-1:");
	var Id=new matrix(n,n);
	for(int i=0;i<n;i++)Id[i,i]=1;
	var C=A*B;
	C.print("\ncheck: A*A^-1:");
	if(Id.approx(A*B)) Write("\nA*A^-1 = Id, test passed\n");
	else Write("\nA*A^-1 != Id, test failed\n");
	var D=B*A;
	D.print("\ncheck: A^-1*A=");
	if(Id.approx(B*A)) Write("\nA^-1*A = I, test passed\n");
	else Write("\nA^-1*A != I, test failed\n");
}
}