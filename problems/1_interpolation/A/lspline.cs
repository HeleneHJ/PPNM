/* NOTE: for practical application use cubic spline */
using System;
using System.Diagnostics;
public class lspline{

double[] x,y,p;

public static int binsearch(double[] x, double z){ /* locates the interval for z by bisection */ 
	int i=0, j=x.Length-1;
	while(j-i>1){
		int mid=(i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;
		}
	return i;
	}

public lspline(double[] xs, double[] ys){
	int n=xs.Length; 
	Trace.Assert(ys.Length>=n); /* Trace.Assert checks if a condition is false; if false, displays a message box that shows the call stack */
	x=new double[n];
	y=new double[n];
	p=new double[n-1];
	for(int i=0;i<n;i++){
		x[i]=xs[i];y[i]=ys[i];
	}
	for(int i=0;i<n-1;i++){
		p[i]=(y[i+1]-y[i])/(x[i+1]-x[i]);
		Trace.Assert((x[i+1]-x[i])>0);
	}
	}

public double eval(double z){
	Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
	int i=binsearch(x,z);
	double dx=z-x[i];
	return y[i]+p[i]*dx;
	}

public double integ(double z){
	Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
	int iz=binsearch(x,z);
	double sum=0,dx;
	for(int i=0;i<iz;i++){
		dx=x[i+1]-x[i];
		p[i]=(y[i+1]-y[i])/dx;
		sum+=dx*(y[i]+dx*(p[i])/2);   
		}
	dx=z-x[iz];
	sum+=dx*(y[iz]+dx*(p[iz])/2);
	return sum;
	}
}//lspline