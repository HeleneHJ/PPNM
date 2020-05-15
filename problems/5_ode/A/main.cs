using System;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;

class main{
static bool approx(double a,double b, double acc=1e-6, double eps=1e-6){
	if( Abs(a-b)<acc )return true;
	if( Abs(a-b)<eps*Max(Abs(a),Abs(b)) ) return true;
	return false;
}

static Func<double,vector,vector>
F=delegate(double x, vector y){
	return new vector(y[1],-y[0]);
		};

static void Main(){
	double a=0;
	vector ya=new vector(0,1);
	double b=2.25*PI;
	double h=0.1,acc=1e-3,eps=1e-3;
	var xs=new List<double>();
	var ys=new List<vector>();

vector y=ode.rk23(F,a,ya,b,acc:acc,eps:eps,h:h,xlist:xs,ylist:ys);

	Error.WriteLine($"acc={acc} eps={eps}");
	Error.WriteLine($"npoints={xs.Count}");
	Error.WriteLine($"a={a} y0({a})={ya[0]} y1({a})={ya[1]}");
	Error.WriteLine($"b={b}");
	Error.WriteLine($"y0 (b)={y[0]  }  y1(b)={y[1]}");
	Error.WriteLine($"sin(b)={Sin(b)} cos(b)={Cos(b)}");
if(approx(y[0],Sin(b),acc,eps) && approx(y[1],Cos(b),acc,eps))
	Error.WriteLine("test passed");
else
	Error.WriteLine("test failed");

	for(int i=0;i<xs.Count;i++)
		WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
}
}