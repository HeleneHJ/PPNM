using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;
public class B{
public static void Main(){
// for(int n=100;n<250;n+=10){
for(int n=50;n<250;n+=10){
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

	Stopwatch sw = new Stopwatch();
   	sw.Start();
	int sweeps=jacobi.cyclic(A,e,V);
	// matrix VTAV = V.T*B*V;
	// VTAV.printfloat("Should be diagional:");
	sw.Stop();
    WriteLine($"{n} {sw.ElapsedMilliseconds}");
}//for-loop
}//Main
}//B

    // Stopwatch swlow= new Stopwatch();
    // swlow.Start();
    // int low=jacobi.lowest(A2,e2,n,V2);
    // swlow.Stop();
    // WriteLine($"{n} {swlow.ElapsedMilliseconds}");
