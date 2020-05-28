using System;
using static System.Console;
public class test{
public static void Main(string[] args){
	int n=5; //size of real symmetric matrix 
	matrix A=new matrix(n,n);
	var rnd=new Random(1);
	for(int i=0;i<n;i++){						/* Construction of a random vector */
		for(int j=0;j<n;j++){
			A[i,j]=(rnd.NextDouble()*10);
			A[j,i]=A[i,j];						/* We make sure that the matrix is symmetric */
	}
	}
	A.print("Random symmetric matrix, A:");
	matrix V=new matrix(n,n);
	vector e=new vector(n);
	matrix B=A.copy(); 						/* We make a copy of A */

	int sweeps=jacobi.cyclic(A,e,V); 			/* We use the jacobi matlib for the implementation of the cyclic sweeps: public static int cyclic(matrix A, vector e, matrix V=null){...} */
	WriteLine($"\nNumber of sweeps: {sweeps}");
	matrix D=(V.T*B*V);
	// D.print("\nEigenvalue-decomposition, V^T*A*V (should be diagonal):"); 
	D.printfloat("\nEigenvalue-decomposition, V^T*A*V (should be diagonal):"); 		/* using my print2 to get 0's instead of values with e.g. "e-16"*/
	e.print("\nEigenvalues:\n");
}
}