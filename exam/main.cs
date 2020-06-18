using System;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;
using static cmath;
class main{
static bool approx(complex a, complex b, double acc, double eps){
	if( abs(a-b)<acc )return true;
	if( abs(a-b)<eps*Max(abs(a),abs(b)))return true;
	return false;
}

static Func<complex,cvector,cvector> F=delegate(complex x, cvector y){
	return new cvector(y[1],-y[0]);
	};

static void Main(){
	complex I=new complex(0,1);
	complex a=-PI+PI*I;
	cvector ya=new cvector(0+11.54873935*I,-11.54873935-0*I);
	complex b=PI+PI*I;
	// complex h=0.1+0.01*I;
	complex h=0.1+0.001*I;
	double acc=1e-3;			
	double eps=1e-3;			
	var xs=new List<complex>();	
	var ys=new List<cvector>();	

	cvector y=ode.rk23(F,a,ya,b,acc:acc,eps:eps,h:h,xlist:xs,ylist:ys);	

	Error.WriteLine($"acc={acc} eps={eps}");
	Error.WriteLine($"npoints={xs.Count}");
	Error.WriteLine($"a={a}: y0(a)={ya[0]} y1(a)={ya[1]}");
	Error.WriteLine($"b={b}: y0(b)={y[0]}  y1(b)={y[1]}");
	Error.WriteLine($"	  sin(b)={sin(b)}  cos(b)={cos(b)}");


	if(approx(y[0],sin(b),acc,eps) && approx(y[1],cos(b),acc,eps))
		Error.WriteLine("test passed");
	else
		Error.WriteLine("test failed");
	Error.WriteLine("\nI can't seem to be able to get it quite right (there seems to be a sign error).");
	Error.WriteLine("I have made separate plots of the real and imaginary parts of both functions (sin(z) and cos(z)).");
	Error.WriteLine("Though not as precise as I would have liked, they do seem quite similar to the same plots from WolframAlpha (also in the folder).");

	for(int i=0;i<xs.Count;i++){
		WriteLine($"{(xs[i]).Re} {(xs[i]).Im} {(ys[i][0]).Re} {(ys[i][0]).Im} {(ys[i][1]).Re} {(ys[i][1]).Im} {abs(ys[i][0])} {abs(ys[i][1])}");
	}
}//Main
}//main