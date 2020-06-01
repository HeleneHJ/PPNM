using System;
using static System.Math;
using static System.Double;
public partial class quad{
public static double inflimit(Func<double,double> f, double a, double b, 
	double acc, double eps){
	Func<double,double> h = (t) => (f((1.0-t)/t)+f(-(1.0-t)/t))*1.0/(t*t); // Eq. 58
	return adapt4(h,0,1,acc,eps);
}

public static double infhigh(Func<double,double> f, double a, double b, 
	double acc, double eps){
	Func<double,double> h = (t) => (f(a+(1.0-t)/t)/(t*t)); // Eq. 60
	return adapt4(h,0,1,acc,eps);
}

public static double inflow(Func<double,double> f, double a, double b, 
	double acc, double eps){
	Func<double,double> h = (t) => (f(b-(1.0-t)/t))/(t*t); // Eq. 62
	return adapt4(h,0,1,acc,eps);
}
}