using static System.Console;
using static System.Math;
static class main{
static void Main(){
	double dx=1.0/64;
	for(double q=dx;q<=5;q+=dx)
		{
		double x=Pow(10,q);
		WriteLine($"{x} {specfunc.lngamma(x)}");
		}
}
}