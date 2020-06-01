using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){

{
	int calls=0; 
	double a=0,b=1,acc=1e-3,eps=1e-3;
	Func<double,double> f=delegate(double x){calls++;return 1/Sqrt(x);};
	WriteLine($"Integral: ∫_{a}^{b} 1/Sqrt(x) dx, acc={acc}, eps={eps}");
	double exact=2.0;
	double Q=quad.adapt4(f,a,b,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"result={Q    :f6}, tolerance={tol :e3}, calls={calls}\n");
	Write($"exact ={exact:f6}, error    ={aerr:e3}, ");
	if(aerr<tol)WriteLine("test passed\n");
	else WriteLine("test failed\n");
	}
{
	int calls=0; 
	double a=0,b=1,acc=1e-6,eps=0;
	Func<double,double> f=delegate(double x){calls++;return 4*Sqrt(1-x*x);};
	WriteLine($"Integral: ∫_{a}^{b} 4*Sqrt(1-x^2) dx, acc={acc}, eps={eps}");
	double exact=PI;
	double Q=quad.adapt4(f,a,b,acc,eps,limit:100);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"result={Q    }, tolerance={tol :e3}, calls={calls}\n");
	Write($"exact ={exact}, error    ={aerr:e3}, ");
	if(aerr<tol)WriteLine("test passed\n");
	else WriteLine("test failed\n");
	}
}
}