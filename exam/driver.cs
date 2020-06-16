using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using static cmath;

public partial class ode{

public static cvector rk23(Func<complex,cvector,cvector> F, complex a, cvector ya, complex b, complex h, double acc, double eps, List<complex> xlist=null, List<cvector> ylist=null, int limit=9999){
	return driver23(F,a,ya,b,acc,eps,h,xlist,ylist,limit,rkstep23);
}//rk23

public static cvector driver23(Func<complex,cvector,cvector> F, complex a, cvector ya, complex b, double acc, double eps, complex h, List<complex> xlist, List<cvector> ylist, int limit, Func<Func<complex,cvector,cvector>,complex,cvector,complex,cvector[]> stepper){// Generic ODE driver
	int nsteps=0;
	Error.WriteLine($"driver1 h: {h}");
	if(xlist!=null) {xlist.Clear(); xlist.Add(a);}
	if(ylist!=null) {ylist.Clear(); ylist.Add(ya);}
	complex I = new complex(0,1);
	do{
		if(largerequal(a,b)==true) return ya;	//if a is larger than b
		if(nsteps>limit){
			Error.Write($"ode.driver: nsteps>{limit}\n");
			return ya;
		}	
		if(largest((a+h),b)==true) h=b-a; 	//if a+h is larger than b
		cvector[] trial=stepper(F,a,ya,h);
		cvector yh=trial[0];
		cvector er=trial[1];
		vector tol = new vector(er.size);
		for(int i=0; i<tol.size; i++){
			tol[i]=Max(acc,abs(yh[i])*eps)*sqrt(abs(h)/abs(b-a));
			if(equal(er[i],0)==true) er[i]=tol[i]/4;
		}
		double factor=tol[0]/abs(er[0]);
		for(int i=1; i<tol.size; i++){
			factor=Min(factor,(tol[i]/abs(er[i])));
		}
		complex hnew=h*min(pow(factor,0.25)*0.95,2);	
		int ok=1;
		for(int i=0;i<tol.size;i++) if(largest(abs(er[i]),tol[i])==true) ok=0; 
		if(ok==1){
			a+=h; ya=yh; h=hnew; nsteps++;
			if(xlist!=null) xlist.Add(a);
			if(ylist!=null) ylist.Add(ya);
		}
		else{h=hnew;} //Error.WriteLine($"driver: bad step at {a}"); }
	}while(true);
	}// driver23
}// class