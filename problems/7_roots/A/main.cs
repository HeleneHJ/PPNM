using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	vector c = new vector("1 1");
	int n=c.size;
	matrix A = new matrix(n,n);
	var rnd=new System.Random(1);
	for(int i=0;i<n;i++)
	for(int j=0;j<n;j++)A[i,j]=2*(rnd.NextDouble()-0.5);
	int ncalls=0;
	Func<vector,vector> f = (z)=>{
		ncalls++;
		return (A*(z-c)).map(t=>t*t*t);
		};
/*
	Func<vector,vector> f = delegate(vector z){
		ncalls++;
		vector r=new vector(2);
		double x=z[0],y=z[1],b=10;
		r[0]=2*(1-x)*(-1)+b*2*(y-x*x)*(-1)*2*x;
		r[1]=b*2*(y-x*x);
		return r;
	};
*/
	double eps=1e-4;
	vector p = new vector("2 2");
p.print("broyden:\n start point:");
	vector root = roots.broyden(f,p,eps);
	WriteLine($"ncalls={ncalls}");
	root.print("root=");
	f(root).print("f(root)=");
	WriteLine($"eps            = {eps}");
	WriteLine($"f(root).norm() = {f(root).norm()}");
	if(f(root).norm()<eps)WriteLine("test passed");
	else                  WriteLine("test failed");

	ncalls=0;
p.print("\nnewton:\n start point:");
	root = roots.newton(f,p,eps);
	WriteLine($"ncalls={ncalls}");
	root.print("root=");
	f(root).print("f(root)=");
	WriteLine($"eps            = {eps}");
	WriteLine($"f(root).norm() = {f(root).norm()}");
	if(f(root).norm()<eps)WriteLine("test passed");
	else                  WriteLine("test failed");
}
}