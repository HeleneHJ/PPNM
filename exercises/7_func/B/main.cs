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

WriteLine("B)\n");

System.Func<double,double> f1 = (x) => Sqrt(x)*Exp(-x);
double a1=0; double b1=inf; double acc1=1e-5; double eps1=1e-5;
double result1=quad.o8av(f1,a1,b1,acc1,eps1);
WriteLine("Integral: ∫_0^∞ sqrt(x)*exp(-x) dx\n");
WriteLine($"	Calculated result: {result1}");
WriteLine($"	True result: {(Sqrt(PI))/2}\n");
Write($"	Accuracy requirement ({acc1}): ");
if(approx(result1,Sqrt(PI)/2,acc1,eps1))Write("passed\n");
else {Write("failed\n");}

Write("\n\n");
System.Func<double,double> f2 = (x) => x/(Exp(x)-1);
double result2=quad.o8av(f2,a1,b1,acc1,eps1);
WriteLine("Integral: ∫_0^∞ x/(exp(x)-1) dx\n");
WriteLine($"	Calculated result: {result2}");
WriteLine($"	True result: {(Pow(PI,2))/6}\n");
Write($"	Accuracy requirement ({acc1}): ");
if(approx(result2,(Pow(PI,2))/6,acc1,eps1))Write("passed\n");
else {Write("failed\n");}

Write("\n\n");
System.Func<double,double> f3 = (x) => Sin(x)/x;
double result3=quad.o8av(f3,a1,b1,acc1,eps1);
WriteLine("Integral: ∫_0^∞ sin(x)/x dx\n");
WriteLine($"	Calculated result: {result3}");
WriteLine($"	True result: {PI/2}\n");
Write($"	Accuracy requirement ({acc1}): ");
if(approx(result3,PI/2,acc1,eps1))Write("passed\n");
else {Write("failed\n");}

Write("\n\n");
System.Func<double,double> f4 = (x) => Pow(x,-x);
double a4=0; double b4=1; double acc4=1e-5; double eps4=1e-5;
double result4=quad.o8av(f4,a4,b4,acc4,eps4);
WriteLine("Integral: ∫_0^∞ x^(-x) dx\n");
WriteLine($"	Calculated result: {result4}");
WriteLine($"	True result: 1.29128599706266\n");
Write($"	Accuracy requirement ({acc4}): ");
if(approx(result4,1.29128599706266,acc4,eps4))Write("passed\n");
else {Write("failed\n");}



return 0;
}
}