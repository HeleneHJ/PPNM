using System;
using static System.Console;
using static System.Math;
class main{

static void Main(string[] args){
	double rmax=10;
	if(args.Length>0)rmax=double.Parse(args[0]);
	Error.Write($"rmax = {rmax}\n");

	Func<vector,vector> master = (vector v)=>{
		double e=v[0];
		double frmax=hydrogen.Fe(e,rmax);
		return new vector(frmax);
		};

	vector vstart=new vector(-1.0);
	vector vroot=roots.newton(master,vstart,eps:1e-4);
	double energy=vroot[0];
	Write("# rmax, e\n");
	Write("{0} {1}\n",rmax,energy);
	Write("\n\n");

	Write("# r, Fe(e,r), exact\n");
	for(double r=0; r<=rmax; r+=rmax/64)
		Write("{0} {1} {2}\n",r,hydrogen.Fe(energy,r),r*Exp(-r));
}
}//main