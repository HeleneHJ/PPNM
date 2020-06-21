using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using static cmath;

public partial class ode{

public static cvector rk23(Func<complex,cvector,cvector> F, complex a, cvector ya, complex b, complex h, double acc, double eps, List<complex> xlist=null, List<cvector> ylist=null, int limit=999){
	return driver(F,a,ya,b,acc,eps,h,xlist,ylist,limit,rkstep23);
}//rk23

public static cvector driver(Func<complex,cvector,cvector> F, complex a, cvector ya, complex b, double acc, double eps, complex h, List<complex> xlist, List<cvector> ylist, int limit, Func<Func<complex,cvector,cvector>,complex,cvector,complex,cvector[]> stepper){
	int nsteps=0;
	if(xlist!=null) {xlist.Clear(); xlist.Add(a);}
	if(ylist!=null) {ylist.Clear(); ylist.Add(ya);}		
	do{
		if(abs(a)>abs(b)) return ya; //making sure we have a proper interval

		complex I=new complex(0,1);	//complex i
		/* enforce that a straight line is taken between a and b */
		double relength=b.Re-a.Re;
		double imlength=b.Im-a.Im;
		double realres=h.Re/relength;
		double imres=h.Re/imlength;
		if(realres<imres) h=realres*relength+realres*imlength*I; 
		else h=imres*relength+imres*imlength*I; 

		/* stop when adding the step means overstepping the interval end value*/
		if(abs(a+h)>=abs(b)) return ya;	
		if(a.Re+h.Re>=b.Re) return ya; 
		if(a.Im+h.Im>=b.Im) return ya; 

		/* stop if the number of steps becomes larger than the limit */
		if(nsteps>limit){
			Error.Write($"ode.driver: nsteps>{limit}\n");
			return ya;
			}
		
		cvector[] trial=stepper(F,a,ya,h);	//calling rkstep23.cs (calculates the step to be taken)
		cvector yh=trial[0];				//function values
		double er=trial[1].norm();			//error
		double tol=(yh.norm()*eps+acc)*Sqrt(abs(h/(b-a)));	//tolerance
		
		complex hnew=h*min(pow(tol/er,0.25)*0.95,2); //eq. 40 (the adjusted step)
		int ok=1;
		if(er>tol) ok=0; 
		/* updating the x- and y-lists */
		if(ok==1){ 
			a+=h; ya=yh; h=hnew; nsteps++;
			if(xlist!=null) xlist.Add(a); 
			if(ylist!=null) ylist.Add(ya);
		}
		/* if precision has not been reached, adjust step size and try again */
		else{h=hnew;} //Error.WriteLine($"driver: bad step at {a}"); }
	}while(true);
	}//driver23
}//class