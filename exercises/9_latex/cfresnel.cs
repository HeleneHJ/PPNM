using System;
using static System.Math;
using static System.Console;
class main{
static int Main(){

Func<double,double> C=delegate(double x){
	Func<double,double> f=(t)=> Cos(t*t);
	return quad.o8av(f,0,x);
	};
for(double x=0;x<=10;x+=1.0/32)
	WriteLine($"{x} {C(x)}");

return 0;
}
}