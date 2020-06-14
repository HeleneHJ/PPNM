using System;
using static System.Math;
using static System.Console;
class main{
static Func<double,double> f=(x)=>x*Exp(-x*x); 			//activation function (Gaussian wavelet)
static Func<double,double> g=(x)=>Sin(x); 				//function to fit (wavelet)
static void Main(){
	int n=5;					//number of sets of parameters
	var ann=new network(n,f);	//creating a new "network" using n and our activation function f
	// double a=-1,b=1;			//a: "start" value, b: "end" value
	double a=-2,b=2;
	int nx=30;					//length of xs and ys
	var xs=new double[nx];
	var ys=new double[nx];
	for(int i=0;i<nx;i++){
		xs[i]=a+(b-a)*i/(nx-1);	//interval of x (with the choice of these specific parameters -1+2*i/19, i.e., x goes from -1 to 1)
		ys[i]=g(xs[i]);			//function values of function to fit 
		Write($"{xs[i]}	{ys[i]}\n");
		}
	Write("\n\n");
	for(int i=0;i<ann.n;i++){
		ann.p[3*i+0]=a+(b-a)*i/(ann.n-1);	//a
		ann.p[3*i+1]=1;						//b
		ann.p[3*i+2]=1;						//w
	}
	ann.p.fprint(Console.Error,"p=");
	ann.train(xs,ys);					//calling "train" which minimizes the deviation given our x's and y's
	ann.p.fprint(Console.Error,"p=");
	for(double z=a;z<=b;z+=1.0/64)
		Write($"{z} {ann.feed(z)}\n");	//calling "feed" which returns the output signal
	

	WriteLine("\n");
	Func<double,double> G = (x) => -Cos(x);
	Func<double,double> gprime = (x) => Cos(x);

	for(double z=a;z<=b;z+=1.0/64){
		WriteLine($"{z}	{ann.feed(z)} {ann.integ(G,z)} {ann.deriv(z)}");	//calling "feed" which returns the output signal
	}
	

}//Main
}//main