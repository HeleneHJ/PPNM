using System;
using static System.Math;
using static System.Console;
public class network{

public vector p;					//p: set of parameters
public readonly int n;				//n: number of sets
public Func<double,double> f;		//f: activation function
public Func<double,double> df;		//df: differentiated activation function
public Func<double,double> F;		//F: integrated activation function

public network(int n, Func<double,double> f, Func<double,double> df, Func<double,double> F){
	this.n=n;
	this.p=new vector(3*n);		//p containts sets of 3 parameters: ai, bi, and wi for i=1,..,n
	this.f=f;
	this.df=df;
	this.F=F;
	}

public double feed(double x){
	double sum=0;
	for(int i=0;i<n;i++){
		double a=p[3*i+0];		//a: first parameter in p
		double b=p[3*i+1];		//b: second parameter in p
		double w=p[3*i+2];		//w: third parameter in p
		sum+=w*f((x-a)/b);		//output signal y=f((x-ai)/bi)*wi
		}
	return sum;
	}

public double feeddf(double x){
	double sum=0;
	for(int i=0;i<n;i++){
		double a=p[3*i+0];		//a: first parameter in p
		double b=p[3*i+1];		//b: second parameter in p
		double w=p[3*i+2];		//w: third parameter in p
		sum+=w/b*df((x-a)/b);		//output signal y=f((x-ai)/bi)*wi
		}
	return sum;
	}

public double feedF(double x){
	double sum=0;
	for(int i=0;i<n;i++){
		double a=p[3*i+0];		//a: first parameter in p
		double b=p[3*i+1];		//b: second parameter in p
		double w=p[3*i+2];		//w: third parameter in p
		sum+=b*w*F((x-a)/b);		//output signal y=f((x-ai)/bi)*wi
		}
	return sum;
	}

public void train(double[] xs,double[] ys){
	int ncalls=0;
	Func<vector,double> mismatch=(u)=>{	
		ncalls++;
		p=u;
		double sum=0;
		for(int k=0;k<xs.Length;k++)
			sum+=Pow(feed(xs[k])-ys[k],2);	//deviation: δ(p)=∑(F_p(x_k)-y_k)^2, with k=1,..,N
	// Error.Write($"mismatch={sum/xs.Length}\n");
		return sum/xs.Length;				
		};//mismatch
	vector v=p;
	//int nsteps=qnewton.sr1(mismatch,ref v,1e-2);					 //minimization of deviation (using the qnewton SR1 minimization routine)
	double nsteps=simplex.downhill(mismatch,ref v,step:0.2,dx:1e-2); //minimization of deviation (using the downhill simplex minimization routine)
	p=v;
	Error.Write($"ncalls={ncalls}\n");
	Error.Write($"nsteps={nsteps}\n");
	}

// public double deriv(double x){
//     double dev=0;
// 	for(int i=0;i<n;i++){
//     	double a=p[3*i+0];		//a: first parameter in p
// 		double b=p[3*i+1];		//b: second parameter in p
// 		double w=p[3*i+2];		//w: third parameter in p
// 		dev+=w*f((x-a)/b)*(-2.0/(b*b)*(x-a));
//     }
//     return dev;
// }

}//network