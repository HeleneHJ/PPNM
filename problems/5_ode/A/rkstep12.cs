public partial class ode{
public static vector[]
rkstep12(System.Func<double,vector,vector> F, double x, vector y, double h)
{// Embedded Runge-Kutta stepper of the order 1-2
	vector k0 = F(x,y);			// Euler's method (1st order RK)
	vector k12 = F(x+h/2,y+(h/2)*k0);	// mid-point method (2nd order RK)
	vector k = k12;
	vector yh = y+k*h;
	vector err = h*(k-k0);
	vector[] result={yh,err};
	return result;
}//rkstep12
}//class