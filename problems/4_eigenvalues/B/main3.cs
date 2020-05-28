using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;
public class B{
public static void Main(){
for(int n=2;n<50;n+=10){
	vector e=new vector(n);
	matrix V=new matrix(n,n);
	var rnd = new Random(1);
	matrix A = new matrix(n,n);
	for(int i=0;i<n;i++){
		for(int j=i;j<n;j++){
			A[i,j]=(rnd.NextDouble());  
			A[j,i]=A[i,j];
		}
	}
	matrix Alow=A.copy();
	matrix Ahigh=A.copy();
	matrix Vlow=V.copy();
	matrix Vhigh=V.copy();
	vector elow=e.copy();
	vector ehigh=e.copy();
	// matrix B=A.copy();

	// var sweeps=jacobi.cyclic(A,e,V);
	// var lowest=jacobi.lowest(Alow,elow,n,Vlow);		//full diagonalization with the lowest eigenvalue first
	// var highest=jacobi.highest(Ahigh,ehigh,n,Vhigh);	//full diagonalization with the highest eigenvalue first
	var sweeps=jacobi.cyclic(A,e,V);
	// matrix VTAV = V.T*B*V;
	// VTAV.printfloat("Should be diagional:");
	var lowest=jacobi.lowest(Alow,elow,n,Vlow);		//only the one lowest eigenvalue
	// matrix VTAVlow = Vlow.T*B*Vlow;
	// VTAVlow.printfloat("Should be diagional:");
	var highest=jacobi.highest(Ahigh,ehigh,n,Vhigh);	//only the one highest eigenvalue
	// matrix VTAVhigh = Vhigh.T*B*Vhigh;
	// VTAVhigh.printfloat("Should be diagional:");
	WriteLine($"{n} {sweeps} {lowest} {highest}");
	}
}//Main
}//B