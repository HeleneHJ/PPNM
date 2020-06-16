using System;
using static cmath;
public partial class ode{
public static cvector[] rkstep23(System.Func<complex,cvector,cvector> F, complex x, cvector y, complex h)
{// Embedded Runge-Kutta stepper of the order 2-3
	cvector k0 = F(x,y);
	cvector k1 = F(x+h/2, y+(h/2)*k0);
	cvector k2 = F(x+3*h/4, y+(3*h/4)*k1);
	cvector ka = (2*k0+3*k1+4*k2)/9;
	cvector kb = k1;
	cvector yh = y+ka*h;
	cvector err = (ka-kb)*h;
	cvector[] result={yh,err};
	return result;
}//rkstep23
}//class