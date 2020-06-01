using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	int ncalls=0;
	double eps=1e-7;
	vector p = new vector(2);
	p[0]=0.5; p[1]=1.7;

	Func<vector,vector> f = delegate(vector z){
		ncalls++;
		vector r=new vector(2);
		double x=z[0],y=z[1],b=100;
		// Rosenbrock's valley function: f(x,y) = (1-x)^2+100*(y-x^2)^2
		// The gradient of Rosenbrock's valley function:
		r[0]=2*(1-x)+2*100*(y-x*x)*(-2*x); // d/dx 
		r[1]=b*2*(y-x*x); // d/dy 
		return r;
	};	
	vector root = roots.newton(f,p,eps);
	WriteLine($"start values={p[0]}	{p[1]}");
	WriteLine($"ncalls={ncalls}");
	root.print("root=");
	f(root).print("f(root)=");
	WriteLine($"eps            = {eps}");
	WriteLine($"f(root).norm() = {f(root).norm()}");
	if(f(root).norm()<eps)WriteLine("test passed");
	else                  WriteLine("test failed");
}
}