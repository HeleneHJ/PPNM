using System;
using static System.Console;
using static System.Math;
class main{
static void Main(){
/* A */
	var t0 =new vector(new double[]{1,2,3,4,6,9,10,13,15});
	var y0 =new vector(new double[]{117,100,88,72,53,29.5,25.2,15.2,11.1});
	var dy0=0.05*y0;
	var f = new Func<double,double>[]{x=>1,x=>x};
	int n=t0.size;
	var t=new vector(n);
	var y=new vector(n);
	var dy=new vector(n);
	for(int i=0;i<n;i++){
		t[i]=t0[i];
		y[i]=Log(y0[i]);
		dy[i]=dy0[i]/y0[i];
		}
	
	var fit=new lsfit(t,y,dy,f);	
	
	for(int i=0;i<t.size;i++)
		WriteLine($"{t0[i]} {y0[i]} {dy0[i]}");

	int k,N=100;
	double z, step=(t[t.size-1]-t[0])/(N-1);

	WriteLine("\n\n");
	for(z=t[0], k=0;k<N;z=t[0]+(++k)*step)
		WriteLine($"{z} {Exp(fit.eval(z))}");


	double lambda=fit.c[1];
	double dlambda=Sqrt(fit.sigma[1,1]);
	// Error.WriteLine($"lambda={lambda:f5}, dlambda={dlambda:f5}");
	double T=-Log(2.0)/lambda;								// half-life
	double dT=Abs(dlambda/lambda/lambda);					// half-life uncertainty
	Error.WriteLine("A)");						
	Error.WriteLine($"ThX half-life from fit = {T:f1} +/- {dT:f1} days");
	Error.WriteLine($"The modern value for the half-life of 224-Rn = {3.619} +/- {0.023} days");
	Error.WriteLine("The value obtained from the fit agrees with the modern value within the uncertainties of the fit");
	Error.WriteLine("(Source: https://en.wikipedia.org/wiki/Isotopes_of_radium)\n");

/* B) */
	matrix sigma=fit.sigma;
	Error.WriteLine("B)");
	Error.WriteLine($"The covariance matrix, Σ: \n {sigma[0,0]:f6}	{sigma[0,1]:f6} \n {sigma[1,0]:f6}	{sigma[1,1]:f6}");
	Error.WriteLine("\nThe fitting parameters with uncertainties are:");
	vector unc=new vector(sigma.size1);
	for(int i=0;i<sigma.size1;i++){
			unc[i]=Sqrt(sigma[i,i]);
		Error.WriteLine($"c[{i}]: {fit.c[i]:f6} +/- {unc[i]:f6}");
	}

/* C) */

	WriteLine("\n\n");
	fit.c[0]+=Sqrt(fit.sigma[0,0]);
	for(z=t[0], k=0;k<N;z=t[0]+(++k)*step)
		WriteLine($"{z} {Exp(fit.eval(z))}");

	WriteLine("\n\n");
	fit.c[0]-=2*Sqrt(fit.sigma[0,0]);
	for(z=t[0], k=0;k<N;z=t[0]+(++k)*step)
		WriteLine($"{z} {Exp(fit.eval(z))}");

	fit.c[0]+=Sqrt(fit.sigma[0,0]);

	WriteLine("\n\n");
	fit.c[1]+=Sqrt(fit.sigma[1,1]);
	for(z=t[0], k=0;k<N;z=t[0]+(++k)*step)
		WriteLine($"{z} {Exp(fit.eval(z))}");

	WriteLine("\n\n");
	fit.c[1]-=2*Sqrt(fit.sigma[1,1]);
	for(z=t[0], k=0;k<N;z=t[0]+(++k)*step)
		WriteLine($"{z} {Exp(fit.eval(z))}");

}
}