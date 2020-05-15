using System;
using static System.Console;
using static System.Math;
public partial class qnewton{

/*
public static readonly double EPS=1.0/1048576;
public static readonly double EPS=1.0/2097152;
*/
public static readonly double two22=4194304;
public static readonly double EPS=1/two22;

public static vector gradient(Func<vector,double>f, vector x){
	vector g=new vector(x.size);
	double fx=f(x);
	for(int i=0;i<x.size;i++){
/*
		double dx=EPS;
*/
		double dx=Abs(x[i])*EPS;
		if(Abs(x[i])<Sqrt(EPS)) dx=EPS;
		x[i]+=dx;
		g[i]=(f(x)-fx)/dx;
		x[i]-=dx;
	}
	return g;
}

public static int sr1
(Func<vector,double>f, ref vector x, double acc=1e-3){
	double fx=f(x);
	vector gx=gradient(f,x);
	matrix B=matrix.id(x.size);
	int nsteps=0;
	while(nsteps<999){
		nsteps++;
		vector Dx=-B*gx;
		if(Dx.norm()<EPS*x.norm()){
			Error.Write($"broyden: |Dx|<EPS*|x|\n");
			break;
			}
		if(gx.norm()<acc){
			Error.Write($"broyden: |gx|<acc\n");
			break;
			}
		vector z;
		double fz,lambda=1;
		while(true){// backtracking linesearch
			z=x+Dx*lambda;
			fz=f(z);
			if(fz<fx){
				break; // good step
				}
			if(lambda<EPS){
				B.setid();
				break; // accept anyway
				}
			lambda/=2;
		}
		vector s=z-x;
		vector gz=gradient(f,z);
		vector y=gz-gx;
		vector u=s-B*y;
		double uTy=u%y;
		if(Abs(uTy)>1e-6){
			B.update(u,u,1/uTy); // SR1 update
		}
		x=z;
		gx=gz;
		fx=fz;
	}
	return nsteps;
}//SR1

}//class