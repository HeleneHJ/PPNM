using System;
public class hydrogen{
public static double F_eps(double eps,double r){
	double r_min=1e-3;		   // limit for r -> 0
	if(r<r_min) return r-r*r;  // f(r->0) = r-r^2

	/*	 The Schrödinger Equation: 	-1/2f''-(1/r)f = εf 
							  <=>  	f'' = -2( εf + (1/r)f )		*/
	Func<double,vector,vector> s_wave = delegate(double x,vector f){
		return new vector(f[1],-2*(eps*f[0]+f[0]/x));	// f = f[0], f'' = f[1]
	};
	
	vector f_rmin=new vector(r_min-r_min*r_min, 1-2*r_min);	// boundary condition: r_min = r_min-r_min^2, r'_min = 1-2r_min
	vector f_rmax=ode.rk23(s_wave,r_min,f_rmin,r,h:0.001);	// solving the Schrödinger equation using the ODE solver
	return f_rmax[0];	// return the lowest root eps_0
}//F_eps
}//class hydrogen