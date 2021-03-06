public partial class ode{
public static vector[]
rkstep45(System.Func<double,vector,vector> F, double x, vector y, double h)
{// Embedded Runge-Kutta stepper of the order 4-5
	vector k1 = F(x, y);
	vector k2 = F(x+(1*h/4), y+h*(1*k1/4));
	vector k3 = F(x+(3*h/8), y+h*(3*k1/32+9*k2/32));
	vector k4 = F(x+(12*h/13), y+h*(1932*k1/2197+(-7200)*k2/2197+7296*k3/2197));
	vector k5 = F(x+1*h, y+h*(439*k1/216+(-8)*k2+3680*k3/513+(-845)*k4/4104));
	vector k6 = F(x+h/2, y+h*((-8)*k1/27+2*k2+(-3544)*k3/2565+1859*k4/4104+(-11)*k5/40));
	vector k = 16*k1/135+6656*k3/12825+28561*k4/56430+(-9)*k5/50+2*k6/55;
	// vector yh = y+h*(25*k1/216+1408*k3/2565+2197*k4/4104+(-1)*k5/5); 
	vector yh = y+h*k; 
	vector err = h*(16*k1/135-25*k1/216+6656*k3/12825-1408*k3/2565+28561*k4/56430-2197*k4/4104+(-9)*k5/50-(-1)*k5/5+2*k6/25); 
	vector[] result={yh,err};
	return result;
}//rkstep45
}//class

// Butcher tableau:
// c1: 0	 |
// c2: 1/4	 |  a21: 1/4
// c3: 3/8	 |	a31: 3/32		a32: 9/32
// c4: 12/13 |	a41: 1932/2197	a42: -7200/2197	a43: 7296/2197
// c5: 1	 |	a51: 439/216	a52: -8			a53: 3680/513	 a54: -845/4104
// c6: 1/2	 |	a61: -8/27		a62: 2			a63: -3544/2565	 a64: 1859/4104 	a65: -11/40	
//___________________________________________________________________________________________________________
//			 |	b1: 16/135		b2: 0			b3: 6656/12825	 b4: 28561/56430	b5: -9/50		b6: 2/55
//			 |  b1*: 25/216		b2*: 0			b3*: 1408/2565	 b4*: 2197/4104		b5*: -1/5		b6*: 0


	// vector k1 = F(x,y);
	// vector k2 = F(x+h/4, y+h*(k1/4));
	// vector k3 = F(x+3*h/8, y+h*(3*k1/32+9*k2/32));
	// vector k4 = F(x+12*h/13, y+h*(1932*k1/2197+(-7200)*k2/2197+7296*k3/2197));
	// vector k5 = F(x+h, y+h*(439*k1/216+(-8)*k2+3680*k3/513+(-845)*k4/4104));
	// vector k6 = F(x+h/2, y+h*(((-8)*k1/27)+(2*k2)+((-3544)*k3/2565)+(1859*k4/4104)+((-11)*k5/40)));
	// vector k = 16*k1/135+6656*k3/12825+28561*k4/56430+(-9)*k5/50+2*k6/55;
	// vector yh = y+k*h; 
	// vector err = h*(16*k1/135-25*k1/216+6656*k3/12825-1408*k3/2565+28561*k4/56430-2197*k4/4104+(-9)*k5/50-(-1)*k5/5+2*k6/55); 
	// vector[] result={yh,err};
	// return result;
// }//rkstep45
// }//class

/*
The Runge–Kutta–Fehlberg method
(Source: en.wikipedia.org/wiki/List_of_Runge%E2%80%93Kutta_methods#Fehlberg_RK1(2)
*/