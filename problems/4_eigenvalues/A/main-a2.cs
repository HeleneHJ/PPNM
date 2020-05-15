using System;
using static System.Console;
using static System.Math;
public class main{

public static void Main(string[] args){
int n=99;

var H = new matrix(n,n);
var e = new vector(n);
var V = new matrix(n,n);
double s=1.0/(n+1);
for(int i=0;i<n-1;i++){
  matrix.set(H,i,i,-2);
  matrix.set(H,i,i+1,1);
  matrix.set(H,i+1,i,1);
  }
matrix.set(H,n-1,n-1,-2);
matrix.scale(H,-1/s/s);
int sweeps=jacobi.cyclic(H,e,V);

for (int k=0; k < Min(n/3,30); k++){
    double calculated = e[k];
    double exact = PI*PI*(k+1)*(k+1);
    WriteLine($"{k} {calculated} {exact}");
}

WriteLine();
WriteLine();

for(int k=0;k<5;k++){
  WriteLine($"{0} {0}");
  for(int i=0;i<n;i++){
	double factor=Sign(V[0,k])/Sqrt(s);
	WriteLine($"{(i+1.0)/(n+1)} {matrix.get(V,i,k)*factor}");
	}
  WriteLine($"{1} {0}\n");
  }


}//Main
}//main