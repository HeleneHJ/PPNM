using System;
using static System.Math;
using static System.Double;
public partial class quad{
public static double clenshawcurtis(Func<double,double> f, double a, double b, 
	double acc, double eps){
	Func<double,double> h = (x) => 0.5*(b-a)*f(0.5*(a+b)+0.5*(b-a)*x);
	Func<double,double> g = (theta) => h(Cos(theta))*Sin(theta);

	return adapt4(g,0,PI,acc,eps);
}
}