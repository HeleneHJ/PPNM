using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using static cmath;

public partial class ode{

public static cvector rk23(Func<complex,cvector,cvector> F, complex a, cvector ya, complex b, complex h, double acc, double eps, List<complex> xlist=null, List<cvector> ylist=null, int limit=999){
	return driver23(F,a,ya,b,acc,eps,h,xlist,ylist,limit,rkstep23);
}//rk23

public static cvector driver23(Func<complex,cvector,cvector> F, complex a, cvector ya, complex b, double acc, double eps, complex h, List<complex> xlist, List<cvector> ylist, int limit, Func<Func<complex,cvector,cvector>,complex,cvector,complex,cvector[]> stepper){// Generic ODE driver
	complex I = new complex(0,1);
	int nsteps=0;
	if(xlist!=null) {xlist.Clear(); xlist.Add(a);}
	if(ylist!=null) {ylist.Clear(); ylist.Add(ya);}
	do{
		if(abs(a)>=abs(b)) return ya;
		if(nsteps>limit){
			Error.Write($"ode.driver: nsteps>{limit}\n");
			return ya;
			}
// /**/
// 		double relength=b.Re-a.Re;
// 		double imlength=b.Im-a.Im;
// 		double realres=h.Re/relength;
// 		double imres=h.Re/imlength;
// 		double sres;
// 		if(realres<imres) sres=realres;
// 		else sres=imres;
// 		h=sres*relength+sres*imlength*I;
// /**/
		if(abs(a)+abs(h)>abs(b)) h=b-a;

		cvector[] trial=stepper(F,a,ya,h);
		cvector yh=trial[0];
		cvector er=trial[1];
		cvector tol = new cvector(er.size);
		for(int i=0; i<tol.size; i++){
			tol[i]=max(acc,abs(yh[i])*eps+acc)*sqrt(h/b-a); //eq. 41
			if(abs(er[i])==0) er[i]=tol[i]/4;
			}
		double factor=abs(tol[0]/er[0]);
		for(int i=1; i<tol.size; i++){ 
			factor=Min(factor,abs(tol[i]/er[i]));
			}
		complex hnew=h*min(pow(factor,0.25)*0.95,2); //eq. 40
		int ok=1;
		for(int i=0;i<tol.size;i++) if(abs(er[i])>abs(tol[i])) ok=0; 
		if(ok==1){
			a+=h; ya=yh; h=hnew; nsteps++;
			if(xlist!=null) xlist.Add(a);
			if(ylist!=null) ylist.Add(ya);
		}
		else{h=hnew;} //Error.WriteLine($"driver: bad step at {a}"); }
	}while(true);
	}// driver23
}// class