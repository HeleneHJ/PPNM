using static System.Console;
static class main{
static void Main(){
	for(double x=-3;x<=3;x+=0.125)
		WriteLine($"{x} {specfunc.erf(x)}");
}
}