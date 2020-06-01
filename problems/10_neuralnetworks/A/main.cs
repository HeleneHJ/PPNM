using System;
using static System.Math;
using static System.Console;
class main{
static Func<double,double> f=(x)=>x*Exp(-x*x); // activation function
static Func<double,double> g=(x)=>Cos(5*x-1)*Exp(-x*x); // function to fit
static void Main(){
	int n=5;
	var ann=new network(n,f);
	double a=-1,b=1;
	int nx=20;
	var xs=new double[nx];
	var ys=new double[nx];
	for(int i=0;i<nx;i++){
		xs[i]=a+(b-a)*i/(nx-1);
		ys[i]=g(xs[i]);
		Write($"{xs[i]} {ys[i]}\n");
		}
	Write("\n\n");
	for(int i=0;i<ann.n;i++){
		ann.p[3*i+0]=a+(b-a)*i/(ann.n-1);
		ann.p[3*i+1]=1;
		ann.p[3*i+2]=1;
	}
	ann.p.fprint(Console.Error,"p=");
	ann.train(xs,ys);
	ann.p.fprint(Console.Error,"p=");
	for(double z=a;z<=b;z+=1.0/64)
		Write($"{z} {ann.feed(z)}\n");
	
}//Main
}//main