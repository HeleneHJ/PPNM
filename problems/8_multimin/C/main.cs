using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	int ncalls;
	Func<vector,double> f;

	ncalls=0;
	f=(z)=>{ncalls++; return (1-z[0])*(1-z[0])+100*(z[1]-z[0]*z[0])*(z[1]-z[0]*z[0]);};
	double dx=1e-3;
	vector p = new vector("3 3");
	Write("simplex.downhill: Rosenbrock's valley function\n");
	p.print("start point:");
	double psize = simplex.downhill(f,ref p,dx:dx);
	WriteLine($"simplex size= {(float)psize}");
	WriteLine($"ncalls = {ncalls}");
	p.print("minimum:    ");
	Write($"f(x_min)          = {(float)f(p)}\n");


	ncalls=0;
	f=(z)=>{ncalls++; return (z[0]*z[0]+z[1]-11)*(z[0]*z[0]+z[1]-11)+(z[0]+z[1]*z[1]-7)*(z[0]+z[1]*z[1]-7);};
	double dx2=1e-3;
	vector p2 = new vector("1 3");
	Write("\nsimplex.downhill: Himmelblau's function\n");
	p2.print("start point:");
	double psize2 = simplex.downhill(f,ref p2,dx:dx2);
	WriteLine($"simplex size= {(float)psize2}");
	WriteLine($"ncalls = {ncalls}");
	p2.print("minimum:    ");
	Write($"f(x_min)          = {(float)f(p2)}\n");
}
}