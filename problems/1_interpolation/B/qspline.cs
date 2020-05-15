/* NOTE: quadratic spline is only for learning, for practical application use cubic spline */
using System;
using static System.Math;
using System.Diagnostics;
public class qspline{

double[] x,y,p,c;

public static int binsearch(double[] x, double z){
	int i =0, j=x.Length-1;
	while(j-i>1){
		int mid=(i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;	
	}
	return i;
}

public qspline(double[] xs, double[] ys){ /* calculate p and c */
	int n=xs.Length; Trace.Assert(ys.Length>=n);
	x=new double[n];
	y=new double[n];
	p=new double[n-1];
	c=new double[n-1];
	for(int i=0;i<n;i++){x[i]=xs[i];y[i]=ys[i];}
	for(int i=0;i<n-1;i++){
		p[i]=(y[i+1]-y[i])/(x[i+1]-x[i]);
		}
	c[0]=0;
	for(int i=1;i<n-1;i++){
		c[i]=(p[i]-p[i-1]-c[i-1]*(x[i]-x[i-1])/(x[i+1]-x[i]));
		}
	for(int i=n-3;i>=0;i--){
		c[i]=(p[i+1]-p[i]-c[i+1]*(x[i+2]-x[i+1]))/(x[i+1]-x[i]);
		}
	}//construcntor

public double eval(double z){/* evaluation of the spline at point z */
	Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
	int i=binsearch(x,z);
	double dx=z-x[i];/* calculate the inerpolating spline : */
	return y[i]+p[i]*dx+c[i]*dx*(z-x[i+1]);
	}

public double deriv(double z){/* evaluate the derivative */ 
	Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
	int i=binsearch(x,z);
	// double dx=z-x[i];/* calculate the inerpolating spline : */
	return p[i]-c[i]*(x[i+1]-x[i])+2*c[i]*(z-x[i]);
	}
	
public double integ(double z){ /* evaluate the integral */ 
	Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
	// int iz=binsearch(x,z);
	int i=binsearch(x,z);
	double sum=0;
	double dx,b;
	for(int j=0;j<i;j++){
		dx=x[j+1]-x[j];
		b=p[j]-c[j]*dx;
		sum+=dx*(c[j]*dx*dx/3+b*dx/2+y[j]);
	}
	dx=z-x[i];
	b=p[i]-c[i]*(x[i+1]-x[i]);
	return sum+=dx*(c[i]*dx*dx/3+b*dx/2+y[i]);
	}	
}//qspline