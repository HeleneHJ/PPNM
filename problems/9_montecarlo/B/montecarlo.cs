using System;
using static System.Console;
using static System.Math;
public partial class montecarlo{
public static vector plainmc(Func<vector,double> f, vector a, vector b, int N){
	var rand=new Random();
	Func<vector> randomx=delegate(){ //generate random x-values (abscissas) between a and b
		vector x=new vector(a.size);
		for(int i=0;i<x.size;i++){
			x[i]=a[i]+rand.NextDouble()*(b[i]-a[i]);
		}
		return x;
	};

	double volume=1;
	for(int i=0;i<a.size;i++){
		volume*=b[i]-a[i];
	}

	double sum=0; 
	double sum2=0;
	for(int i=0;i<N;i++){
		vector rx=randomx();
		double fx=f(rx);
		sum+=fx;				//f
		sum2+=fx*fx;			//f^2
	}

	double mean=sum/N;							// <f_i>
	double sigma=Sqrt(sum2/N-mean*mean);		// sigma^2 = <(f_i)^2> - <f_i>^2 (eq. 4)
	double SIGMA=sigma/Sqrt(N);					// SIGMA^2 = <Q^2> - <Q>^2 

	double result=mean*volume;					//approximate integral of f(x) (eq. 2)
	double error=SIGMA*volume;					//error (eq .3)

	return new vector(result, error);	
}
}