using System;
using static System.Math;
using static System.Console;
class main{
static Func<double,double> f=(x)=>x*Exp(-x*x); 	//activation function (Gaussian wavelet)
static Func<double,double> df=(x)=>Exp(-x*x)*(1-2*x*x); 	//activation function (Gaussian wavelet)
static Func<double,double> F=(x)=>-Exp(-x*x)/2; 	//activation function (Gaussian wavelet)
static Func<double,double> g=(x)=>Sin(x); 		//function to fit (wavelet)
static Func<double,double> dg=(x)=>Cos(x); 		//derivative of g
static Func<double,double> G=(x)=>-Cos(x); 		//anti-derivative of g
static void Main(){
	int n=5;					//number of sets of parameters
	var ann=new network(n,f,df,F);	//creating a new "network" using n and our activation function f
	double a=-PI,b=2*PI;			//a: "start" value, b: "end" value
	int nx=30;					//length of xs and ys
	var xs=new double[nx];
	var ys=new double[nx];
	for(int i=0;i<nx;i++){
		xs[i]=a+(b-a)*i/(nx-1);	//interval of x inbetween a and b
		ys[i]=g(xs[i]);			//function values of function to fit 
		Write($"{xs[i]}	{ys[i]} {dg(xs[i])} {G(xs[i])}\n");
		}
	Write("\n\n");
	for(int i=0;i<ann.n;i++){
		ann.p[3*i+0]=a+(b-a)*i/(ann.n-1);	//a
		ann.p[3*i+1]=1;						//b
		ann.p[3*i+2]=1;						//w
	}
	ann.p.fprint(Console.Error,"p=");
	ann.train(xs,ys);					//calling "train" which minimizes the deviation given our x's and y's
	double offset = G(xs[0])-ann.feedF(xs[0]);
	ann.p.fprint(Console.Error,"p=");
	for(double z=a;z<=b;z+=1.0/64)
		Write($"{z} {ann.feed(z)} {ann.feeddf(z)} {ann.feedF(z)+offset}\n");	//calling "feed" which returns the output signal

}//Main
}//main