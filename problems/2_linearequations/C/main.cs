using System;
using static System.Console;
class main{
static void Main(){
		int n=4;
		int m=4;
		var rand=new Random();
		matrix A=new matrix(n,m);
		vector b=new vector(n); 
		for(int i=0;i<n;i++){
			for(int j=0;j<m;j++){
				A[i,j]=10*rand.NextDouble();
			}
			b[i]=10*rand.NextDouble();
		}
		WriteLine("Givens rotations.");
		A.print("Random square matrix A:");
		b.print("Random vector b:\n");

		var S = new givens(A); /* decomposition via Givens rotations*/
		WriteLine("The Givens rotation decomposition is stored in the matrix called 'S' (so as not to confuse it with the typical notation for the other relevant matrices), which contains the elements of the component R in the upper triangular part and the angles for the rotations in the relevant sub-diagonal entries.");
		S.G.print("Matrix S:");
		
		vector x = S.solve(b);
		x.print("Solution to A*x=b using Givens rotations:\n");

		Write("Checking that A^(-1)*A is the identity matrix:\n");
		(S.inverse()*A).printfloat("A^(-1)*A:");

		var C=A*x;
		C.print("Checking that A*x=b. A*x:\n");
		if(b.approx(A*x)) Write("A*x=b, test passed\n");
		else Write("A*x!=b, test failed\n");
}
}