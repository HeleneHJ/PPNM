using System;
using static System.Math;
using static System.Console;
class main{
const double inf=double.PositiveInfinity;
public static bool approx(double x, double y, double acc=1e-6, double eps=1e-6){
        if(Abs(x-y)<acc)return true;
        if(Abs(x-y)<eps*(Abs(x)+Abs(y))/2)return true;
        return false;
}
static int Main(){

// int ncalls=0;
// int ierr=0;
// double q,exact,acc,eps;
// System.Func<double,double> f;

WriteLine("A)\n");

Func<double,double> f1 = (x) => Log(x)/Sqrt(x);
double a1=0; double b1=1; double acc1=1e-5; double eps1=1e-5;
double result1=quad.o8av(f1,a1,b1,acc1,eps1);
WriteLine("Integral: ∫_0^1 ln(x)/sqrt(x) dx\n");
WriteLine($"	Calculated result: {result1}");
WriteLine("	True result: -4.00000000000\n");
Write($"	Accuracy requirement ({acc1}): ");
if(approx(result1,-4.00000000000,acc1,eps1))Write("passed\n");
else {Write("failed\n");}

WriteLine("\n\n");
Func<double,double> f2 = (x) => Exp(-x*x);
double a2=-inf; double b2=inf; double acc2=1e-6; double eps2=1e-6;
double result2=quad.o8av(f2,a2,b2);
WriteLine("Integral: ∫_-∞^+∞ (exp(-x^2)) dx\n");
WriteLine($"	Calculated result: {result2}");
WriteLine($"	True result: {Sqrt(PI)}\n");
Write($"	Accuracy requirement ({acc2}): ");
if(approx(result2,Sqrt(PI),acc2,eps2))Write("passed\n");
else {Write("failed\n");}

WriteLine("\n\n");
WriteLine("Integral: ∫_0^1 (ln(1/x))^p dx\n");
WriteLine("For p=1/2:\n");

int p7=1/2;
Func<double,double> f7 = (x) => Pow(Log(1/x),p7);
double a3=0; double b3=1; double acc3=1e-6; double eps3=1e-6;
double result7=quad.o8av(f7,a3,b3);
WriteLine($"	Calculated result: {result7:f5}");
WriteLine($"	True result: 0.886227\n");
Write($"	Accuracy requirement ({acc3}): ");
if(approx(result7,0.886227,acc3,eps3))Write("passed\n");
else {Write("failed\n");}

WriteLine("\nFor p=1:\n");
int p3=1;
Func<double,double> f3 = (x) => Pow(Log(1/x),p3);
// double a3=0; double b3=1; double acc3=1e-6; double eps3=1e-6;
double result3=quad.o8av(f3,a3,b3);
WriteLine($"	Calculated result: {result3}");
WriteLine($"	True result: 1.000000000\n");
Write($"	Accuracy requirement ({acc3}): ");
if(approx(result3,1.000000000,acc3,eps3))Write("passed\n");
else {Write("failed\n");}

WriteLine("\nFor p=2:\n");
int p4=2;
Func<double,double> f4 = (x) => Pow(Log(1/x),p4);
double result4=quad.o8av(f4,a3,b3);
WriteLine($"	Calculated result: {result4}");
WriteLine($"	True result: 2.000000000\n");
Write($"	Accuracy requirement ({acc3}): ");
if(approx(result4,2.000000000,acc3,eps3))Write("passed\n");
else {Write("failed\n");}

WriteLine("\nFor p=5:\n");
int p5=5;
Func<double,double> f5 = (x) => Pow(Log(1/x),p5);
double result5=quad.o8av(f5,a3,b3);
WriteLine($"	Calculated result: {result5}");
WriteLine($"	True result: 120.000000000\n");
Write($"	Accuracy requirement ({acc3}): ");
if(approx(result5,120.000000000,acc3,eps3))Write("passed\n");
else {Write("failed\n");}

WriteLine("\nFor p=10:\n");
int p6=10;
Func<double,double> f6 = (x) => Pow(Log(1/x),p6);
double result6=quad.o8av(f6,a3,b3);
WriteLine($"	Calculated result: {result6}");
WriteLine($"	True result: 3628800.00\n");
Write($"	Accuracy requirement ({acc3}): ");
if(approx(result6,3628800.00,acc3,eps3))Write("passed\n");
else {Write("failed\n");}



// acc=1e-6; eps=0; exact = 2;
// WriteLine($"o8av: testing ∫_0^1 ln(1/x)^2 dx={exact},acc={acc},eps={eps}");
// f = delegate(double x){ ncalls++; return Pow(Log(1/x),2); };
// ncalls=0; q=quad.o8av(f,0,1,acc,eps);
// WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
// if(approx(q,exact,acc,eps))WriteLine("test passed\n");
// else {ierr++;WriteLine("test failed\n");}

// WriteLine($"failed tests: {ierr}");
// return ierr;
return 0;
}
}