using System;
using static System.Console;
class main{
static void Main(){
	int n=4,m=3;
	matrix A=new matrix(n,m);				/* Construction of a random matrix A */
	var rnd=new Random(1);
	for(int i=0;i<n;i++)
	for(int j=0;j<m;j++)
		A[i,j]=2*(rnd.NextDouble()-0.5);
	A.print($"QR-decomposition:\nrandom {n}x{m} matrix A:");
	
	var qra=new gramschmidt(A);
	var Q=qra.Q;
	var R=qra.R;
	Q.print("matrix Q:");
	R.print("matrix R:");
	matrix qtq=(Q.T*Q);
	qtq.print("Q^T*Q:");
	matrix qr = (Q*R);
	qr.print("Q*R:");
	if(A.approx(Q*R))Write("Q*R=A, test passed\n");
	else Write("Q*R!=A, test failed\n");
}
}