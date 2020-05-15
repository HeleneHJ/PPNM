using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	int calls=0;
	double a=0,b=1,acc=1e-3,eps=1e-3;

	{
	Func<double,double> f=delegate(double x){calls++;return Sqrt(x);};
	WriteLine($"integral_{a}^{b} Sqrt(x) dx, acc={acc} eps={eps}");
	double exact=2.0/3;
	double[] q=quad.adapt4(f,a,b,acc,eps);
	double Q=q[0],err=q[1],aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	WriteLine($"result={Q}, calls={calls}");
	WriteLine($"exact ={exact}");
	WriteLine($"tilerance       ={tol}");
	WriteLine($"estimated error ={err}");
	WriteLine($"actual error    ={aerr}");
	if(aerr<err && err<tol)WriteLine("test passed :)\n");
	else WriteLine("test failed :)\n");
	}

	{
	calls=0; acc=1e-6; eps=0;
	Func<double,double> f=delegate(double x){calls++;return 4*Sqrt(1-x*x);};
	WriteLine($"integral_{a}^{b} 4*Sqrt(1-x^2) dx, acc={acc} eps={eps}");
	double exact=PI;
	double[] q=quad.adapt4(f,a,b,acc,eps,limit:100);
	double Q=q[0],err=q[1],aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	WriteLine($"result={Q}, calls={calls}");
	WriteLine($"exact ={exact}");
	WriteLine($"tilerance       ={tol}");
	WriteLine($"estimated error ={err}");
	WriteLine($"actual error    ={aerr}");
	if(aerr<err && err<tol)WriteLine("test passed :)\n");
	else WriteLine("TEST FAILED :(\n");
	}

	{
	calls=0; acc=1e-6; eps=0;
	Func<double,double> f=delegate(double x){calls++;return 4*Sqrt(1-x*x);};
	WriteLine("o8av:");
	WriteLine($"integral_{a}^{b} 4*Sqrt(1-x^2) dx, acc={acc} eps={eps}");
	double exact=PI;
	double Q=quad.o8av(f,a,b,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	WriteLine($"result={Q}, calls={calls}");
	WriteLine($"exact ={exact}");
	WriteLine($"tilerance       ={tol}");
	WriteLine($"actual error    ={aerr}");
	if(aerr<tol)WriteLine("test passed :)\n");
	else WriteLine("TEST FAILED :(\n");
	}

}
}