using System;
using static System.Console;
using static System.Math;
class main{
static void Main(){
	var t0=new vector(new double[]{1,2,3,4,6,9,10,13,15});
	var y0=new vector(new double[]{117,100,88,72,53,29.5,25.2,15.2,11.1});
	var dy0=0.05*y0;
	var f=new Func<double,double>[]{x=>1,x=>x};
	int n=t0.size;
	vector t=new vector(n);
	vector y=new vector(n);
	vector dy=new vector(n);
	for(int i=0;i<n;i++){
		t[i]=t0[i];
		y[i]=Log(y0[i]);
		dy[i]=dy0[i]/y0[i];
	}
 	var fit=new lsfit(t,y,y0,f);

	for(int i=0;i<n;i++){
		WriteLine($"{t0[i]} {y0[i]} {dy0[i]}");
	}

	// double z;
	// int k;
	// int N=100;
	// for(z=t[0],k=0;k<N;z=t[0]+(++k)*0.1){
	// 	WriteLine($"{z} {Exp(fit.eval(z))}");
	// }	

	int k,N=100;
	double z, step=(t[t.size-1]-t[0])/(N-1);

	WriteLine(); WriteLine();
	for(z=t[0], k=0;k<N;z=t[0]+(++k)*step)
		WriteLine($"{z} {Exp(fit.eval(z))}");
	}
}