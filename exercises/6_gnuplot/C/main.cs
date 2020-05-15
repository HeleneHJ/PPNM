using static System.Console;
using static cmath;
static class main{
static void Main(){
	double eps=1.0/64, dx=1.0/16, dy=dx;
	for(double x=-3.2+eps;x<=4.5-eps;x+=dx){
		WriteLine();
		for(double y=-3+eps;y<-1;y+=2*dy)
			WriteLine($"{x} {y} {abs(specfunc.gamma(x+complex.I*y))}");
		for(double y=-1+eps;y<1;y+=0.5*dy)
			WriteLine($"{x} {y} {abs(specfunc.gamma(x+complex.I*y))}");
		for(double y=1;y<=3-eps;y+=2*dy)
			WriteLine($"{x} {y} {abs(specfunc.gamma(x+complex.I*y))}");
		}
}
}