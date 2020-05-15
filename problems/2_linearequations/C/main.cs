using System;
using static System.Console;
using static System.Math;

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
		A.print("Random matrix A:\n"); 
		b.print("Random vector b:\n");

		QRgivens GR = new QRgivens(A); /* decomposition via Givens rotations*/
		WriteLine("The Givens rotation decomposition is stored in the resulting matrix GR, which contains the elements of the component R in the upper triangular part and the angles for the Givens rotations in the relevant sub-diagonal entries:");
		GR._G.print("GR:");
		
		vector x = GR.solve(b);
		x.print("\nSolution to A*x=b using Givens rotations: \n");

		Write("\nChecking that A^(-1)*A is the identity matrix:\n");
		(GR.inverse()*A).print("A^(-1)*A:");
	}
}