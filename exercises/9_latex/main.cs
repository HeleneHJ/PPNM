using System;
using static System.Math;
using static System.Console;
class main{
static int Main(){

Func<double,double> S=delegate(double x){
	Func<double,double> f=(a)=> Sin(a*a);
	return quad.o8av(f,0,x);
	};
for(double x=1.0/16;x<=10;x+=1.0/32)
	WriteLine($"{x} {S(x)}");

return 0;
}
}