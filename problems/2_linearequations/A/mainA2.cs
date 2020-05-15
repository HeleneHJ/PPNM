using System;
using static System.Console;
class main{
static void Main(){
	var rnd=new Random(1);
	int n=4;
	var A=new matrix(n,n);
	var b=new vector(n);
	for(int i=0;i<n;i++)
	for(int j=0;j<n;j++)
		A[i,j]=2*(rnd.NextDouble()-0.5);
	A.print("Solution of a linear system Ax=b:\nrandom square matrix A:");
	for(int i=0;i<n;i++) b[i]=2*(rnd.NextDouble()-0.5);
	b.print("random right-hand-side b:\n");
	var qra=new gramschmidt(A);
	var x=qra.solve(b);
	x.print("solution x to equation Ax=b:\n");
	var C=A*x;
	C.print("check: A*x=\n");
	if(b.approx(A*x)) Write("A*x=b, test passed\n");
	else Write("A*x!=b, test failed\n");
}
}