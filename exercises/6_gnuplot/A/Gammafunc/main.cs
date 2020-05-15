using static System.Console;
static class main{
static void Main(){
	double eps=1.0/64, dx=1.0/32;
	for(double x=-4+eps;x<=5-eps;x+=dx)
		WriteLine($"{x} {specfunc.gamma(x)}");
}
}