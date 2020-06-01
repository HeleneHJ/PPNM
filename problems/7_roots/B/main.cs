using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	double r_max=8;
	Func<vector,vector> M = delegate(vector e){	// the auxiliary function M(eps)=F_eps(r_max)
			double eps=e[0];
			double f_rmax=hydrogen.F_eps(eps,r_max);
			return new vector(f_rmax);
		};

	vector e_start=Dealnew vector(-1.0);
	vector e_root=roots.newton(M,e_start,eps:1e-4);
	double energy=e_root[0];

	Write("\n\n");
	for(double r=0; r<=r_max; r+=r_max/100){
			WriteLine($"{r}	{hydrogen.F_eps(energy,r)}	{r*Exp(-r)}");
		}

	Error.Write("\n\n");
	Error.WriteLine($"r_max={r_max}");
	Error.WriteLine($"calculated: 	energy={energy:f9}");
	Error.WriteLine($"exact result:	energy=-0.500000000");
}//Main method
}//class