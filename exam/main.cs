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

static Func<complex,cvector,cvector>
F=delegate(complex x, cvector y){
	return new cvector(y[1],-y[0]);
	// return new cvector(y[1]=0,y[0]);
		};

static void Main(){
	complex I = new complex(0,1);
	complex a=(1.0/2)*PI+(1.0/2)*PI*I; // boundary condition
	// complex a=1+1*I;
	// cvector ya=new cvector(a,1.29845658+0.634963*I);	// boundary condition, {a,y(a)}
	cvector ya=new cvector(a,2.50917847866+0*I);	// boundary condition, {a,y(a)}
	complex b=PI+PI*I;				// "end" value
	complex h=0.01+0.01*I;				// step size
	double acc=1e-3;			// precision (used in "approx")
	double eps=1e-3;			// precision (used in "approx")
	var xs=new List<complex>();	// x-values (to be filled)
	var ys=new List<cvector>();	// y-values (to be filled)

cvector y=ode.rk23(F,a,ya,b,acc:acc,eps:eps,h:h,xlist:xs,ylist:ys);	// solving the ODE

/* Printing output to "Log"  */
	Error.WriteLine($"acc={acc} eps={eps}");
	Error.WriteLine($"npoints={xs.Count}");
	Error.WriteLine($"a={a}: y0(a)={ya[0]} y1(a)={ya[1]}");
	Error.WriteLine($"b={b}: y0(b)={y[0]:f7}  y1(b)={y[1]}");
	Error.WriteLine($"sin(b)={sin(b)} 	cos(b)={cos(b)}");

/* Test to see if the precision of our Runge-Kutta solution satisfies the true solution within the required precision */
if(approx(y[0],sin(b),acc,eps) && approx(y[1],cos(b),acc,eps))
	Error.WriteLine("test passed");
else
	Error.WriteLine("test failed");

	for(int i=0;i<xs.Count;i++)
		// WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
		// WriteLine($"{abs(xs[i])} {abs(ys[i][0])} {abs(ys[i][1])}");
		// WriteLine($"{(xs[i]).Re} {(ys[i][0]).Re} {(ys[i][1]).Re}");
		// WriteLine($"{(xs[i]).Re} {(xs[i]).Im} {abs(ys[i][0])} {abs(ys[i][1])}");
		WriteLine($"{(xs[i]).Re} {(xs[i]).Im} {(ys[i][0]).Re} {(ys[i][0]).Im} {(ys[i][1]).Re} {(ys[i][1]).Im}");
}
}