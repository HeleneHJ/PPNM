using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	double a=0,b=1,acc=1e-3,eps=1e-3;

{
	int calls=0, callswo=0;
	Func<double,double> f=delegate(double x){calls++;return 1/Sqrt(x);};
	Func<double,double> fwo=delegate(double x){callswo++;return 1/Sqrt(x);};
	
	WriteLine($"Integral: ∫_{a}^{b} 1/Sqrt(x) dx, acc={acc} eps={eps}");
	double exact=2.0;
	double Q=quad.clenshawcurtis(f,a,b,acc,eps);
	double Qwo=quad.adapt4(fwo,a,b,acc,eps);
	WriteLine("  Solution using Clenshaw-Curtis transformation:");
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"	result={Q    :f6}, tolerance={tol :e3}, calls={calls}\n");
	Write($"	exact ={exact:f6}, error    ={aerr:e3}, ");
	if(aerr<tol)WriteLine("test passed");
	else WriteLine("test failed");
	WriteLine("  Solution without Clenshaw-Curtis transformation:");
	double aerrwo=Abs(Qwo-exact),tolwo=acc+eps*Abs(Qwo);
	Write($"	result={Qwo    :f6}, tolerance={tolwo :e3}, calls={callswo}\n");
	Write($"	exact ={exact:f6}, error    ={aerrwo:e3}, ");
	if(aerrwo<tolwo)WriteLine("test passed\n");
	else WriteLine("test failed\n");
	}

{
	int calls=0, callswo=0;
	Func<double,double> f=delegate(double x){calls++;return Log(x)/Sqrt(x);};
	Func<double,double> fwo=delegate(double x){callswo++;return Log(x)/Sqrt(x);};
	
	WriteLine($"Integral: ∫_{a}^{b} Log(x)/Sqrt(x) dx, acc={acc} eps={eps}");
	double exact=-4.0;
	double Q=quad.clenshawcurtis(f,a,b,acc,eps);
	double Qwo=quad.adapt4(fwo,a,b,acc,eps);
	WriteLine("  Solution using Clenshaw-Curtis transformation:");
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"	result={Q    :f6}, tolerance={tol :e3}, calls={calls}\n");
	Write($"	exact ={exact:f6}, error    ={aerr:e3}, ");
	if(aerr<tol)WriteLine("test passed");
	else WriteLine("test failed");
	WriteLine("  Solution without Clenshaw-Curtis transformation:");
	double aerrwo=Abs(Qwo-exact),tolwo=acc+eps*Abs(Qwo);
	Write($"	result={Qwo    :f6}, tolerance={tolwo :e3}, calls={callswo}\n");
	Write($"	exact ={exact:f6}, error    ={aerrwo:e3}, ");
	if(aerrwo<tolwo)WriteLine("test passed\n");
	else WriteLine("test failed\n");
	}

	WriteLine("The Clenshaw-Curtis transformation clearly reduces the number of recursive calls without significantly increasing the error.\n");


{
	int calls=0, callswo=0, callso8av=0;
	Func<double,double> f=delegate(double x){calls++;return 4*Sqrt(1-x*x);};
	Func<double,double> fwo=delegate(double x){callswo++;return 4*Sqrt(1-x*x);};
	Func<double,double> fo8av=delegate(double x){callso8av++;return 4*Sqrt(1-x*x);};

	WriteLine($"Integral: ∫_{a}^{b} 4*Sqrt(1-x*x) dx, acc={acc} eps={eps}");
	double exact=PI;
	double Q=quad.clenshawcurtis(f,a,b,acc,eps);
	double Qwo=quad.adapt4(fwo,a,b,acc,eps);
	double Qo8av=quad.o8av(fo8av,a,b,acc,eps);
	WriteLine("  Solution using Clenshaw-Curtis transformation:");
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"	result={Q    :f16}, tolerance={tol :e3}, calls={calls}\n");
	Write($"	exact ={exact:f16}, error    ={aerr:e3}, ");
	if(aerr<tol)WriteLine("test passed");
	else WriteLine("test failed");
	WriteLine("  Solution without Clenshaw-Curtis transformation:");
	double aerrwo=Abs(Qwo-exact),tolwo=acc+eps*Abs(Qwo);
	Write($"	result={Qwo    :f16}, tolerance={tolwo :e3}, calls={callswo}\n");
	Write($"	exact ={exact:f16}, error    ={aerrwo:e3}, ");
	if(aerrwo<tolwo)WriteLine("test passed");
	else WriteLine("test failed");
	WriteLine("  Solution using o8av:");
	double aerro8av=Abs(Qo8av-exact),tolo8av=acc+eps*Abs(Qo8av);
	Write($"	result={Qo8av    :f16}, tolerance={tolo8av :e3}, calls={callso8av}\n");
	Write($"	exact ={exact:f16}, error    ={aerro8av:e3}, ");
	if(aerro8av<tolo8av)WriteLine("test passed\n");
	else WriteLine("test failed\n");

	}
WriteLine("The 'o8av' integration routine from the matlib is much faster, i.e., it requires fewer calls, however it is not as accurate as the other integration routines.");

}
}