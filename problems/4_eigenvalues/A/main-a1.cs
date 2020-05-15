using System;

public class test{

public static void Main(string[] args){
int n=5;
var rnd = new Random(1);
var a = new matrix(n,n);
vector e = new vector(n);
matrix v = new matrix(n,n);
for(int i=0;i<n;i++)for(int j=i;j<n;j++)
	{
	a[i,j]=2*(rnd.NextDouble()-0.5); a[j,i]=a[i,j];
	}
Console.WriteLine("Eigenvalue Decomposition A=V*D*V^T");
a.print("Random symmetric matrix A:");
matrix b = a.copy();
int sweeps=jacobi.cyclic(a,e,v);
System.Console.WriteLine("Number of sweeps={0}",sweeps);
var k=(v.T*b*v);
k.print("V^T*A*V (should be diagonal):");
e.print("Eigenvalues (should equal the diagonal elements above):\n");
}
}