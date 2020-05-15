using System;
public class hydrogen{

public static double Fe(double e, double r){
	double rmin = 1e-3;
	if(r<rmin) return r-r*r;

	Func<double,vector,vector> swave = (x,y)=>
	{ /* -(1/2)f'' - (1/r)f = e f */
		return new vector(y[1], 2*(-1/x-e)*y[0]);
	};

	vector yrmin = new vector(rmin-rmin*rmin, 1-2*rmin);
	vector yrmax = ode.rk23(swave,rmin,yrmin,r,h:0.001);
	return yrmax[0];
}
}//class