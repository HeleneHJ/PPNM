using System;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;
using static cmath;
class main{
static bool approx(complex a, complex b, double acc, double eps){ //precision test
	if( abs(a-b)<acc )return true;
	if( abs(a-b)<eps*Max(abs(a),abs(b)))return true;
	return false;
}

static Func<complex,cvector,cvector> F=delegate(complex x, cvector y){ //defining our ODE
	return new cvector(y[1],-y[0]);
	};

static void Main(){
	complex I=new complex(0,1); 								 //complex i
	complex a=0.01+0.01*I; 										 //start value
	cvector ya=new cvector(0.100333+0.099666*I,0.999983-0.01*I); //function values of a (from WolframAlpha)
	complex b=2*PI+2*PI*I;			 							 //end value
	complex h=0.1+0.1*I;			 							 //step size
	double acc=1e-3;											 //accuracy	
	double eps=1e-3;											 //accuracy	
	var xs=new List<complex>();	
	var ys=new List<cvector>();	

	cvector y=ode.rk23(F,a,ya,b,acc:acc,eps:eps,h:h,xlist:xs,ylist:ys);	//solving the ODE

	Error.WriteLine("Exam project #5: Generalize the ODE solver of your choice to solve ODE with complex-valued functions of complex variable along a straight line between the given start- and end-point.\n");
	Error.WriteLine($"accuracy: acc={acc} eps={eps}");
	Error.WriteLine($"npoints={xs.Count}");
	Error.WriteLine($"start point:	a={a}, end point: b={b}");
	Error.WriteLine($"end point:	b={b}");
	Error.WriteLine($"Function values at start point: y0(a)={ya[0]} 	y1(a)={ya[1]}");
	Error.WriteLine($"Function values at end point:   y0(b)={y[0]}  	y1(b)={y[1]}");
	Error.WriteLine($"Expected values at end point:	sin(b)={sin(b)}  cos(b)={cos(b)}");
	if(approx(y[0],sin(b),acc,eps) && approx(y[1],cos(b),acc,eps))
		Error.WriteLine("test passed");
	else
	Error.WriteLine("test failed");

	Error.WriteLine("\nThough the result is very close to the expected result, I can't seem to be able to get it quite right.\n");
	// Error.WriteLine("One could have made plots of the result, but I have chosen not to since it was not specified in the exam description.\n");

	// for(int i=0;i<xs.Count;i++){ //for making plots
	// 	WriteLine($"{(xs[i]).Re} {(xs[i]).Im} {(ys[i][0]).Re} {(ys[i][0]).Im} {(ys[i][1]).Re} {(ys[i][1]).Im} {abs(ys[i][0])} {abs(ys[i][1])}");
	// }
}//Main
}//main