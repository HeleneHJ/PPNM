using System;
using static System.Math;
using static System.Console;
using static System.Double;
public static partial class quad{
public static double adapt4(
	Func<double,double> f,double a,double b,
	double acc=1e-3, double eps=1e-3, int limit=99,
	double f2=NaN, double f3=NaN)
{
	double f1=f(a+(b-a)/6), f4=f(a+5*(b-a)/6);				// x_i (eq. 48 & 51) used to define f(x_i)
	if(IsNaN(f2)){f2=f(a+2*(b-a)/6); f3=f(a+4*(b-a)/6);} 	//f2 and f3 are inherited from the previous step
	double Q=(2*f1+f2+f3+2*f4)/6*(b-a);						// higher order (trapezium rule) (eq. 44 & eq. 48 & 51)
	double q=(f1+f2+f3+f4)/4*(b-a);							// lower order (rectangle rule) (eq. 45 & eq. 49 & 51)
	double err=Abs(Q-q)/Sqrt(2);							// error estimate (eq. 46)
	if(limit==0){
		Error.WriteLine($"adapt: limit reached: a={a} b={b}");
		return Q;
		}
	if(err<acc+eps*Abs(Q)){		// the error is smaller than the tolerance (eq. 47)
		return Q;
		}
	else{
		double Q1=adapt4(f,a,(a+b)/2,acc/Sqrt(2),eps,limit-1,f1,f2); //if we do not reach our accuracy, we divide the integral into two (Q1, Q2) and calculate each
		double Q2=adapt4(f,(a+b)/2,b,acc/Sqrt(2),eps,limit-1,f3,f4);	// until the accuracy or limit is reached
		return Q1+Q2;
		}
}
}