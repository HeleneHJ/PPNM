using System;
using static System.Math;
using static System.Console;
class main{
const double inf=double.PositiveInfinity;
static void Main(){

Func<double,double> norm=delegate(double a){
	Func<double,double> f=(x)=> Exp(-a*x*x);
	return quad.o8av(f,-inf,inf);
	};

Func<double,double> expect=delegate(double a){
	Func<double,double> f=(x)=> (-a*a*x*x/2+a/2+x*x/2)*Exp(-a*x*x);
	return quad.o8av(f,-inf,inf);
	};

Func<double,double> E=(a)=>expect(a)/norm(a);
for(double a=1.0/16;a<=4;a+=1.0/32)
	WriteLine($"{a} {E(a)}");

}
}

