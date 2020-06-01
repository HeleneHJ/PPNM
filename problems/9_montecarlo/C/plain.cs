using System;
using static System.Console;
using static System.Math;
using static System.Double;

public partial class montecarlo{

public static double[] plain
(Func<vector,double> f, double[] a, double[] b, int npoints, Random RND=null){
	if(RND==null)RND=new Random();
	double volume=1; for(int i=0;i<a.Length;i++) volume*=(b[i]-a[i]);
	var x=new vector(a.Length);
	double average=0,variance=0;
	for(int n=0;n<npoints;n++){
		for(int i=0;i<x.size;i++) x[i]=a[i]+RND.NextDouble()*(b[i]-a[i]);
		double fx=f(x);
		double d1=fx-average;
                average+=d1/(n+1);
		double d2=fx-average;
		variance += d1*d2;
                }
	variance/=(npoints-1);
	return new double[] {average*volume,variance*volume/Sqrt(npoints)};
	}

}//class