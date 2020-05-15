using System;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;
public class main{
	static int Main(string[] args){
	/* 		 u''(phi) + u(phi) = 1 + eps * u(phi)^2  
		<=>  u''(phi) = 1 - u(phi) + esp * u(phi) * u(phi) */

		double[] input = new double[4];
		for(int i = 0; i < args.Length; i++){
			input[i] = double.Parse(args[i]);
		}	

		double dx=0.1;
		vector ysolved;
		for(double xi=0.0;xi<4*PI;xi+=dx){
			ysolved = orbit(input[0], input[1], input[2], input[3]);
			Write("{0:f16} {1:f16}\n",xi, ysolved[0]);
		}
		return 0;		
	}

	static vector orbit(double epsilon, double y0, double yprime0, double xfinal){
		Func<double, vector, vector> ODE = (x, y) => new vector(y[1],1-y[0]+epsilon*y[0]*y[0]);

		double xinitial = 0;
		vector yinitital = new vector(y0, yprime0);

		List<double> xvalues = new List<double>();
		List<vector> yvalues = new List<vector>();

		vector ysolved=ode.rk23(ODE, xinitial, yinitital, xfinal, xlist:xvalues, ylist:yvalues);
	return ysolved;
	}
}