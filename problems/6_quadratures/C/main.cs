using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	
	double acc=1e-3,eps=1e-3;
	double posinf=double.PositiveInfinity;
	double neginf=double.NegativeInfinity;

{
	int calls=0, callso8av=0;
	Func<double,double> f=delegate(double x){calls++;return Exp(-(x*x));};
	Func<double,double> fo8av=delegate(double x){callso8av++;return Exp(-(x*x));};
	WriteLine($"Integral: ∫_-∞^+∞ Exp(-(x*x)) dx, acc={acc} eps={eps}");
	double exact=Sqrt(PI);
	double Q=quad.inflimit(f,neginf,posinf,acc,eps);
	double Qo8av=quad.o8av(fo8av,neginf,posinf,acc,eps);
	WriteLine("  Solution using integrator with infinite limits:");
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"	result={Q    :f16}, tolerance={tol :e3}, calls={calls}\n");
	Write($"	exact ={exact:f16}, error    ={aerr:e3}, ");
	if(aerr<tol)WriteLine("test passed");
	else WriteLine("test failed");
	WriteLine("  Solution using o8av:");
	double aerro8av=Abs(Qo8av-exact),tolo8av=acc+eps*Abs(Qo8av);
	Write($"	result={Qo8av    :f16}, tolerance={tolo8av :e3}, calls={callso8av}\n");
	Write($"	exact ={exact:f16}, error    ={aerro8av:e3}, ");
	if(aerro8av<tolo8av)WriteLine("test passed\n");
	else WriteLine("test failed\n");
	}


{
	int calls=0, callso8av=0;
	Func<double,double> f=delegate(double x){calls++;return x*Exp(x);};
	Func<double,double> fo8av=delegate(double x){callso8av++;return x*Exp(x);};
	WriteLine($"Integral: ∫_-∞^0 x*Exp(x) dx, acc={acc} eps={eps}");
	double exact=-1.0;
	double Q=quad.inflow(f,neginf,0,acc,eps);
	double Qo8av=quad.o8av(fo8av,neginf,0,acc,eps);
	WriteLine("  Solution using integrator with infinite limits:");
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"	result={Q    :f16}, tolerance={tol :e3}, calls={calls}\n");
	Write($"	exact ={exact:f16}, error    ={aerr:e3}, ");
	if(aerr<tol)WriteLine("test passed");
	else WriteLine("test failed");
	WriteLine("  Solution using o8av:");
	double aerro8av=Abs(Qo8av-exact),tolo8av=acc+eps*Abs(Qo8av);
	Write($"	result={Qo8av    :f16}, tolerance={tolo8av :e3}, calls={callso8av}\n");
	Write($"	exact ={exact:f16}, error    ={aerro8av:e3}, ");
	if(aerro8av<tolo8av)WriteLine("test passed\n");
	else WriteLine("test failed\n");
	}


{
	int calls=0, callso8av=0;
	Func<double,double> f=delegate(double x){calls++;return 1/(1+(x*x));};
	Func<double,double> fo8av=delegate(double x){callso8av++;return 1/(1+(x*x));};
	WriteLine($"Integral: ∫_0^+∞ 1/(1+x^2) dx, acc={acc} eps={eps}");
	double exact=PI/2;
	double Q=quad.infhigh(f,0,posinf,acc,eps);
	double Qo8av=quad.o8av(fo8av,0,posinf,acc,eps);
	WriteLine("  Solution using integrator with infinite limits:");
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"	result={Q    :f16}, tolerance={tol :e3}, calls={calls}\n");
	Write($"	exact ={exact:f16}, error    ={aerr:e3}, ");
	if(aerr<tol)WriteLine("test passed");
	else WriteLine("test failed");
	WriteLine("  Solution using o8av:");
	double aerro8av=Abs(Qo8av-exact),tolo8av=acc+eps*Abs(Qo8av);
	Write($"	result={Qo8av    :f16}, tolerance={tolo8av :e3}, calls={callso8av}\n");
	Write($"	exact ={exact:f16}, error    ={aerro8av:e3}, ");
	if(aerro8av<tolo8av)WriteLine("test passed\n");
	else WriteLine("test failed\n");
	}

WriteLine("The 'o8av' integration routine is also faster at determining integrals with infinite limits, however it is not as accurate as the other integration routine.");
}
}