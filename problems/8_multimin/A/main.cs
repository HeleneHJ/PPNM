using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){

	Func<vector,double> f1=(z)=>(1-z[0])*(1-z[0])+100*(z[1]-z[0]*z[0])*(z[1]-z[0]*z[0]); // Rosenbrock's valley function (a=1,b=100)
	double eps=1e-4;
	vector p = new vector("2 3");	// starting point
	Write("SR1: Rosenbrock's valley function\n");
	p.print("start point:");
	int nsteps = qnewton.sr1(f1,ref p,eps);
	WriteLine($"nsteps={nsteps}");
	p.print("minimum:    ");
	Write($"f(x_min)          = {(float)f1(p)}\n");
	vector g=qnewton.gradient(f1,p);
	Write($"|gradient| goal   = {(float)eps}\n");
	Write($"|gradient| actual = {(float)g.norm()}\n");
	if(g.norm()<eps)WriteLine("test passed");
	else            WriteLine("test failed");
	// Minimum at (1,1)

	Func<vector,double>f2=(z)=>(z[0]*z[0]+z[1]-11)*(z[0]*z[0]+z[1]-11)+(z[0]+z[1]*z[1]-7)*(z[0]+z[1]*z[1]-7); // Himmelblau's function
	eps=1e-4;
	p = new vector("0 1"); 			// starting point
	Write("\nSR1: Himmelblau's function\n");
	p.print("start point:");
	nsteps = qnewton.sr1(f2,ref p,eps);
	WriteLine($"nsteps={nsteps}");
	p.print("minimum:    ");
	Write($"f(x_min)          = {(float)f2(p)}\n");
	g=qnewton.gradient(f,p);
	Write($"|gradient| goal   = {(float)eps}\n");
	Write($"|gradient| actual = {(float)g.norm()}\n");
	if(g.norm()<eps)WriteLine("test passed");
	else            WriteLine("test failed");
	// Minima at (3,2), (-2.805118,3.131312), (-3.779310,-3.283186), and (3.584428,-1.848126)
}
}