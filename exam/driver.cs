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

public static cvector driver23(Func<complex,cvector,cvector> F, complex a, cvector ya, complex b, double acc, double eps, complex h, List<complex> xlist, List<cvector> ylist, int limit, Func<Func<complex,cvector,cvector>,complex,cvector,complex,cvector[]> stepper){
	int nsteps=0;
	if(xlist!=null) {xlist.Clear(); xlist.Add(a);}
	if(ylist!=null) {ylist.Clear(); ylist.Add(ya);}		
	do{
		if(abs(a+h)>=abs(b)) return ya;	
		if(a.Re+h.Re>=b.Re) return ya;	

		if(nsteps>limit){
			Error.Write($"ode.driver: nsteps>{limit}\n");
			return ya;
			}
		
		if(abs(a+h)>abs(b)) h=b-a; 
		cvector[] trial=stepper(F,a,ya,h);
		cvector yh=trial[0];
		double er=trial[1].norm();
		double tol=(yh.norm()*eps+acc)*Sqrt(abs(h/(b-a)));
		
		complex hnew=h*min(pow(tol/er,0.25)*0.95,2); //eq. 40
		int ok=1;
		if(er>tol) ok=0; 
		if(ok==1){
			a+=h; ya=yh; h=hnew; nsteps++;
			if(xlist!=null) xlist.Add(a);
			if(ylist!=null) ylist.Add(ya);
		}
		else{h=hnew;} //Error.WriteLine($"driver: bad step at {a}"); }
	}while(true);
	}//driver23
}//class