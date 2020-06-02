using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using static cmath;

public partial class ode{
public static cvector rk23(
	Func<complex,cvector,cvector> F, /* equation */
	complex a, cvector ya, /* initial condition: {a,y(a)} */
	complex b, 
	double h=0.1,
	double acc=1e-3,
	double eps=1e-3,
	// double h=0.1, 
	List<complex> xlist=null,
	List<cvector> ylist=null,
	int limit=999
){
return driver23( F, a, ya, b, acc, eps, h, xlist, ylist, limit, rkstep23 );}

public static cvector driver23(
	Func<complex,cvector,cvector> F, /* equation */
	complex a, cvector ya, complex b, 
	double acc, double eps, complex h, 
	List<complex> xlist, List<cvector> ylist,
	int limit,
	Func<
		Func<complex,cvector,cvector>,
		complex,cvector,complex,cvector[]
	> stepper
	){// Generic ODE driver
int nsteps=0;
if(xlist!=null) {xlist.Clear(); xlist.Add(a);}
if(ylist!=null) {ylist.Clear(); ylist.Add(ya);}
do{
	if(largerequal(a,b)==true) return ya;		// if a is larger than b (should be correct)
	if(nsteps>limit) {
		Error.Write($"ode.driver: nsteps>{limit}\n");
		return ya;
		}
	if(largest((a+h),b)==true) h=b-a; // if a+h is larger than b
	cvector[] trial=stepper(F,a,ya,h);
	cvector   yh=trial[0];
	cvector   er=trial[1];
	cvector tol = new cvector(er.size);
	for(int i=0; i<tol.size; i++){
		tol[i]=Max(acc,abs(yh[i])*eps)*sqrt(h/(b-a));
		if(equal(er[i],0)==true)er[i]=tol[i]/4;
		}
	complex factor=tol[0]/abs(er[0]);
	for(int i=1; i<tol.size; i++)
		factor=min(factor,abs(tol[i]/er[i]));
	complex hnew = h*min( pow(factor,0.25)*0.95, 2);
	int ok=1;
	for(int i=0;i<tol.size;i++)if(largest(abs(er[i]),(tol[i]))==true) ok=0;
	if(ok==1){
		a+=h; ya=yh; h=hnew; nsteps++;
		if(xlist!=null) xlist.Add(a);
		if(ylist!=null) ylist.Add(ya);
		}
	else { h=hnew; Error.WriteLine($"driver: bad step at {a}"); }
	}while(true);
}// driver23
}// class