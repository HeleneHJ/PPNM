using static System.Math;
using static cmath;
public static partial class specfunc{

public static complex gamma(complex z){
/// single precision gamma function (Gergo Nemes, from Wikipedia)
	if(z.Re<0)return PI/sin(PI*z)/gamma(1-z);
	if(z.Re<9)return gamma(z+1)/z;
	complex lngamma=z*log(z+1/(12*z-1/z/10))-z+log(2*PI/z)/2;
return exp(lngamma);
}
}