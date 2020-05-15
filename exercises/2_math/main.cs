using System;
using static System.Console;
using static System.Math;
using static cmath;
class main{
	static int Main(){
	WriteLine("A)");
		complex I = new complex(0,1);
		double x=2;	
		Write($"sqrt({x})={Sqrt(x)}\n");
		Write($"exp(i)={exp(I)}\n");
		complex eipi = exp(I*PI);
		Write($"exp(i*pi)={eipi.Re}+{eipi.Im:f0}i\n");	/* The real part is rounded down to 0 */
		Write($"i^i={exp(-PI/2)}\n"); /* According to wolfram-aplha, i^i = exp(-pi/2)*/
		Write($"sin(i*pi)={sin(I*PI)}\n");
	
	WriteLine("B)");
		complex sinhi = cfunctions.sinh(I);
		Write($"sinh(i)={sinhi}\n");
		complex coshi = cfunctions.cosh(I);
		Write($"cosh(i)={coshi}\n");
		complex sqrti = cfunctions.csqrt(I);
		Write($"sqrt(i)={sqrti}\n");
		complex sqrtminus1 = cfunctions.csqrt(-1);
		Write("sqrt(-1)={0:f0}+{1}i\n",sqrtminus1.Re,sqrtminus1.Im); /* The real part is rounded down to 0 */
	return 0;
	}
}