using System;
using static System.Math;
using static System.Console;
public class network{

public vector p;
public Func<double,double> f;
public readonly int n;

public network(int n, Func<double,double> f){
	this.n=n;
	this.f=f;
	this.p=new vector(3*n);
	}

public double feed(double x){
	double sum=0;
	for(int i=0;i<n;i++){
		double a=p[3*i+0];
		double b=p[3*i+1];
		double w=p[3*i+2];
		sum+=w*f((x-a)/b);
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
			sum+=Pow(feed(xs[k])-ys[k],2);
Error.Write($"mismatch={sum/xs.Length}\n");
		return sum/xs.Length;
		};
	vector v=p;
	//int nsteps=qnewton.sr1(mismatch,ref v,1e-2);
	double nsteps=simplex.downhill(mismatch,ref v,step:0.2,dx:1e-2);
	p=v;
Error.Write($"ncalls={ncalls}\n");
Error.Write($"nsteps={nsteps}\n");
	}

}//network